using Parsec.Attributes;
using Parsec.Common;

namespace Parsec.Shaiya.GuildHouse;

public class GuildHouse : SData.SData, IJsonReadable
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
