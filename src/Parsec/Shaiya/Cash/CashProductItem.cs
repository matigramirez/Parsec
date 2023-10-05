using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cash;

public sealed class CashProductItem : ISerializable
{
    public uint ItemId { get; set; }

    public byte Count { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        ItemId = binaryReader.ReadUInt32();
        Count = binaryReader.ReadByte();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(ItemId);
        binaryWriter.Write(Count);
    }
}
