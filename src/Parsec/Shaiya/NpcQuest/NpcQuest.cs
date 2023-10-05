using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.NpcQuest;

public class NpcQuest : SData.SData
{
    public List<Merchant> Merchants { get; set; } = new();

    public List<NpcQuestGateKeeper> Gatekeepers { get; set; } = new();

    public List<StandardNpc> Blacksmiths { get; set; } = new();

    public List<StandardNpc> PvpManagers { get; set; } = new();

    public List<StandardNpc> GamblingHouses { get; set; } = new();

    public List<StandardNpc> Warehouses { get; set; } = new();

    public List<StandardNpc> NormalNpcs { get; set; } = new();

    public List<StandardNpc> Guards { get; set; } = new();

    public List<StandardNpc> Animals { get; set; } = new();

    public List<StandardNpc> Apprentices { get; set; } = new();

    public List<StandardNpc> GuildMasters { get; set; } = new();

    public List<StandardNpc> DeadNpcs { get; set; } = new();

    public List<StandardNpc> CombatCommanders { get; set; } = new();

    public byte[]? UnknownArray { get; set; }

    public List<Quest> Quests { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        ReadMerchants(binaryReader);
        ReadGatekeepers(binaryReader);
        ReadStandardNpcs(binaryReader, Blacksmiths);
        ReadStandardNpcs(binaryReader, PvpManagers);
        ReadStandardNpcs(binaryReader, GamblingHouses);
        ReadStandardNpcs(binaryReader, Warehouses);
        ReadStandardNpcs(binaryReader, NormalNpcs);
        ReadStandardNpcs(binaryReader, Guards);
        ReadStandardNpcs(binaryReader, Animals);
        ReadStandardNpcs(binaryReader, Apprentices);
        ReadStandardNpcs(binaryReader, GuildMasters);
        ReadStandardNpcs(binaryReader, DeadNpcs);
        ReadStandardNpcs(binaryReader, CombatCommanders);
        ReadUnknownArray(binaryReader);
        ReadQuests(binaryReader);
    }

    private void ReadMerchants(SBinaryReader binaryReader)
    {
        var merchantCount = binaryReader.ReadInt32();
        for (var i = 0; i < merchantCount; i++)
        {
            var merchant = binaryReader.Read<Merchant>();
            Merchants.Add(merchant);
        }
    }

    private void ReadGatekeepers(SBinaryReader binaryReader)
    {
        var gateKeeperCount = binaryReader.ReadInt32();
        for (var i = 0; i < gateKeeperCount; i++)
        {
            var gateKeeper = binaryReader.Read<NpcQuestGateKeeper>();
            Gatekeepers.Add(gateKeeper);
        }
    }

    private void ReadStandardNpcs(SBinaryReader binaryReader, ICollection<StandardNpc> npcList)
    {
        var npcCount = binaryReader.ReadInt32();
        for (var i = 0; i < npcCount; i++)
        {
            var standardNpc = binaryReader.Read<StandardNpc>();
            npcList.Add(standardNpc);
        }
    }

    private void ReadUnknownArray(SBinaryReader binaryReader)
    {
        var unknownBuffer = new List<byte>();

        // 256x256 matrix
        for (int i = 0; i < 256; i++)
        {
            for (int j = 0; j < 256; j++)
            {
                int value1 = binaryReader.ReadInt32();
                byte[] array1 = binaryReader.ReadBytes(2 * value1);

                unknownBuffer.AddRange(BitConverter.GetBytes(value1));
                unknownBuffer.AddRange(array1);

                int value2 = binaryReader.ReadInt32();
                byte[] array2 = binaryReader.ReadBytes(2 * value2);

                unknownBuffer.AddRange(BitConverter.GetBytes(value2));
                unknownBuffer.AddRange(array2);
            }
        }

        UnknownArray = unknownBuffer.ToArray();
    }

    private void ReadQuests(SBinaryReader binaryReader)
    {
        var questCount = binaryReader.ReadInt32();
        for (var i = 0; i < questCount; i++)
        {
            var quest = binaryReader.Read<Quest>();
            Quests.Add(quest);
        }
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
