using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SetItem;

public sealed class SetItemRecordItem : ISerializable
{
    public ushort Type { get; set; }

    public ushort TypeId { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Type = binaryReader.ReadUInt16();
        TypeId = binaryReader.ReadUInt16();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Type);
        binaryWriter.Write(TypeId);
    }
}
