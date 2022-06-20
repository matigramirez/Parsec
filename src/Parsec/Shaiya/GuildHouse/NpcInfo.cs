using Parsec.Attributes;

namespace Parsec.Shaiya.GuildHouse;

public class NpcInfo
{
    [ShaiyaProperty]
    public byte PriceRate { get; set; }

    [ShaiyaProperty]
    public byte NpcLvl { get; set; }

    [ShaiyaProperty]
    public byte RapiceMixPercentRate { get; set; }

    [ShaiyaProperty]
    public byte RapiceMixDecreRate { get; set; }

    [ShaiyaProperty]
    public byte MinRank { get; set; }

    [ShaiyaProperty]
    public short Icon { get; set; }

    [ShaiyaProperty]
    public short SysMsgId { get; set; }

    [ShaiyaProperty]
    public short UpPrice { get; set; }

    [ShaiyaProperty]
    public short ServicePrice { get; set; }

    [ShaiyaProperty]
    public byte NpcType { get; set; }

    [ShaiyaProperty]
    public byte Group { get; set; }
}
