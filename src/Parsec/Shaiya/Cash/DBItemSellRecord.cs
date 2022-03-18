using System.Collections.Generic;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Cash
{
    public class DBItemSellRecord : IBinarySDataRecord
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

        public void Read(SBinaryReader binaryReader, params object[] options)
        {
            ProductCode = binaryReader.Read<long>();
            Goods_Id = binaryReader.Read<long>();
            Multi_BuyCost1 = binaryReader.Read<long>();
            Multi_BuyCost2 = binaryReader.Read<long>();
            ItemID1 = binaryReader.Read<long>();
            ItemCount1 = binaryReader.Read<long>();
            ItemID2 = binaryReader.Read<long>();
            ItemCount2 = binaryReader.Read<long>();
            ItemID3 = binaryReader.Read<long>();
            ItemCount3 = binaryReader.Read<long>();
            ItemID4 = binaryReader.Read<long>();
            ItemCount4 = binaryReader.Read<long>();
            ItemID5 = binaryReader.Read<long>();
            ItemCount5 = binaryReader.Read<long>();
            ItemID6 = binaryReader.Read<long>();
            ItemCount6 = binaryReader.Read<long>();
            ItemID7 = binaryReader.Read<long>();
            ItemCount7 = binaryReader.Read<long>();
            ItemID8 = binaryReader.Read<long>();
            ItemCount8 = binaryReader.Read<long>();
            ItemID9 = binaryReader.Read<long>();
            ItemCount9 = binaryReader.Read<long>();
            ItemID10 = binaryReader.Read<long>();
            ItemCount10 = binaryReader.Read<long>();
            ItemID11 = binaryReader.Read<long>();
            ItemCount11 = binaryReader.Read<long>();
            ItemID12 = binaryReader.Read<long>();
            ItemCount12 = binaryReader.Read<long>();
            ItemID13 = binaryReader.Read<long>();
            ItemCount13 = binaryReader.Read<long>();
            ItemID14 = binaryReader.Read<long>();
            ItemCount14 = binaryReader.Read<long>();
            ItemID15 = binaryReader.Read<long>();
            ItemCount15 = binaryReader.Read<long>();
            ItemID16 = binaryReader.Read<long>();
            ItemCount16 = binaryReader.Read<long>();
            ItemID17 = binaryReader.Read<long>();
            ItemCount17 = binaryReader.Read<long>();
            ItemID18 = binaryReader.Read<long>();
            ItemCount18 = binaryReader.Read<long>();
            ItemID19 = binaryReader.Read<long>();
            ItemCount19 = binaryReader.Read<long>();
            ItemID20 = binaryReader.Read<long>();
            ItemCount20 = binaryReader.Read<long>();
            ItemID21 = binaryReader.Read<long>();
            ItemCount21 = binaryReader.Read<long>();
            ItemID22 = binaryReader.Read<long>();
            ItemCount22 = binaryReader.Read<long>();
            ItemID23 = binaryReader.Read<long>();
            ItemCount23 = binaryReader.Read<long>();
            ItemID24 = binaryReader.Read<long>();
            ItemCount24 = binaryReader.Read<long>();
            Type = binaryReader.Read<long>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(ProductCode.GetBytes());
            buffer.AddRange(Goods_Id.GetBytes());
            buffer.AddRange(Multi_BuyCost1.GetBytes());
            buffer.AddRange(Multi_BuyCost2.GetBytes());
            buffer.AddRange(ItemID1.GetBytes());
            buffer.AddRange(ItemCount1.GetBytes());
            buffer.AddRange(ItemID2.GetBytes());
            buffer.AddRange(ItemCount2.GetBytes());
            buffer.AddRange(ItemID3.GetBytes());
            buffer.AddRange(ItemCount3.GetBytes());
            buffer.AddRange(ItemID4.GetBytes());
            buffer.AddRange(ItemCount4.GetBytes());
            buffer.AddRange(ItemID5.GetBytes());
            buffer.AddRange(ItemCount5.GetBytes());
            buffer.AddRange(ItemID6.GetBytes());
            buffer.AddRange(ItemCount6.GetBytes());
            buffer.AddRange(ItemID7.GetBytes());
            buffer.AddRange(ItemCount7.GetBytes());
            buffer.AddRange(ItemID8.GetBytes());
            buffer.AddRange(ItemCount8.GetBytes());
            buffer.AddRange(ItemID9.GetBytes());
            buffer.AddRange(ItemCount9.GetBytes());
            buffer.AddRange(ItemID10.GetBytes());
            buffer.AddRange(ItemCount10.GetBytes());
            buffer.AddRange(ItemID11.GetBytes());
            buffer.AddRange(ItemCount11.GetBytes());
            buffer.AddRange(ItemID12.GetBytes());
            buffer.AddRange(ItemCount12.GetBytes());
            buffer.AddRange(ItemID13.GetBytes());
            buffer.AddRange(ItemCount13.GetBytes());
            buffer.AddRange(ItemID14.GetBytes());
            buffer.AddRange(ItemCount14.GetBytes());
            buffer.AddRange(ItemID15.GetBytes());
            buffer.AddRange(ItemCount15.GetBytes());
            buffer.AddRange(ItemID16.GetBytes());
            buffer.AddRange(ItemCount16.GetBytes());
            buffer.AddRange(ItemID17.GetBytes());
            buffer.AddRange(ItemCount17.GetBytes());
            buffer.AddRange(ItemID18.GetBytes());
            buffer.AddRange(ItemCount18.GetBytes());
            buffer.AddRange(ItemID19.GetBytes());
            buffer.AddRange(ItemCount19.GetBytes());
            buffer.AddRange(ItemID20.GetBytes());
            buffer.AddRange(ItemCount20.GetBytes());
            buffer.AddRange(ItemID21.GetBytes());
            buffer.AddRange(ItemCount21.GetBytes());
            buffer.AddRange(ItemID22.GetBytes());
            buffer.AddRange(ItemCount22.GetBytes());
            buffer.AddRange(ItemID23.GetBytes());
            buffer.AddRange(ItemCount23.GetBytes());
            buffer.AddRange(ItemID24.GetBytes());
            buffer.AddRange(ItemCount24.GetBytes());
            buffer.AddRange(Type.GetBytes());
            return buffer.ToArray();
        }
    }
}
