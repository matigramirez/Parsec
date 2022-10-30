using Parsec.Attributes;

namespace Parsec.Shaiya.NpcQuest;

public class NpcQuestTrans : SData.SData
{
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> Merchants { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(GateKeeperQuestTran))]
    public List<GateKeeperQuestTran> GateKeepers { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> Blacksmiths { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> PvpManagers { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> GamblingHouses { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> Warehouses { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> NormalNpcs { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> Guards { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> Animals { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> Apprentices { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> GuildMasters { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> DeadNpcs { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NpcQuestTran))]
    public List<NpcQuestTran> CombatCommanders { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(QuestTranslation))]
    public List<QuestTranslation> QuestTranslations { get; set; } = new();
}
