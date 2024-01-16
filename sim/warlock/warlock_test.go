package warlock

import (
	"testing"

	_ "github.com/wowsims/wotlk/sim/common"
	"github.com/wowsims/wotlk/sim/core"
	"github.com/wowsims/wotlk/sim/core/proto"
)

func init() {
	RegisterWarlock()
}

func TestAffliction(t *testing.T) {
	core.RunTestSuite(t, t.Name(), core.FullCharacterTestSuiteGenerator(core.CharacterSuiteConfig{
		Class: proto.Class_ClassWarlock,
		Race:  proto.Race_RaceOrc,

		GearSet:     core.GetGearSet("../../ui/warlock/gear_sets", "p4_affliction"),
		Talents:     AfflictionTalents,
		Glyphs:      AfflictionGlyphs,
		Consumes:    FullConsumes,
		SpecOptions: core.SpecOptionsCombo{Label: "Affliction Warlock", SpecOptions: DefaultAfflictionWarlock},
		Rotation:    core.GetAplRotation("../../ui/warlock/apls", "affliction"),

		ItemFilter: ItemFilter,
	}))
}

func TestDemonology(t *testing.T) {
	core.RunTestSuite(t, t.Name(), core.FullCharacterTestSuiteGenerator(core.CharacterSuiteConfig{
		Class: proto.Class_ClassWarlock,
		Race:  proto.Race_RaceOrc,

		GearSet:     core.GetGearSet("../../ui/warlock/gear_sets", "p4_demo"),
		Talents:     DemonologyTalents,
		Glyphs:      DemonologyGlyphs,
		Consumes:    FullConsumes,
		SpecOptions: core.SpecOptionsCombo{Label: "Demonology Warlock", SpecOptions: DefaultDemonologyWarlock},
		Rotation:    core.GetAplRotation("../../ui/warlock/apls", "demo"),

		ItemFilter: ItemFilter,
	}))
}

func TestDestruction(t *testing.T) {
	core.RunTestSuite(t, t.Name(), core.FullCharacterTestSuiteGenerator(core.CharacterSuiteConfig{
		Class: proto.Class_ClassWarlock,
		Race:  proto.Race_RaceOrc,

		GearSet:     core.GetGearSet("../../ui/warlock/gear_sets", "p4_destro"),
		Talents:     DestructionTalents,
		Glyphs:      DestructionGlyphs,
		Consumes:    FullConsumes,
		SpecOptions: core.SpecOptionsCombo{Label: "Destruction Warlock", SpecOptions: DefaultDestroWarlock},
		Rotation:    core.GetAplRotation("../../ui/warlock/apls", "destro"),
		ItemFilter:  ItemFilter,
	}))
}

var ItemFilter = core.ItemFilter{
	WeaponTypes: []proto.WeaponType{
		proto.WeaponType_WeaponTypeSword,
		proto.WeaponType_WeaponTypeDagger,
	},
	HandTypes: []proto.HandType{
		proto.HandType_HandTypeOffHand,
	},
	ArmorType: proto.ArmorType_ArmorTypeCloth,
	RangedWeaponTypes: []proto.RangedWeaponType{
		proto.RangedWeaponType_RangedWeaponTypeWand,
	},
}

var AfflictionTalents = "2350002030023510253500331151--550000051"
var DemonologyTalents = "-203203301035012530135201351-550000052"
var DestructionTalents = "-03310030003-05203205210331051335230351"
var AfflictionGlyphs = &proto.Glyphs{
	Major1: int32(proto.WarlockMajorGlyph_GlyphOfQuickDecay),
	Major2: int32(proto.WarlockMajorGlyph_GlyphOfLifeTap),
	Major3: int32(proto.WarlockMajorGlyph_GlyphOfHaunt),
}
var DemonologyGlyphs = &proto.Glyphs{
	Major1: int32(proto.WarlockMajorGlyph_GlyphOfQuickDecay),
	Major2: int32(proto.WarlockMajorGlyph_GlyphOfLifeTap),
	Major3: int32(proto.WarlockMajorGlyph_GlyphOfFelguard),
}
var DestructionGlyphs = &proto.Glyphs{
	Major1: int32(proto.WarlockMajorGlyph_GlyphOfConflagrate),
	Major2: int32(proto.WarlockMajorGlyph_GlyphOfLifeTap),
	Major3: int32(proto.WarlockMajorGlyph_GlyphOfIncinerate),
}

