package core

func applyVipLevelEffects(agent Agent) {
	character := agent.GetCharacter()

	dmgMultiplier := 1 + 0.01*float64(character.VipLevel)
	character.PseudoStats.DamageDealtMultiplier *= dmgMultiplier
}
