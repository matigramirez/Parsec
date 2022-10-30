using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class Merchant : BaseNpc, IBinary
{
    public MerchantType MerchantType { get; set; }

    public List<MerchantItem> SaleItems { get; } = new();

    public Merchant(SBinaryReader binaryReader, Episode episode)
    {
        ReadBaseNpcFirstSegment(binaryReader);
        MerchantType = (MerchantType)binaryReader.Read<byte>();
        ReadBaseNpcSecondSegment(binaryReader, episode);

        int saleItemCount = binaryReader.Read<int>();

        for (int i = 0; i < saleItemCount; i++)
        {
            var merchantItem = new MerchantItem(binaryReader);
            SaleItems.Add(merchantItem);
        }

        ReadBaseNpcThirdSegment(binaryReader);
    }

    [JsonConstructor]
    public Merchant()
    {
    }

    public override IEnumerable<byte> GetBytes(params object[] options)
    {
        var episode = Episode.EP5;

        if (options.Length > 0)
            episode = (Episode)options[0];

        var buffer = new List<byte>();
        WriteBaseNpcFirstSegmentBytes(buffer);
        buffer.Add((byte)MerchantType);
        WriteBaseNpcSecondSegmentBytes(buffer, episode);
        buffer.AddRange(SaleItems.GetBytes());
        WriteBaseNpcThirdSegmentBytes(buffer);
        return buffer;
    }
}
