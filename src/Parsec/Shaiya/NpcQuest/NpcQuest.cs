using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.NpcQuest;

public class NpcQuest : SData.SData
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
            Merchants.Add(new Merchant(_binaryReader, Episode));
    }

    private void ReadGatekeepers()
    {
        int gateKeeperCount = _binaryReader.Read<int>();
        for (int i = 0; i < gateKeeperCount; i++)
            Gatekeepers.Add(new GateKeeper(_binaryReader, Episode));
    }

    private void ReadStandardNpcs(ICollection<StandardNpc> npcList)
    {
        int npcCount = _binaryReader.Read<int>();
        for (int i = 0; i < npcCount; i++)
            npcList.Add(new StandardNpc(_binaryReader, Episode));
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
            Quests.Add(new Quest(_binaryReader, Episode));
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        if (episode == Episode.Unknown)
            episode = Episode;

        var buffer = new List<byte>();
        buffer.AddRange(Merchants.GetBytes(true, episode));
        buffer.AddRange(Gatekeepers.GetBytes(true, episode));
        buffer.AddRange(Blacksmiths.GetBytes(true, episode));
        buffer.AddRange(PvpManagers.GetBytes(true, episode));
        buffer.AddRange(GamblingHouses.GetBytes(true, episode));
        buffer.AddRange(Warehouses.GetBytes(true, episode));
        buffer.AddRange(NormalNpcs.GetBytes(true, episode));
        buffer.AddRange(Guards.GetBytes(true, episode));
        buffer.AddRange(Animals.GetBytes(true, episode));
        buffer.AddRange(Apprentices.GetBytes(true, episode));
        buffer.AddRange(GuildMasters.GetBytes(true, episode));
        buffer.AddRange(DeadNpcs.GetBytes(true, episode));
        buffer.AddRange(CombatCommanders.GetBytes(true, episode));
        buffer.AddRange(UnknownArray);
        buffer.AddRange(Quests.GetBytes(true, episode));
        return buffer;
    }
}
