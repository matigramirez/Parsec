using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Itm;

public struct ItmColor : ISerializable
{
    public byte Red { get; set; }

    public byte Green { get; set; }

    public byte Blue { get; set; }

    public byte Alpha { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Red = binaryReader.ReadByte();
        Green = binaryReader.ReadByte();
        Blue = binaryReader.ReadByte();
        Alpha = binaryReader.ReadByte();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Red);
        binaryWriter.Write(Green);
        binaryWriter.Write(Blue);
        binaryWriter.Write(Alpha);
    }
}
