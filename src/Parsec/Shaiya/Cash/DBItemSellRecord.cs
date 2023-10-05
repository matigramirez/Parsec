using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Cash;

public sealed class DBItemSellRecord : IBinarySDataRecord
{
    public long ProductCode { get; set; }

    public long Goods_Id { get; set; }

    public long Multi_BuyCost1 { get; set; }

    public long Multi_BuyCost2 { get; set; }

    public long ItemID1 { get; set; }

    public long ItemCount1 { get; set; }

    public long ItemID2 { get; set; }

    public long ItemCount2 { get; set; }

    public long ItemID3 { get; set; }

    public long ItemCount3 { get; set; }

    public long ItemID4 { get; set; }

    public long ItemCount4 { get; set; }

    public long ItemID5 { get; set; }

    public long ItemCount5 { get; set; }

    public long ItemID6 { get; set; }

    public long ItemCount6 { get; set; }

    public long ItemID7 { get; set; }

    public long ItemCount7 { get; set; }

    public long ItemID8 { get; set; }

    public long ItemCount8 { get; set; }

    public long ItemID9 { get; set; }

    public long ItemCount9 { get; set; }

    public long ItemID10 { get; set; }

    public long ItemCount10 { get; set; }

    public long ItemID11 { get; set; }

    public long ItemCount11 { get; set; }

    public long ItemID12 { get; set; }

    public long ItemCount12 { get; set; }

    public long ItemID13 { get; set; }

    public long ItemCount13 { get; set; }

    public long ItemID14 { get; set; }

    public long ItemCount14 { get; set; }

    public long ItemID15 { get; set; }

    public long ItemCount15 { get; set; }

    public long ItemID16 { get; set; }

    public long ItemCount16 { get; set; }

    public long ItemID17 { get; set; }

    public long ItemCount17 { get; set; }

    public long ItemID18 { get; set; }

    public long ItemCount18 { get; set; }

    public long ItemID19 { get; set; }

    public long ItemCount19 { get; set; }

    public long ItemID20 { get; set; }

    public long ItemCount20 { get; set; }

    public long ItemID21 { get; set; }

    public long ItemCount21 { get; set; }

    public long ItemID22 { get; set; }

    public long ItemCount22 { get; set; }

    public long ItemID23 { get; set; }

    public long ItemCount23 { get; set; }

    public long ItemID24 { get; set; }

    public long ItemCount24 { get; set; }

