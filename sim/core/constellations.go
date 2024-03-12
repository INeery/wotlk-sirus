package core

import (
	"github.com/wowsims/wotlk/sim/core/proto"
	"github.com/wowsims/wotlk/sim/core/stats"
)

func applyConstellationEffects(agent Agent) {
	character := agent.GetCharacter()

	switch character.Constellation {
	case proto.Constellation_ConstellationUnknown:
		{
		}
	case proto.Constellation_Demon:
		character.stats[stats.MeleeCrit] += CritRatingPerCritChance * 2
		character.stats[stats.SpellHaste] += HasteRatingPerHastePercent * 2

		//character.PseudoStats.multi

		//фрагмент души
		//TODO а это множитель или аддитивно?
		character.PseudoStats.DamageDealtMultiplier *= 1.02

		//путь возвышения
		//TODO а это множитель или аддитивно?
		//TODO заменить на реализацию с бафом, пока банальный буст урона
		character.PseudoStats.DamageDealtMultiplier *= 1.04
	}
}
