using Parsec.Serialization;

namespace Parsec.Shaiya.NpcQuest;

public class NpcQuestTrans : SData.SData
{
    public List<NpcQuestStandardNpcTranslation> Merchants { get; set; } = new();

    public List<NpcQuestGatekeeperTranslation> GateKeepers { get; set; } = new();

    public List<NpcQuestStandardNpcTranslation> Blacksmiths { get; set; } = new();

    public List<NpcQuestStandardNpcTranslation> PvpManagers { get; set; } = new();

    public List<NpcQuestStandardNpcTranslation> GamblingHouses { get; set; } = new();

    public List<NpcQuestStandardNpcTranslation> Warehouses { get; set; } = new();

    public List<NpcQuestStandardNpcTranslation> NormalNpcs { get; set; } = new();

    public List<NpcQuestStandardNpcTranslation> Guards { get; set; } = new();

    public List<NpcQuestStandardNpcTranslation> Animals { get; set; } = new();

    public List<NpcQuestStandardNpcTranslation> Apprentices { get; set; } = new();

    public List<NpcQuestStandardNpcTranslation> GuildMasters { get; set; } = new();

    public List<NpcQuestStandardNpcTranslation> DeadNpcs { get; set; } = new();

    public List<NpcQuestStandardNpcTranslation> CombatCommanders { get; set; } = new();

    public List<NpcQuestQuestTranslation> QuestTranslations { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
    }
}
