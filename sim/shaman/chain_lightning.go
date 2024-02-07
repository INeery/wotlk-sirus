package shaman

import (
	"time"

	"github.com/wowsims/wotlk/sim/core"
	"github.com/wowsims/wotlk/sim/core/proto"
)

func (shaman *Shaman) registerChainLightningSpell() {
	numHits := GetChainLightningHitsNumber(shaman)
	shaman.ChainLightning = shaman.newChainLightningSpell(false)
	shaman.ChainLightningLOs = []*core.Spell{}
	for i := int32(0); i < numHits; i++ {
		shaman.ChainLightningLOs = append(shaman.ChainLightningLOs, shaman.newChainLightningSpell(true))
	}
}

func (shaman *Shaman) newChainLightningSpell(isLightningOverload bool) *core.Spell {
	spellConfig := shaman.newElectricSpellConfig(
		core.ActionID{SpellID: 49271},
		0.26,
		time.Millisecond*2000,
		isLightningOverload)

	if shaman.HasSetBonus(ItemSetWorldbreakerBattlegear, 4) {
		spellConfig.DamageMultiplier += 0.34
	}

	if !isLightningOverload {
		spellConfig.Cast.CD = core.Cooldown{
			Timer:    shaman.NewTimer(),
			Duration: GetChainLightningCooldown(shaman),
		}
	}

	numHits := GetChainLightningHitsNumber(shaman)

	dmgMultiplierPerBounce := GetGetChainLightningBounceMultiplier(shaman)
	dmgBonus := shaman.electricSpellBonusDamage(0.5714)
	spellCoeff := 0.5714 + 0.04*float64(shaman.Talents.Shamanism)

	canLO := !isLightningOverload && shaman.Talents.LightningOverload > 0
	lightningOverloadChance := float64(shaman.Talents.LightningOverload) * 0.11 / 3

	spellConfig.ApplyEffects = func(sim *core.Simulation, target *core.Unit, spell *core.Spell) {
		bounceCoeff := 1.0
		curTarget := target
		for hitIndex := int32(0); hitIndex < numHits; hitIndex++ {
			baseDamage := dmgBonus + sim.Roll(973, 1111) + spellCoeff*spell.SpellPower()
			baseDamage *= bounceCoeff
			result := spell.CalcDamage(sim, curTarget, baseDamage, spell.OutcomeMagicHitAndCrit)

			if canLO && result.Landed() && sim.RandomFloat("CL Lightning Overload") <= lightningOverloadChance {
				shaman.ChainLightningLOs[hitIndex].Cast(sim, curTarget)
			}

			spell.DealDamage(sim, result)

			if result.Landed() {
				shaman.BiteWhenWolvesAreActive(sim, target)
			}

			bounceCoeff *= dmgMultiplierPerBounce
			curTarget = sim.Environment.NextTargetUnit(curTarget)
		}
	}

	return shaman.RegisterSpell(spellConfig)
}

func GetChainLightningHitsNumber(shaman *Shaman) int32 {
	bonusHits := core.TernaryInt32(shaman.HasMajorGlyph(proto.ShamanMajorGlyph_GlyphOfChainLightning), 1, 0)
	bonusHits += shaman.Talents.StaticShock
	numHits := min(3+bonusHits, shaman.Env.GetNumTargets())
	return numHits
}

func GetChainLightningCooldown(shaman *Shaman) time.Duration {
	cooldown := time.Second*6 - []time.Duration{0, 750 * time.Millisecond, 1500 * time.Millisecond, 2500 * time.Millisecond}[shaman.Talents.StormEarthAndFire]
	cooldown -= []time.Duration{0, 2 * time.Second, 4 * time.Second, 6 * time.Second}[shaman.Talents.StaticShock]

	return max(cooldown, core.GCDDefault)
}

func GetGetChainLightningBounceMultiplier(shaman *Shaman) float64 {
	dmgReductionPerBounce := core.TernaryFloat64(shaman.HasSetBonus(ItemSetTidefury, 2), 0.87, 0.7)
	dmgReductionPerBounce += float64(shaman.Talents.StaticShock) * 0.1

	return max(dmgReductionPerBounce, 1)
}
