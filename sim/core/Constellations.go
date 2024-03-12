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
	}
}
