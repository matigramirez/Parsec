using Parsec.Attributes;

namespace Parsec.Shaiya.GuildHouse;

public sealed class GuildHouse : SData.SData
{
    [ShaiyaProperty]
    public int Unknown { get; set; }

    [ShaiyaProperty]
    public int HousePrice { get; set; }

    [ShaiyaProperty]
    public int ServicePrice { get; set; }

    [ShaiyaProperty]
    [FixedLengthList(typeof(NpcInfo), 36)]
    public List<NpcInfo> NpcInfoList { get; set; } = new();

    [ShaiyaProperty]
    [FixedLengthList(typeof(int), 24)]
    public List<int> NpcIds { get; set; } = new();
}
