using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

public struct Color : ISerializable
{
    public float Red { get; set; }

    public float Green { get; set; }

    public float Blue { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Red = binaryReader.ReadSingle();
        Green = binaryReader.ReadSingle();
        Blue = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Red);
        binaryWriter.Write(Green);
        binaryWriter.Write(Blue);
    }
}
