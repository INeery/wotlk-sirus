package core

import (
	"github.com/wowsims/wotlk/sim/core/proto"
	"github.com/wowsims/wotlk/sim/core/stats"
	"time"
)

func applyConstellationEffects(agent Agent) {
	character := agent.GetCharacter()

	switch character.Constellation {
	case proto.Constellation_ConstellationUnknown:
		{
		}
	case proto.Constellation_Demon:
		// Пассивные статы от 'Неистовста Хаоса'
		character.stats[stats.MeleeCrit] += CritRatingPerCritChance * 2
		character.stats[stats.SpellHaste] += HasteRatingPerHastePercent * 2

		// Мощь первобытного демона - аура +2% крит урона
		PowerOfPrimordialDemonAura(character)

		// Фрагмент души
		soulFragmentAura := Aura{
			Label:    "Soul Fragment",
			ActionID: ActionID{SpellID: 316463},
			Duration: NeverExpires,
			OnReset: func(aura *Aura, sim *Simulation) {
				aura.Activate(sim)
			},

			OnGain: func(aura *Aura, sim *Simulation) {
				//TODO а это множитель или аддитивно?
				character.PseudoStats.DamageDealtMultiplier *= 1.02
			},

			OnExpire: func(aura *Aura, sim *Simulation) {
				character.PseudoStats.DamageDealtMultiplier /= 1.02
			},
		}
		character.RegisterAura(soulFragmentAura)

		// Путь возвышения
		// имитируем шарды в сумке с помощью переменной.
		shards := 10
		pathOfElevationAura := character.GetOrRegisterAura(Aura{
			Label:    "Path Of Elevation",
			ActionID: ActionID{SpellID: 322329},
			Duration: time.Second * 20,

			OnGain: func(aura *Aura, sim *Simulation) {
				if shards < 1 {
					return
				}

				//TODO а это множитель или аддитивно?
				character.PseudoStats.DamageDealtMultiplier *= 1.04

				shards--
			},
			OnExpire: func(aura *Aura, sim *Simulation) {
				character.PseudoStats.DamageDealtMultiplier /= 1.04
			},

			OnDoneIteration: func(aura *Aura, sim *Simulation) {
				shards = 10
			},
		})

		pathOfElevationSpell := character.RegisterSpell(SpellConfig{
			ActionID: ActionID{SpellID: 316466},
			Flags:    SpellFlagNoOnCastComplete,
			Cast: CastConfig{
				DefaultCast: Cast{
					Cost: 0,
					GCD:  0,
				},
				IgnoreHaste: true,
				CD: Cooldown{
					Timer:    character.NewTimer(),
					Duration: time.Second * 20,
				},
			},
			ApplyEffects: func(sim *Simulation, _ *Unit, _ *Spell) {
				pathOfElevationAura.Activate(sim)
			},
		})

		// Пока это AddMajorCooldown с автоюзом. Не хочется включать в ротацию прожимку. Может просто сделать кол-во осколков настраевым?
		// Не используется если закончились стаки ауры
		character.AddMajorCooldown(MajorCooldown{
			Spell: pathOfElevationSpell,
			Type:  CooldownTypeDPS,
			ShouldActivate: func(sim *Simulation, character *Character) bool {
				return shards > 0
			}})
	}
}
