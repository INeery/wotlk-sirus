package core

import (
	"time"

	"github.com/wowsims/wotlk/sim/core/proto"
)

type APLValueAuraIsActive struct {
	defaultAPLValueImpl
	aura AuraReference
}

func (rot *APLRotation) newValueAuraIsActive(config *proto.APLValueAuraIsActive) APLValue {
	aura := rot.aplGetAura(config.SourceUnit, config.AuraId)
	if aura.Get() == nil {
		return nil
	}
	return &APLValueAuraIsActive{
		aura: aura,
	}
}
func (value *APLValueAuraIsActive) Type() proto.APLValueType {
	return proto.APLValueType_ValueTypeBool
}
func (value *APLValueAuraIsActive) GetBool(sim *Simulation) bool {
	return value.aura.Get().IsActive()
}

type APLValueAuraRemainingTime struct {
	defaultAPLValueImpl
	aura AuraReference
}

func (rot *APLRotation) newValueAuraRemainingTime(config *proto.APLValueAuraRemainingTime) APLValue {
	aura := rot.aplGetAura(config.SourceUnit, config.AuraId)
	if aura.Get() == nil {
		return nil
	}
	return &APLValueAuraRemainingTime{
		aura: aura,
	}
}
func (value *APLValueAuraRemainingTime) Type() proto.APLValueType {
	return proto.APLValueType_ValueTypeDuration
}
func (value *APLValueAuraRemainingTime) GetDuration(sim *Simulation) time.Duration {
	return value.aura.Get().RemainingDuration(sim)
}

type APLValueAuraNumStacks struct {
	defaultAPLValueImpl
	aura AuraReference
}

func (rot *APLRotation) newValueAuraNumStacks(config *proto.APLValueAuraNumStacks) APLValue {
	aura := rot.aplGetAura(config.SourceUnit, config.AuraId)
	if aura.Get() == nil {
		return nil
	}
	if aura.Get().MaxStacks == 0 {
		rot.validationWarning("%s is not a stackable aura", ProtoToActionID(config.AuraId))
		return nil
	}
	return &APLValueAuraNumStacks{
		aura: aura,
	}
}
func (value *APLValueAuraNumStacks) Type() proto.APLValueType {
	return proto.APLValueType_ValueTypeInt
}
func (value *APLValueAuraNumStacks) GetInt(sim *Simulation) int32 {
	return value.aura.Get().GetStacks()
}

type APLValueAuraInternalCooldown struct {
	defaultAPLValueImpl
	aura AuraReference
}

func (rot *APLRotation) newValueAuraInternalCooldown(config *proto.APLValueAuraInternalCooldown) APLValue {
	aura := rot.aplGetProcAura(config.SourceUnit, config.AuraId)
	if aura.Get() == nil {
		return nil
	}
	return &APLValueAuraInternalCooldown{
		aura: aura,
	}
}
func (value *APLValueAuraInternalCooldown) Type() proto.APLValueType {
	return proto.APLValueType_ValueTypeDuration
}
func (value *APLValueAuraInternalCooldown) GetDuration(sim *Simulation) time.Duration {
	return value.aura.Get().Icd.TimeToReady(sim)
}
