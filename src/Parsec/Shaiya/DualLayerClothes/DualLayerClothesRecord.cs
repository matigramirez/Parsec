using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.DualLayerClothes;

public sealed class DualLayerClothesRecord : ISerializable
{
    public ushort Index { get; set; }

    public ushort Upper { get; set; }

    public ushort Hands { get; set; }

    public ushort Lower { get; set; }

    public ushort Feet { get; set; }

    public ushort Face { get; set; }

    public ushort Head { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Index = binaryReader.ReadUInt16();
        Upper = binaryReader.ReadUInt16();
        Hands = binaryReader.ReadUInt16();
        Lower = binaryReader.ReadUInt16();
        Feet = binaryReader.ReadUInt16();
        Face = binaryReader.ReadUInt16();
        Head = binaryReader.ReadUInt16();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Index);
        binaryWriter.Write(Upper);
        binaryWriter.Write(Hands);
        binaryWriter.Write(Lower);
        binaryWriter.Write(Feet);
        binaryWriter.Write(Face);
        binaryWriter.Write(Head);
    }
}
