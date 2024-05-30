using System.Text.Json.Serialization;

namespace SirusDbScrapper.Api.DTOs;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

public class ItemDetails
{
	[JsonPropertyName("item")] public Item Item { get; set; }

	[JsonPropertyName("tooltip")] public Tooltip Tooltip { get; set; }

	[JsonPropertyName("randomEnchants")] public List<object> RandomEnchants { get; set; }

	[JsonPropertyName("tabs")] public List<Tab> Tabs { get; set; }

	[JsonPropertyName("transforms")] public List<object> Transforms { get; set; }

	[JsonPropertyName("auctionhouse")] public object Auctionhouse { get; set; }
}

public class Item
{
	[JsonPropertyName("bag_family")] public object BagFamily { get; set; }

	[JsonPropertyName("bonding")] public int Bonding { get; set; }

	[JsonPropertyName("quality")] public int Quality { get; set; }

	[JsonPropertyName("class")] public int Class { get; set; }

	[JsonPropertyName("subclass")] public int Subclass { get; set; }

	[JsonPropertyName("subSubClass")] public int SubSubClass { get; set; }

	[JsonPropertyName("color")] public string Color { get; set; }

	[JsonPropertyName("disenchant_id")] public int DisenchantId { get; set; }

	[JsonPropertyName("entry")] public int Entry { get; set; }

	[JsonPropertyName("flags")] public int Flags { get; set; }

	[JsonPropertyName("flags_custom")] public int FlagsCustom { get; set; }

	[JsonPropertyName("flags_extra")] public int FlagsExtra { get; set; }

	[JsonPropertyName("gem_enchantment_id")]
	public int GemEnchantmentId { get; set; }

	[JsonPropertyName("holiday_event")] public object HolidayEvent { get; set; }

	[JsonPropertyName("inventory_type")] public int InventoryType { get; set; }

	[JsonPropertyName("item_level")] public int ItemLevel { get; set; }

	[JsonPropertyName("max_money_moot")] public int MaxMoneyMoot { get; set; }

	[JsonPropertyName("min_money_loot")] public int MinMoneyLoot { get; set; }

	[JsonPropertyName("name")] public string Name { get; set; }

	[JsonPropertyName("icon")] public string Icon { get; set; }

	[JsonPropertyName("repair_price")] public int RepairPrice { get; set; }

	[JsonPropertyName("requiredRace")] public int RequiredRace { get; set; }

	[JsonPropertyName("required_disenchant_skill")]
	public int RequiredDisenchantSkill { get; set; }

	[JsonPropertyName("required_skill")] public int RequiredSkill { get; set; }

	[JsonPropertyName("required_skill_rank")]
	public int RequiredSkillRank { get; set; }

	[JsonPropertyName("stackable")] public int Stackable { get; set; }

	[JsonPropertyName("spellcharges_1")] public int Spellcharges1 { get; set; }

	[JsonPropertyName("spellcharges_2")] public int Spellcharges2 { get; set; }

	[JsonPropertyName("spellcharges_3")] public int Spellcharges3 { get; set; }

	[JsonPropertyName("spellcharges_4")] public int Spellcharges4 { get; set; }

	[JsonPropertyName("spellcharges_5")] public int Spellcharges5 { get; set; }

	[JsonPropertyName("spellid_1")] public int Spellid1 { get; set; }

	[JsonPropertyName("spellid_2")] public int Spellid2 { get; set; }

	[JsonPropertyName("spellid_3")] public int Spellid3 { get; set; }

	[JsonPropertyName("spellid_4")] public int Spellid4 { get; set; }

	[JsonPropertyName("spellid_5")] public int Spellid5 { get; set; }

	[JsonPropertyName("spelltrigger_1")] public int Spelltrigger1 { get; set; }

	[JsonPropertyName("spelltrigger_2")] public int Spelltrigger2 { get; set; }

	[JsonPropertyName("spelltrigger_3")] public int Spelltrigger3 { get; set; }

	[JsonPropertyName("spelltrigger_4")] public int Spelltrigger4 { get; set; }

	[JsonPropertyName("spelltrigger_5")] public int Spelltrigger5 { get; set; }

	[JsonPropertyName("totem_category")] public object TotemCategory { get; set; }

	[JsonPropertyName("gem_description")] public object GemDescription { get; set; }

	[JsonPropertyName("is_heroic")] public bool IsHeroic { get; set; }

	[JsonPropertyName("cost_list")] public List<object> CostList { get; set; }

