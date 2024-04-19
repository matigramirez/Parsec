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

    public byte[] UnknownArray { get; set; } = Array.Empty<byte>();

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
        ReadUnknownArray(binaryReader);
        Quests = binaryReader.ReadList<Quest>().ToList();
    }

    private void ReadUnknownArray(SBinaryReader binaryReader)
    {
        var unknownBuffer = new List<byte>();

        for (var i = 0; i < 256; i++)
        {
            for (var j = 0; j < 256; j++)
            {
                var value1 = binaryReader.ReadInt32();
                var array1 = binaryReader.ReadBytes(2 * value1);

                unknownBuffer.AddRange(BitConverter.GetBytes(value1));
                unknownBuffer.AddRange(array1);

                var value2 = binaryReader.ReadInt32();
                var array2 = binaryReader.ReadBytes(2 * value2);

                unknownBuffer.AddRange(BitConverter.GetBytes(value2));
                unknownBuffer.AddRange(array2);
            }
        }

        UnknownArray = unknownBuffer.ToArray();
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
        binaryWriter.Write(UnknownArray);
        binaryWriter.Write(Quests.ToSerializable());
    }
}
