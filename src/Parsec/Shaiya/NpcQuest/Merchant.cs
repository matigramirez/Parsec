using System.Collections.Generic;
using Parsec.Readers;

namespace Parsec.Shaiya.NPCQUEST
{
    public class Merchant : BaseNpc
    {
        public MerchantType MerchantType { get; set; }

        /// <summary>
        /// The amount of items this Merchant sells
        /// </summary>
        public int ItemQuantity { get; set; }

        public List<MerchantItem> SaleItems { get; } = new();

        public Merchant(ShaiyaBinaryReader binaryReader)
        {
            ReadBaseNpcFirstSegment(binaryReader);
            MerchantType = (MerchantType)binaryReader.Read<byte>();
            ReadBaseNpcSecondSegment(binaryReader);

            ItemQuantity = binaryReader.Read<int>();

            for (int j = 0; j < ItemQuantity; j++)
            {
                var merchantItem = new MerchantItem(binaryReader);
                SaleItems.Add(merchantItem);
            }

            ReadBaseNpcThirdSegment(binaryReader);
        }
    }
}