	[JsonPropertyName("req_rating")] public List<object> ReqRating { get; set; }
}

public class Item2
{
	[JsonPropertyName("entry")] public int Entry { get; set; }

	[JsonPropertyName("name")] public string Name { get; set; }

	[JsonPropertyName("subname")] public string Subname { get; set; }

	[JsonPropertyName("minlevel")] public int Minlevel { get; set; }

	[JsonPropertyName("maxlevel")] public int Maxlevel { get; set; }

	[JsonPropertyName("zones")] public List<object> Zones { get; set; }

	[JsonPropertyName("rank")] public int Rank { get; set; }

	[JsonPropertyName("type")] public object Type { get; set; }

	[JsonPropertyName("hasQuests")] public bool HasQuests { get; set; }

	[JsonPropertyName("reaction")] public Reaction Reaction { get; set; }

	[JsonPropertyName("realm_id")] public int RealmId { get; set; }

	[JsonPropertyName("percent")] public double Percent { get; set; }

	[JsonPropertyName("quality")] public int? Quality { get; set; }

	[JsonPropertyName("icon")] public string Icon { get; set; }

	[JsonPropertyName("slot")] public int? Slot { get; set; }

	[JsonPropertyName("level")] public int? Level { get; set; }

	[JsonPropertyName("reqlevel")] public object Reqlevel { get; set; }

	[JsonPropertyName("color")] public string Color { get; set; }

	[JsonPropertyName("stack")] public int? Stack { get; set; }

	[JsonPropertyName("flags_extra")] public int? FlagsExtra { get; set; }

	[JsonPropertyName("required_race")] public int? RequiredRace { get; set; }

	[JsonPropertyName("required_class")] public int? RequiredClass { get; set; }

	[JsonPropertyName("source")] public Source Source { get; set; }

	[JsonPropertyName("is_heroic")] public bool? IsHeroic { get; set; }

	[JsonPropertyName("group")] public int? Group { get; set; }

	[JsonPropertyName("quest")] public int? Quest { get; set; }

	[JsonPropertyName("count")] public int? Count { get; set; }

	[JsonPropertyName("mode")] public string Mode { get; set; }

	[JsonPropertyName("pctstack")] public string Pctstack { get; set; }
}

public class MoreType
{
	[JsonPropertyName("entry")] public int Entry { get; set; }

	[JsonPropertyName("name")] public string Name { get; set; }

	[JsonPropertyName("subname")] public object Subname { get; set; }

	[JsonPropertyName("minlevel")] public object Minlevel { get; set; }

	[JsonPropertyName("maxlevel")] public object Maxlevel { get; set; }

	[JsonPropertyName("zones")] public List<Zone> Zones { get; set; }

	[JsonPropertyName("rank")] public string Rank { get; set; }

	[JsonPropertyName("reaction")] public Reaction Reaction { get; set; }

	[JsonPropertyName("realm_id")] public int RealmId { get; set; }

	[JsonPropertyName("quality")] public int? Quality { get; set; }

	[JsonPropertyName("icon")] public string Icon { get; set; }

	[JsonPropertyName("color")] public string Color { get; set; }
}

public class Price
{
	[JsonPropertyName("copper")] public int Copper { get; set; }

	[JsonPropertyName("silver")] public int Silver { get; set; }

	[JsonPropertyName("gold")] public int Gold { get; set; }
}

public class Reaction
{
	[JsonPropertyName("alliance")] public int Alliance { get; set; }

	[JsonPropertyName("horde")] public int Horde { get; set; }

	[JsonPropertyName("renegade")] public int Renegade { get; set; }
}

public class Socket
{
	[JsonPropertyName("slot")] public int Slot { get; set; }

	[JsonPropertyName("color")] public int Color { get; set; }

	[JsonPropertyName("type")] public string Type { get; set; }

	[JsonPropertyName("gem")] public object Gem { get; set; }
}

public class SocketBonusEnch
{
	[JsonPropertyName("id")] public int Id { get; set; }

	[JsonPropertyName("name")] public string Name { get; set; }
}

public class Source
{
	[JsonPropertyName("type")] public string Type { get; set; }

	[JsonPropertyName("moreType")] public MoreType MoreType { get; set; }

	[JsonPropertyName("sources")] public List<int> Sources { get; set; }
}

public class Tab
{
	[JsonPropertyName("items")] public List<Item2> Items { get; set; }

	[JsonPropertyName("id")] public string Id { get; set; }

	[JsonPropertyName("type")] public string Type { get; set; }

	[JsonPropertyName("extra")] public List<string> Extra { get; set; }