var defaultDestroRotation = &proto.Warlock_Rotation{
	Type:         proto.Warlock_Rotation_Destruction,
	PrimarySpell: proto.Warlock_Rotation_Incinerate,
	SecondaryDot: proto.Warlock_Rotation_Immolate,
	SpecSpell:    proto.Warlock_Rotation_ChaosBolt,
	Curse:        proto.Warlock_Rotation_Doom,
	Corruption:   false,
	DetonateSeed: true,
}

var defaultDestroOptions = &proto.Warlock_Options{
	Armor:       proto.Warlock_Options_FelArmor,
	Summon:      proto.Warlock_Options_Imp,
	WeaponImbue: proto.Warlock_Options_GrandFirestone,
}

var DefaultDestroWarlock = &proto.Player_Warlock{
	Warlock: &proto.Warlock{
		Options:  defaultDestroOptions,
		Rotation: defaultDestroRotation,
	},
}

// ---------------------------------------
var DefaultAfflictionWarlock = &proto.Player_Warlock{
	Warlock: &proto.Warlock{
		Options:  defaultAfflictionOptions,
		Rotation: defaultAfflictionRotation,
	},
}

var defaultAfflictionOptions = &proto.Warlock_Options{
	Armor:       proto.Warlock_Options_FelArmor,
	Summon:      proto.Warlock_Options_Felhunter,
	WeaponImbue: proto.Warlock_Options_GrandSpellstone,
}

var defaultAfflictionRotation = &proto.Warlock_Rotation{
	Type:         proto.Warlock_Rotation_Affliction,
	PrimarySpell: proto.Warlock_Rotation_ShadowBolt,
	SecondaryDot: proto.Warlock_Rotation_UnstableAffliction,
	SpecSpell:    proto.Warlock_Rotation_Haunt,
	Curse:        proto.Warlock_Rotation_Agony,
	Corruption:   true,
	DetonateSeed: true,
}

var afflictionItemSwapRotation = &proto.Warlock_Rotation{
	Type:             proto.Warlock_Rotation_Affliction,
	PrimarySpell:     proto.Warlock_Rotation_ShadowBolt,
	SecondaryDot:     proto.Warlock_Rotation_UnstableAffliction,
	SpecSpell:        proto.Warlock_Rotation_Haunt,
	Curse:            proto.Warlock_Rotation_Agony,
	Corruption:       true,
	DetonateSeed:     true,
	EnableWeaponSwap: true,
	WeaponSwap: &proto.ItemSwap{
		MhItem: &proto.ItemSpec{
			Id:      45457,
			Enchant: 3790,
			Gems:    []int32{40013, 40013},
		},
	},
}

// ---------------------------------------
var DefaultDemonologyWarlock = &proto.Player_Warlock{
	Warlock: &proto.Warlock{
		Options:  defaultDemonologyOptions,
		Rotation: defaultDemonologyRotation,
	},
}

var defaultDemonologyOptions = &proto.Warlock_Options{
	Armor:       proto.Warlock_Options_FelArmor,
	Summon:      proto.Warlock_Options_Felguard,
	WeaponImbue: proto.Warlock_Options_GrandSpellstone,
}

var defaultDemonologyRotation = &proto.Warlock_Rotation{
	Type:         proto.Warlock_Rotation_Demonology,
	PrimarySpell: proto.Warlock_Rotation_ShadowBolt,
	SecondaryDot: proto.Warlock_Rotation_Immolate,
	Curse:        proto.Warlock_Rotation_Doom,
	Corruption:   true,
	DetonateSeed: true,
}

// ---------------------------------------------------------

var FullConsumes = &proto.Consumes{
	Flask:         proto.Flask_FlaskOfTheFrostWyrm,
	DefaultPotion: proto.Potions_PotionOfWildMagic,
	PrepopPotion:  proto.Potions_PotionOfWildMagic,
	Food:          proto.Food_FoodFishFeast,
}
