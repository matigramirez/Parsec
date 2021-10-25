using System.Collections.Generic;

namespace Parsec.Shaiya
{
    public class Merchant : BaseNpc
    {
        public MerchantType MerchantType { get; set; }

        /// <summary>
        /// The amount of items this Merchant sells
        /// </summary>
        public int ItemQuantity { get; set; }

        public List<MerchantItem> SaleItems { get; } = new();
    }
}