	[JsonPropertyName("hidden")] public List<string> Hidden { get; set; }

	[JsonPropertyName("visible")] public List<object> Visible { get; set; }
}

public class Tooltip
{
	[JsonPropertyName("entry")] public int Entry { get; set; }

	[JsonPropertyName("name")] public string Name { get; set; }

	[JsonPropertyName("realm_id")] public int RealmId { get; set; }

	[JsonPropertyName("icon")] public string Icon { get; set; }

	[JsonPropertyName("class")] public int Class { get; set; }

	[JsonPropertyName("subclass")] public int Subclass { get; set; }

	[JsonPropertyName("item_level")] public int ItemLevel { get; set; }

	[JsonPropertyName("required_level")] public int RequiredLevel { get; set; }

	[JsonPropertyName("required_class")] public int RequiredClass { get; set; }

	[JsonPropertyName("required_race")] public int RequiredRace { get; set; }

	[JsonPropertyName("quality")] public int Quality { get; set; }

	[JsonPropertyName("gem_enchantment_id")]
	public int GemEnchantmentId { get; set; }

	[JsonPropertyName("gem_description")] public object GemDescription { get; set; }

	[JsonPropertyName("bonding")] public int Bonding { get; set; }

	[JsonPropertyName("description")] public object Description { get; set; }

	[JsonPropertyName("is_heroic")] public bool IsHeroic { get; set; }

	[JsonPropertyName("is_unique")] public bool IsUnique { get; set; }

	[JsonPropertyName("is_conjured")] public bool IsConjured { get; set; }

	[JsonPropertyName("is_account_bound")] public bool IsAccountBound { get; set; }

	[JsonPropertyName("is_openable")] public bool IsOpenable { get; set; }

	[JsonPropertyName("is_readable")] public bool IsReadable { get; set; }

	[JsonPropertyName("charges")] public int Charges { get; set; }

	[JsonPropertyName("inventory_type")] public int InventoryType { get; set; }

	[JsonPropertyName("max_count")] public int MaxCount { get; set; }

	[JsonPropertyName("slots")] public int Slots { get; set; }

	[JsonPropertyName("bag_family")] public int BagFamily { get; set; }

	[JsonPropertyName("bag_type")] public int BagType { get; set; }

	[JsonPropertyName("type")] public string Type { get; set; }

	[JsonPropertyName("armor")] public int Armor { get; set; }

	[JsonPropertyName("armor_damage_modifier")]
	public int ArmorDamageModifier { get; set; }

	[JsonPropertyName("block")] public int Block { get; set; }

	[JsonPropertyName("dmg_min1")] public int DmgMin1 { get; set; }

	[JsonPropertyName("dmg_max1")] public int DmgMax1 { get; set; }

	[JsonPropertyName("dmg_type1")] public int DmgType1 { get; set; }

	[JsonPropertyName("dmg_min2")] public int DmgMin2 { get; set; }

	[JsonPropertyName("dmg_max2")] public int DmgMax2 { get; set; }

	[JsonPropertyName("dmg_type2")] public int DmgType2 { get; set; }

	[JsonPropertyName("delay")] public int Delay { get; set; }

	[JsonPropertyName("dps")] public double Dps { get; set; }

	[JsonPropertyName("fap")] public int Fap { get; set; }

	[JsonPropertyName("stat_type1")] public int StatType1 { get; set; }

	[JsonPropertyName("stat_value1")] public int StatValue1 { get; set; }

	[JsonPropertyName("stat_type2")] public int StatType2 { get; set; }

	[JsonPropertyName("stat_value2")] public int StatValue2 { get; set; }

	[JsonPropertyName("stat_type3")] public int StatType3 { get; set; }

	[JsonPropertyName("stat_value3")] public int StatValue3 { get; set; }

	[JsonPropertyName("stat_type4")] public int StatType4 { get; set; }

	[JsonPropertyName("stat_value4")] public int StatValue4 { get; set; }

	[JsonPropertyName("stat_type5")] public int StatType5 { get; set; }

	[JsonPropertyName("stat_value5")] public int StatValue5 { get; set; }

	[JsonPropertyName("stat_type6")] public int StatType6 { get; set; }

	[JsonPropertyName("stat_value6")] public int StatValue6 { get; set; }

	[JsonPropertyName("stat_type7")] public int StatType7 { get; set; }

	[JsonPropertyName("stat_value7")] public int StatValue7 { get; set; }

	[JsonPropertyName("stat_type8")] public int StatType8 { get; set; }

