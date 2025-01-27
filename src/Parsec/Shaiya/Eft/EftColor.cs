using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

/// <summary>
/// Represents an RGBA color used in <see cref="EftEffect"/>
/// </summary>
public struct EftColor : ISerializable
{
    public float Red { get; set; }

    public float Green { get; set; }

    public float Blue { get; set; }

    public float Alpha { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Red = binaryReader.ReadSingle();
        Green = binaryReader.ReadSingle();
        Blue = binaryReader.ReadSingle();
        Alpha = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Red);
        binaryWriter.Write(Green);
        binaryWriter.Write(Blue);
        binaryWriter.Write(Alpha);
    }
}
