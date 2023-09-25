using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.GuildHouse;

public sealed class GuildHouse : SData.SData
{
    public int Unknown { get; set; }

    public int HousePrice { get; set; }

    public int ServicePrice { get; set; }

    public List<NpcInfo> NpcInfoList { get; set; } = new();

    public List<GuildHouseNpc> Npcs { get; set; } = new();

    /// <inheritdoc />
    public override void Read()
    {
        Unknown = _binaryReader.Read<int>();
        HousePrice = _binaryReader.Read<int>();
        ServicePrice = _binaryReader.Read<int>();

        for (int i = 0; i < 36; i++)
            NpcInfoList.Add(new NpcInfo(_binaryReader));

        for (int i = 0; i < 24; i++)
            Npcs.Add(new GuildHouseNpc(_binaryReader));
    }

    /// <inheritdoc />
    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Unknown.GetBytes());
        buffer.AddRange(HousePrice.GetBytes());
        buffer.AddRange(ServicePrice.GetBytes());
        buffer.AddRange(NpcInfoList.Take(36).GetBytes(false));
        buffer.AddRange(Npcs.Take(24).GetBytes(false));
        return buffer;
    }
}
