using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NPCQUEST
{
    public class Merchant : BaseNpc, IBinary
    {
        public MerchantType MerchantType { get; set; }

        public List<MerchantItem> SaleItems { get; } = new();

        public Merchant(ShaiyaBinaryReader binaryReader)
        {
            ReadBaseNpcFirstSegment(binaryReader);
            MerchantType = (MerchantType)binaryReader.Read<byte>();
            ReadBaseNpcSecondSegment(binaryReader);

            var saleItemCount = binaryReader.Read<int>();

            for (int i = 0; i < saleItemCount; i++)
            {
                var merchantItem = new MerchantItem(binaryReader);
                SaleItems.Add(merchantItem);
            }

            ReadBaseNpcThirdSegment(binaryReader);
        }

        public override byte[] GetBytes()
        {
            var buffer = new List<byte>();

            WriteBaseNpcFirstSegmentBytes(buffer);
            buffer.Add((byte)MerchantType);
            WriteBaseNpcSecondSegmentBytes(buffer);

            buffer.AddRange(BitConverter.GetBytes(SaleItems.Count));

            foreach (var saleItem in SaleItems)
            {
                buffer.AddRange(saleItem.GetBytes());
            }

            WriteBaseNpcThirdSegmentBytes(buffer);

            return buffer.ToArray();
        }
    }
}