	[JsonPropertyName("stat_value8")] public int StatValue8 { get; set; }

	[JsonPropertyName("stat_type9")] public int StatType9 { get; set; }

	[JsonPropertyName("stat_value9")] public int StatValue9 { get; set; }

	[JsonPropertyName("stat_type10")] public int StatType10 { get; set; }

	[JsonPropertyName("stat_value10")] public int StatValue10 { get; set; }

	[JsonPropertyName("holy_res")] public int HolyRes { get; set; }

	[JsonPropertyName("nature_res")] public int NatureRes { get; set; }

	[JsonPropertyName("fire_res")] public int FireRes { get; set; }

	[JsonPropertyName("frost_res")] public int FrostRes { get; set; }

	[JsonPropertyName("shadow_res")] public int ShadowRes { get; set; }

	[JsonPropertyName("arcane_res")] public int ArcaneRes { get; set; }

	[JsonPropertyName("randomPropertyStats")]
	public List<object> RandomPropertyStats { get; set; }

	[JsonPropertyName("randomEnchant")] public bool RandomEnchant { get; set; }

	[JsonPropertyName("enchantments")] public object Enchantments { get; set; }

	[JsonPropertyName("sockets")] public List<Socket> Sockets { get; set; }

	[JsonPropertyName("is_right_gem_colors")]
	public bool IsRightGemColors { get; set; }

	[JsonPropertyName("spell_triggers")] public List<object> SpellTriggers { get; set; }

	[JsonPropertyName("can_teach_spell")] public bool CanTeachSpell { get; set; }

	[JsonPropertyName("craft_spell")] public object CraftSpell { get; set; }

	[JsonPropertyName("socket_bonus_ench")]
	public SocketBonusEnch SocketBonusEnch { get; set; }

	[JsonPropertyName("required_reputation")]
	public object RequiredReputation { get; set; }

	[JsonPropertyName("required_skill")] public object RequiredSkill { get; set; }

	[JsonPropertyName("required_skill_rank")]
	public int RequiredSkillRank { get; set; }

	[JsonPropertyName("required_spell")] public object RequiredSpell { get; set; }

	[JsonPropertyName("spellcharges_1")] public int Spellcharges1 { get; set; }

	[JsonPropertyName("spellcharges_2")] public int Spellcharges2 { get; set; }

	[JsonPropertyName("spellcharges_3")] public int Spellcharges3 { get; set; }

	[JsonPropertyName("spellcharges_5")] public int Spellcharges5 { get; set; }

	[JsonPropertyName("spellid_1")] public int Spellid1 { get; set; }

	[JsonPropertyName("spellid_2")] public int Spellid2 { get; set; }

	[JsonPropertyName("spellid_3")] public int Spellid3 { get; set; }

	[JsonPropertyName("spellid_4")] public int Spellid4 { get; set; }

	[JsonPropertyName("spellid_5")] public int Spellid5 { get; set; }

	[JsonPropertyName("spelltrigger_1")] public int Spelltrigger1 { get; set; }

	[JsonPropertyName("spelltrigger_2")] public int Spelltrigger2 { get; set; }

	[JsonPropertyName("spelltrigger_3")] public int Spelltrigger3 { get; set; }

	[JsonPropertyName("spelltrigger_4")] public int Spelltrigger4 { get; set; }

	[JsonPropertyName("spelltrigger_5")] public int Spelltrigger5 { get; set; }

	[JsonPropertyName("locks")] public List<object> Locks { get; set; }

	[JsonPropertyName("stackable")] public int Stackable { get; set; }

	[JsonPropertyName("sell_price")] public int SellPrice { get; set; }

	[JsonPropertyName("price")] public Price Price { get; set; }

	[JsonPropertyName("itemset_data")] public object ItemsetData { get; set; }

	[JsonPropertyName("item_limit_category")]
	public int ItemLimitCategory { get; set; }

	[JsonPropertyName("durability")] public int Durability { get; set; }

	[JsonPropertyName("duration")] public object Duration { get; set; }

	[JsonPropertyName("realduration")] public bool Realduration { get; set; }

	[JsonPropertyName("holiday_event")] public object HolidayEvent { get; set; }

	[JsonPropertyName("start_quest")] public int StartQuest { get; set; }

	[JsonPropertyName("req_rating")] public List<object> ReqRating { get; set; }
}

public class Zone
{
	[JsonPropertyName("id")] public int Id { get; set; }

	[JsonPropertyName("name")] public string Name { get; set; }
}
