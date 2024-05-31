using Google.Protobuf.Collections;
using Mapster;
using SirusDbScrapper.Api.DTOs;
using SirusDbScrapper.UIDatabase;

namespace SirusDbScrapper.Mapping;

public class MapsterConfig
{
	public MapsterConfig()
	{
		TypeAdapterConfig<Tooltip, RepeatedField<double>>.NewConfig()
			.MapToTargetWith((tooltip, proto) => ConvertTooltipToStats(tooltip, proto));
	}

	private static RepeatedField<double> ConvertTooltipToStats(Tooltip tooltip, RepeatedField<double> protoStats)
	{
		protoStats[(int)Stat.Armor] = tooltip.Armor;
		protoStats[(int)Stat.Block] = tooltip.Block;
		protoStats[(int)Stat.ArcaneResistance] = tooltip.ArcaneRes;
		protoStats[(int)Stat.FireResistance] = tooltip.FireRes;
		protoStats[(int)Stat.FrostResistance] = tooltip.FrostRes;
		protoStats[(int)Stat.NatureResistance] = tooltip.NatureRes;
		protoStats[(int)Stat.ShadowResistance] = tooltip.ShadowRes;

		TrySetProtoStats(tooltip.StatType1, tooltip.StatValue1, protoStats);
		TrySetProtoStats(tooltip.StatType2, tooltip.StatValue2, protoStats);
		TrySetProtoStats(tooltip.StatType3, tooltip.StatValue3, protoStats);
		TrySetProtoStats(tooltip.StatType4, tooltip.StatValue4, protoStats);
		TrySetProtoStats(tooltip.StatType5, tooltip.StatValue5, protoStats);
		TrySetProtoStats(tooltip.StatType6, tooltip.StatValue6, protoStats);
		TrySetProtoStats(tooltip.StatType7, tooltip.StatValue7, protoStats);
		TrySetProtoStats(tooltip.StatType8, tooltip.StatValue8, protoStats);
		TrySetProtoStats(tooltip.StatType9, tooltip.StatValue9, protoStats);
		TrySetProtoStats(tooltip.StatType10, tooltip.StatValue10, protoStats);

		return protoStats;
	}

	private static int[] GetProtoStatIndex(int statType1)
	{
		return statType1 switch
		{
			(int)ItemStatType.Agility => [(int)Stat.Agility],
			(int)ItemStatType.AttackPower => [(int)Stat.AttackPower],
			(int)ItemStatType.CritRating => [(int)Stat.MeleeCrit, (int)Stat.SpellCrit],
			(int)ItemStatType.Intellect => [(int)Stat.Intellect],
			(int)ItemStatType.HasteRating => [(int)Stat.MeleeHaste, (int)Stat.SpellHaste],
			(int)ItemStatType.Stamina => [(int)Stat.Stamina],
			(int)ItemStatType.ArmorPenetration => [(int)Stat.ArmorPenetration],
			(int)ItemStatType.HitRating => [(int)Stat.MeleeHit, (int)Stat.SpellHit],
			(int)ItemStatType.Expertise => [(int)Stat.Expertise],
			(int)ItemStatType.SpellPower => [(int)Stat.SpellPower],
			(int)ItemStatType.Strength => [(int)Stat.Strength],
			(int)ItemStatType.Resilience => [(int)Stat.Resilience],
			(int)ItemStatType.Defense => [(int)Stat.Defense],
			(int)ItemStatType.Dodge => [(int)Stat.Dodge],
			(int)ItemStatType.Parry => [(int)Stat.Parry],
			(int)ItemStatType.BlockValue => [(int)Stat.BlockValue],

			_ => throw new ArgumentOutOfRangeException(nameof(statType1), statType1, null)
		};
	}

	private static void TrySetProtoStats(int sirusStatType, int statValue, RepeatedField<double> protoStats)
	{
		if (sirusStatType is 0)
			return;

		var statIndexes = GetProtoStatIndex(sirusStatType);
		foreach (var statIndex in statIndexes)
		{
			protoStats[statIndex] = statValue;
		}
	}
}

public enum ItemStatType
{
	Agility = 3,
	AttackPower = 38,
	CritRating = 32,
	Intellect = 5,
	HasteRating = 36,
	Stamina = 7,
	ArmorPenetration = 44,
	HitRating = 31,
	Expertise = 37,
	SpellPower = 45,
	Strength = 4,
	Resilience = 35,
	Defense = 12,
	Dodge = 13,
	Parry = 14,
	BlockValue = 15,
}

// public enum Stat {
//     [pbr::OriginalName("StatStrength")] Strength = 0,
//     [pbr::OriginalName("StatAgility")] Agility = 1,
//     [pbr::OriginalName("StatStamina")] Stamina = 2,
//     [pbr::OriginalName("StatIntellect")] Intellect = 3,
//     [pbr::OriginalName("StatSpirit")] Spirit = 4,
//     [pbr::OriginalName("StatSpellPower")] SpellPower = 5,
//     [pbr::OriginalName("StatMP5")] Mp5 = 6,
//     [pbr::OriginalName("StatSpellHit")] SpellHit = 7,
//     [pbr::OriginalName("StatSpellCrit")] SpellCrit = 8,
//     [pbr::OriginalName("StatSpellHaste")] SpellHaste = 9,
//     [pbr::OriginalName("StatSpellPenetration")] SpellPenetration = 10,
//     [pbr::OriginalName("StatAttackPower")] AttackPower = 11,
//     [pbr::OriginalName("StatMeleeHit")] MeleeHit = 12,
//     [pbr::OriginalName("StatMeleeCrit")] MeleeCrit = 13,
//     [pbr::OriginalName("StatMeleeHaste")] MeleeHaste = 14,
//     [pbr::OriginalName("StatArmorPenetration")] ArmorPenetration = 15,
//     [pbr::OriginalName("StatExpertise")] Expertise = 16,
//     [pbr::OriginalName("StatMana")] Mana = 17,
//     [pbr::OriginalName("StatEnergy")] Energy = 18,
//     [pbr::OriginalName("StatRage")] Rage = 19,
//     [pbr::OriginalName("StatArmor")] Armor = 20,
//     [pbr::OriginalName("StatRangedAttackPower")] RangedAttackPower = 21,
//     [pbr::OriginalName("StatDefense")] Defense = 22,
//     [pbr::OriginalName("StatBlock")] Block = 23,
//     [pbr::OriginalName("StatBlockValue")] BlockValue = 24,
//     [pbr::OriginalName("StatDodge")] Dodge = 25,
//     [pbr::OriginalName("StatParry")] Parry = 26,
//     [pbr::OriginalName("StatResilience")] Resilience = 27,
//     [pbr::OriginalName("StatHealth")] Health = 28,
//     [pbr::OriginalName("StatArcaneResistance")] ArcaneResistance = 29,
//     [pbr::OriginalName("StatFireResistance")] FireResistance = 30,
//     [pbr::OriginalName("StatFrostResistance")] FrostResistance = 31,
//     [pbr::OriginalName("StatNatureResistance")] NatureResistance = 32,
//     [pbr::OriginalName("StatShadowResistance")] ShadowResistance = 33,
//     [pbr::OriginalName("StatBonusArmor")] BonusArmor = 34,
//   }
