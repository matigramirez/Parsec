using Parsec.Serialization;

namespace Parsec.Shaiya.NpcQuest;

public class NpcQuestTrans : SData.SData
{
    public List<NpcQuestTran> Merchants { get; set; } = new();

    public List<GateKeeperQuestTran> GateKeepers { get; set; } = new();

    public List<NpcQuestTran> Blacksmiths { get; set; } = new();

    public List<NpcQuestTran> PvpManagers { get; set; } = new();

    public List<NpcQuestTran> GamblingHouses { get; set; } = new();

    public List<NpcQuestTran> Warehouses { get; set; } = new();

    public List<NpcQuestTran> NormalNpcs { get; set; } = new();

    public List<NpcQuestTran> Guards { get; set; } = new();

    public List<NpcQuestTran> Animals { get; set; } = new();

    public List<NpcQuestTran> Apprentices { get; set; } = new();

    public List<NpcQuestTran> GuildMasters { get; set; } = new();

    public List<NpcQuestTran> DeadNpcs { get; set; } = new();

    public List<NpcQuestTran> CombatCommanders { get; set; } = new();

    public List<QuestTranslation> QuestTranslations { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
    }
}
