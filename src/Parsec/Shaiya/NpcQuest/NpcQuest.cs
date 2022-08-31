using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.NpcQuest;

public class NpcQuest : SData.SData, IJsonReadable
{
    public List<Merchant> Merchants { get; } = new();
    public List<GateKeeper> Gatekeepers { get; } = new();
    public List<StandardNpc> Blacksmiths { get; } = new();
    public List<StandardNpc> PvpManagers { get; } = new();
    public List<StandardNpc> GamblingHouses { get; } = new();
    public List<StandardNpc> Warehouses { get; } = new();
    public List<StandardNpc> NormalNpcs { get; } = new();
    public List<StandardNpc> Guards { get; } = new();
    public List<StandardNpc> Animals { get; } = new();
    public List<StandardNpc> Apprentices { get; } = new();
    public List<StandardNpc> GuildMasters { get; } = new();
    public List<StandardNpc> DeadNpcs { get; } = new();
    public List<StandardNpc> CombatCommanders { get; } = new();
    public byte[] UnknownArray { get; set; }
    public List<Quest> Quests { get; } = new();

    public override void Read(params object[] options)
    {
        Episode = Episode.EP5;

        if (options.Length > 0)
        {
            object format = options[0];
            Episode = (Episode)format;
        }

        ReadMerchants();
        ReadGatekeepers();
        ReadStandardNpcs(Blacksmiths);
        ReadStandardNpcs(PvpManagers);
        ReadStandardNpcs(GamblingHouses);
        ReadStandardNpcs(Warehouses);
        ReadStandardNpcs(NormalNpcs);
        ReadStandardNpcs(Guards);
        ReadStandardNpcs(Animals);
        ReadStandardNpcs(Apprentices);
        ReadStandardNpcs(GuildMasters);
        ReadStandardNpcs(DeadNpcs);
        ReadStandardNpcs(CombatCommanders);
        ReadUnknownArray();
        ReadQuests();
    }

    private void ReadMerchants()
    {
        int merchantCount = _binaryReader.Read<int>();

        for (int i = 0; i < merchantCount; i++)
        {
            var merchant = new Merchant(_binaryReader, Episode);
            Merchants.Add(merchant);
        }
    }

    private void ReadGatekeepers()
    {
        int gateKeeperCount = _binaryReader.Read<int>();

        for (int i = 0; i < gateKeeperCount; i++)
        {
            var gatekeeper = new GateKeeper(_binaryReader, Episode);
            Gatekeepers.Add(gatekeeper);
        }
    }

    private void ReadStandardNpcs(List<StandardNpc> npcList)
    {
        int count = _binaryReader.Read<int>();

        for (int i = 0; i < count; i++)
        {
            var npc = new StandardNpc(_binaryReader, Episode);
            npcList.Add(npc);
        }
    }

    private void ReadUnknownArray()
    {
        var unknownBuffer = new List<byte>();

        // 256x256 matrix
        for (int i = 0; i < 256; i++)
        {
            for (int j = 0; j < 256; j++)
            {
                int value1 = _binaryReader.Read<int>();
                byte[] array1 = _binaryReader.ReadBytes(2 * value1);

                unknownBuffer.AddRange(value1.GetBytes());
                unknownBuffer.AddRange(array1);

                int value2 = _binaryReader.Read<int>();
                byte[] array2 = _binaryReader.ReadBytes(2 * value2);

                unknownBuffer.AddRange(value2.GetBytes());
                unknownBuffer.AddRange(array2);
            }
        }

        UnknownArray = unknownBuffer.ToArray();
    }

    private void ReadQuests()
    {
        int questCount = _binaryReader.Read<int>();

        for (int i = 0; i < questCount; i++)
        {
            var quest = new Quest(_binaryReader, Episode);
            Quests.Add(quest);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        if (episode == Episode.Unknown)
            episode = Episode;

        var buffer = new List<byte>();
        buffer.AddRange(Merchants.GetBytes());
        buffer.AddRange(Gatekeepers.GetBytes());
        buffer.AddRange(Blacksmiths.GetBytes());
        buffer.AddRange(PvpManagers.GetBytes());
        buffer.AddRange(GamblingHouses.GetBytes());
        buffer.AddRange(Warehouses.GetBytes());
        buffer.AddRange(NormalNpcs.GetBytes());
        buffer.AddRange(Guards.GetBytes());
        buffer.AddRange(Animals.GetBytes());
        buffer.AddRange(Apprentices.GetBytes());
        buffer.AddRange(GuildMasters.GetBytes());
        buffer.AddRange(DeadNpcs.GetBytes());
        buffer.AddRange(CombatCommanders.GetBytes());
        buffer.AddRange(UnknownArray);
        buffer.AddRange(Quests.GetBytes(true, episode));
        return buffer;
    }
}
