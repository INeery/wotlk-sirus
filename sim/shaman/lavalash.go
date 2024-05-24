package shaman

import (
	"time"

	"github.com/wowsims/wotlk/sim/core"
	"github.com/wowsims/wotlk/sim/core/proto"
	"github.com/wowsims/wotlk/sim/core/stats"
)

// Totem IDs
const (
	VentureCoFlameSlicer                      = 38367
	DeadlyGladiatorsTotemOfIndomitability     = 42607
	FuriousGladiatorsTotemOfIndomitability    = 42608
	RelentlessGladiatorsTotemOfIndomitability = 42609
	WrathfulGladiatorsTotemOfIndomitability   = 51507
)

func (shaman *Shaman) registerLavaLashSpell() {
	if !shaman.Talents.LavaLash {
		return
	}

	flatDamageBonus := core.TernaryFloat64(shaman.Ranged().ID == VentureCoFlameSlicer, 25, 0)

	imbueMultiplier := 1.0
	if shaman.SelfBuffs.ImbueOH == proto.ShamanImbue_FlametongueWeapon || shaman.SelfBuffs.ImbueOH == proto.ShamanImbue_FlametongueWeaponDownrank {
		imbueMultiplier = 2
		if shaman.HasMajorGlyph(proto.ShamanMajorGlyph_GlyphOfLavaLash) {
			imbueMultiplier = 2.1
		}
	}

	var indomitabilityAura *core.Aura
	switch shaman.Ranged().ID {
	case DeadlyGladiatorsTotemOfIndomitability:
		indomitabilityAura = shaman.NewTemporaryStatsAura("Deadly Aggression", core.ActionID{SpellID: 60549}, stats.Stats{stats.AttackPower: 120}, time.Second*10)
	case FuriousGladiatorsTotemOfIndomitability:
		indomitabilityAura = shaman.NewTemporaryStatsAura("Furious Gladiator's Libram of Fortitute", core.ActionID{SpellID: 60551}, stats.Stats{stats.AttackPower: 144}, time.Second*10) //wowhead is wierd about this one, might be the same in-game idk
	case RelentlessGladiatorsTotemOfIndomitability:
		indomitabilityAura = shaman.NewTemporaryStatsAura("Relentless Aggression", core.ActionID{SpellID: 60553}, stats.Stats{stats.AttackPower: 172}, time.Second*10)
	case WrathfulGladiatorsTotemOfIndomitability:
		indomitabilityAura = shaman.NewTemporaryStatsAura("Fury of the Gladiator", core.ActionID{SpellID: 60555}, stats.Stats{stats.AttackPower: 204}, time.Second*10)
	}

	var volcanicSurge *core.Spell
	if shaman.HasSetBonus(ItemSetEarthshatterBattlegear, 2) {
		volcanicSurge = shaman.RegisterSpell(core.SpellConfig{
			ActionID:         core.ActionID{SpellID: 373522},
			SpellSchool:      core.SpellSchoolFire,
			ProcMask:         core.ProcMaskEmpty,
			Flags:            core.SpellFlagNoOnCastComplete | core.SpellFlagIgnoreModifiers, // TODO Выяснить применяется ли к урону модификаторы цели (дебаф от лока например)
			DamageMultiplier: 1,
			ThreatMultiplier: 1,

			ApplyEffects: func(sim *core.Simulation, target *core.Unit, spell *core.Spell) {
				//TODO может мисануть, критануть, учитывает множитель урона шамана?
				dmgMultiplier := shaman.AttackTables[target.UnitIndex].DamageDealtMultiplier
				baseDamage := shaman.Unit.GetStats()[stats.AttackPower] * 0.3 * dmgMultiplier

				for targetIndex := int32(0); targetIndex < shaman.Env.GetNumTargets(); targetIndex++ {
					curTarget := shaman.Env.GetTargetUnit(targetIndex)
					spell.CalcAndDealDamage(sim, curTarget, baseDamage, spell.OutcomeAlwaysHit)
				}
			},
		})
	}

	shaman.LavaLash = shaman.RegisterSpell(core.SpellConfig{
		ActionID:    core.ActionID{SpellID: 60103},
		SpellSchool: core.SpellSchoolFire,
		ProcMask:    core.ProcMaskMeleeOHSpecial,
		Flags:       core.SpellFlagMeleeMetrics | core.SpellFlagAPL | core.SpellFlagStormstrikeBoostable,

		ManaCost: core.ManaCostOptions{
			BaseCost: 0.04,
		},
		Cast: core.CastConfig{
			DefaultCast: core.Cast{
				GCD: core.GCDDefault,
			},
			IgnoreHaste: true,
			CD: core.Cooldown{
				Timer:    shaman.NewTimer(),
				Duration: time.Second * 6,
			},
		},

		//TODO можно проверить, но пока кажется что WeaponMastery влияет на урон ЛБ и УБ (так как это расчёт урона от оружия хотя и не физ школа)
		DamageMultiplier: 1 * imbueMultiplier * []float64{1, 1.04, 1.07, 1.1}[shaman.Talents.WeaponMastery],
		CritMultiplier:   shaman.ElementalCritMultiplier(0),
		ThreatMultiplier: shaman.spellThreatMultiplier(),

		ApplyEffects: func(sim *core.Simulation, target *core.Unit, spell *core.Spell) {
			baseDamage := flatDamageBonus +
				spell.Unit.OHWeaponDamage(sim, spell.MeleeAttackPower()) +
				spell.BonusWeaponDamage()

			result := spell.CalcAndDealDamage(sim, target, baseDamage, spell.OutcomeMeleeSpecialHitAndCrit)

			if result.Landed() { //TODO: verify that it actually needs to hit
				if indomitabilityAura != nil {
					indomitabilityAura.Activate(sim)
				}
			}

			if result.Landed() {
				shaman.BiteWhenWolvesAreActive(sim, target)
			}

			if result.Landed() && volcanicSurge != nil {
				volcanicSurge.Cast(sim, target)
			}
		},
		ExtraCastCondition: func(sim *core.Simulation, target *core.Unit) bool {
			return shaman.HasOHWeapon()
		},
	})
}

func (shaman *Shaman) IsLavaLashCastable(sim *core.Simulation) bool {
	return shaman.LavaLash.IsReady(sim)
}
