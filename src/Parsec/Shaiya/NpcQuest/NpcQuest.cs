using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.NpcQuest;

public class NpcQuest : SData.SData
{
    public List<NpcQuestMerchant> Merchants { get; set; } = new();

    public List<NpcQuestGateKeeper> Gatekeepers { get; set; } = new();

    public List<NpcQuestStandardNpc> Blacksmiths { get; set; } = new();

    public List<NpcQuestStandardNpc> PvpManagers { get; set; } = new();

    public List<NpcQuestStandardNpc> GamblingHouses { get; set; } = new();

    public List<NpcQuestStandardNpc> Warehouses { get; set; } = new();

    public List<NpcQuestStandardNpc> NormalNpcs { get; set; } = new();

    public List<NpcQuestStandardNpc> Guards { get; set; } = new();

    public List<NpcQuestStandardNpc> Animals { get; set; } = new();

    public List<NpcQuestStandardNpc> Apprentices { get; set; } = new();

    public List<NpcQuestStandardNpc> GuildMasters { get; set; } = new();

    public List<NpcQuestStandardNpc> DeadNpcs { get; set; } = new();

    public List<NpcQuestStandardNpc> CombatCommanders { get; set; } = new();

    public List<QuestItemLink> QuestLinks { get; set; } = new();

    public List<Quest> Quests { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        Merchants = binaryReader.ReadList<NpcQuestMerchant>().ToList();
        Gatekeepers = binaryReader.ReadList<NpcQuestGateKeeper>().ToList();
        Blacksmiths = binaryReader.ReadList<NpcQuestStandardNpc>().ToList();
        PvpManagers = binaryReader.ReadList<NpcQuestStandardNpc>().ToList();
        GamblingHouses = binaryReader.ReadList<NpcQuestStandardNpc>().ToList();
        Warehouses = binaryReader.ReadList<NpcQuestStandardNpc>().ToList();
        NormalNpcs = binaryReader.ReadList<NpcQuestStandardNpc>().ToList();
        Guards = binaryReader.ReadList<NpcQuestStandardNpc>().ToList();
        Animals = binaryReader.ReadList<NpcQuestStandardNpc>().ToList();
        Apprentices = binaryReader.ReadList<NpcQuestStandardNpc>().ToList();
        GuildMasters = binaryReader.ReadList<NpcQuestStandardNpc>().ToList();
        DeadNpcs = binaryReader.ReadList<NpcQuestStandardNpc>().ToList();
        CombatCommanders = binaryReader.ReadList<NpcQuestStandardNpc>().ToList();

        for (var itemType = 0; itemType <= byte.MaxValue; itemType++)
        {
            for (var itemTypeId = 0; itemTypeId <= byte.MaxValue; itemTypeId++)
            {
                var questLink = binaryReader.Read<QuestItemLink>();
                QuestLinks.Add(questLink);
            }
        }

        Quests = binaryReader.ReadList<Quest>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Merchants.ToSerializable());
        binaryWriter.Write(Gatekeepers.ToSerializable());
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

        for (var itemType = 0; itemType <= byte.MaxValue; itemType++)
        {
            for (var itemTypeId = 0; itemTypeId <= byte.MaxValue; itemTypeId++)
            {
                var questLinksIndex = itemType * byte.MaxValue + itemTypeId;

                if (questLinksIndex >= QuestLinks.Count)
                {
                    binaryWriter.Write(new QuestItemLink());
                }
                else
                {
                    binaryWriter.Write(QuestLinks[questLinksIndex]);
                }
            }
        }

        binaryWriter.Write(Quests.ToSerializable());
    }
}
