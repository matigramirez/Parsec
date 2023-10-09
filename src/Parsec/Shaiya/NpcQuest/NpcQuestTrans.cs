using Parsec.Extensions;
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
        Merchants = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        GateKeepers = binaryReader.ReadList<NpcQuestGatekeeperTranslation>().ToList();
        Blacksmiths = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        PvpManagers = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        GamblingHouses = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        Warehouses = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        NormalNpcs = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        Guards = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        Animals = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        Apprentices = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        GuildMasters = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        DeadNpcs = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        CombatCommanders = binaryReader.ReadList<NpcQuestStandardNpcTranslation>().ToList();
        QuestTranslations = binaryReader.ReadList<NpcQuestQuestTranslation>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Merchants.ToSerializable());
        binaryWriter.Write(GateKeepers.ToSerializable());
        binaryWriter.Write(Blacksmiths.ToSerializable());
        binaryWriter.Write(PvpManagers.ToSerializable());
        binaryWriter.Write(GamblingHouses.ToSerializable());
        binaryWriter.Write(Warehouses.ToSerializable());
        binaryWriter.Write(NormalNpcs.ToSerializable());
        binaryWriter.Write(Guards.ToSerializable());
        binaryWriter.Write(Animals.ToSerializable());
        binaryWriter.Write(Apprentices.ToSerializable());
        binaryWriter.Write(GuildMasters.ToSerializable());
        binaryWriter.Write(DeadNpcs.ToSerializable());
        binaryWriter.Write(CombatCommanders.ToSerializable());
        binaryWriter.Write(QuestTranslations.ToSerializable());
    }
}
