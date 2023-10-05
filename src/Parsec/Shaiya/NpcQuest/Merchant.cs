using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class Merchant : BaseNpc, ISerializable
{
    public MerchantType MerchantType { get; set; }

    public List<MerchantItem> Items { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        ReadBaseNpcFirstSegment(binaryReader);
        MerchantType = (MerchantType)binaryReader.ReadByte();
        ReadBaseNpcSecondSegment(binaryReader);
        Items = binaryReader.ReadList<MerchantItem>().ToList();
        ReadBaseNpcThirdSegment(binaryReader);
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        WriteBaseNpcFirstSegment(binaryWriter);
        binaryWriter.Write((byte)MerchantType);
        WriteBaseNpcSecondSegment(binaryWriter);
        binaryWriter.Write(Items.ToSerializable());
        WriteBaseNpcThirdSegment(binaryWriter);
    }
}