    public long Type { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        ProductCode = binaryReader.ReadInt64();
        Goods_Id = binaryReader.ReadInt64();
        Multi_BuyCost1 = binaryReader.ReadInt64();
        Multi_BuyCost2 = binaryReader.ReadInt64();
        ItemID1 = binaryReader.ReadInt64();
        ItemCount1 = binaryReader.ReadInt64();
        ItemID2 = binaryReader.ReadInt64();
        ItemCount2 = binaryReader.ReadInt64();
        ItemID3 = binaryReader.ReadInt64();
        ItemCount3 = binaryReader.ReadInt64();
        ItemID4 = binaryReader.ReadInt64();
        ItemCount4 = binaryReader.ReadInt64();
        ItemID5 = binaryReader.ReadInt64();
        ItemCount5 = binaryReader.ReadInt64();
        ItemID6 = binaryReader.ReadInt64();
        ItemCount6 = binaryReader.ReadInt64();
        ItemID7 = binaryReader.ReadInt64();
        ItemCount7 = binaryReader.ReadInt64();
        ItemID8 = binaryReader.ReadInt64();
        ItemCount8 = binaryReader.ReadInt64();
        ItemID9 = binaryReader.ReadInt64();
        ItemCount9 = binaryReader.ReadInt64();
        ItemID10 = binaryReader.ReadInt64();
        ItemCount10 = binaryReader.ReadInt64();
        ItemID11 = binaryReader.ReadInt64();
        ItemCount11 = binaryReader.ReadInt64();
        ItemID12 = binaryReader.ReadInt64();
        ItemCount12 = binaryReader.ReadInt64();
        ItemID13 = binaryReader.ReadInt64();
        ItemCount13 = binaryReader.ReadInt64();
        ItemID14 = binaryReader.ReadInt64();
        ItemCount14 = binaryReader.ReadInt64();
        ItemID15 = binaryReader.ReadInt64();
        ItemCount15 = binaryReader.ReadInt64();
        ItemID16 = binaryReader.ReadInt64();
        ItemCount16 = binaryReader.ReadInt64();
        ItemID17 = binaryReader.ReadInt64();
        ItemCount17 = binaryReader.ReadInt64();
        ItemID18 = binaryReader.ReadInt64();
        ItemCount18 = binaryReader.ReadInt64();
        ItemID19 = binaryReader.ReadInt64();
        ItemCount19 = binaryReader.ReadInt64();
        ItemID20 = binaryReader.ReadInt64();
        ItemCount20 = binaryReader.ReadInt64();
        ItemID21 = binaryReader.ReadInt64();
        ItemCount21 = binaryReader.ReadInt64();
        ItemID22 = binaryReader.ReadInt64();
        ItemCount22 = binaryReader.ReadInt64();
        ItemID23 = binaryReader.ReadInt64();
        ItemCount23 = binaryReader.ReadInt64();
        ItemID24 = binaryReader.ReadInt64();
        ItemCount24 = binaryReader.ReadInt64();
        Type = binaryReader.ReadInt64();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(ProductCode);
        binaryWriter.Write(Goods_Id);
        binaryWriter.Write(Multi_BuyCost1);
        binaryWriter.Write(Multi_BuyCost2);
        binaryWriter.Write(ItemID1);
        binaryWriter.Write(ItemCount1);
        binaryWriter.Write(ItemID2);
        binaryWriter.Write(ItemCount2);
        binaryWriter.Write(ItemID3);
        binaryWriter.Write(ItemCount3);
        binaryWriter.Write(ItemID4);
        binaryWriter.Write(ItemCount4);
        binaryWriter.Write(ItemID5);
        binaryWriter.Write(ItemCount5);
        binaryWriter.Write(ItemID6);
        binaryWriter.Write(ItemCount6);
        binaryWriter.Write(ItemID7);
        binaryWriter.Write(ItemCount7);
        binaryWriter.Write(ItemID8);
        binaryWriter.Write(ItemCount8);
        binaryWriter.Write(ItemID9);
        binaryWriter.Write(ItemCount9);
        binaryWriter.Write(ItemID10);
        binaryWriter.Write(ItemCount10);
        binaryWriter.Write(ItemID11);
        binaryWriter.Write(ItemCount11);
        binaryWriter.Write(ItemID12);
        binaryWriter.Write(ItemCount12);
        binaryWriter.Write(ItemID13);
        binaryWriter.Write(ItemCount13);
        binaryWriter.Write(ItemID14);
        binaryWriter.Write(ItemCount14);
        binaryWriter.Write(ItemID15);
        binaryWriter.Write(ItemCount15);
        binaryWriter.Write(ItemID16);
        binaryWriter.Write(ItemCount16);
        binaryWriter.Write(ItemID17);
        binaryWriter.Write(ItemCount17);
        binaryWriter.Write(ItemID18);
        binaryWriter.Write(ItemCount18);
        binaryWriter.Write(ItemID19);
        binaryWriter.Write(ItemCount19);
        binaryWriter.Write(ItemID20);
        binaryWriter.Write(ItemCount20);
        binaryWriter.Write(ItemID21);
        binaryWriter.Write(ItemCount21);
        binaryWriter.Write(ItemID22);
        binaryWriter.Write(ItemCount22);
        binaryWriter.Write(ItemID23);
        binaryWriter.Write(ItemCount23);
        binaryWriter.Write(ItemID24);
        binaryWriter.Write(ItemCount24);
        binaryWriter.Write(Type);
    }
}
