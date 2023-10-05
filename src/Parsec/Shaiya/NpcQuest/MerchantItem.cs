using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class MerchantItem : ISerializable
{
    public byte ItemType { get; set; }

    public byte ItemTypeId { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        ItemType = binaryReader.ReadByte();
        ItemTypeId = binaryReader.ReadByte();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(ItemType);
        binaryWriter.Write(ItemTypeId);
    }
}
