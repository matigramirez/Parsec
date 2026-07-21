using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Env;

/// <summary>
/// An .ENV RGB color normalized to the range 0 through 1.
/// </summary>
public struct EnvColor : ISerializable
{
    private const float MaximumEncodedChannel = 255f;

    public float Red { get; set; }

    public float Green { get; set; }

    public float Blue { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Red = ReadChannel(binaryReader);
        Green = ReadChannel(binaryReader);
        Blue = ReadChannel(binaryReader);
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(EncodeChannel(Red));
        binaryWriter.Write(EncodeChannel(Green));
        binaryWriter.Write(EncodeChannel(Blue));
    }

    private static float ReadChannel(SBinaryReader binaryReader)
    {
        var value = binaryReader.ReadInt32();
        if (value < 0 || value > MaximumEncodedChannel)
        {
            throw new InvalidDataException($"The .ENV file contains an invalid color channel of {value}.");
        }

        return value / MaximumEncodedChannel;
    }

    private static int EncodeChannel(float value)
    {
        if (float.IsNaN(value) || float.IsInfinity(value) || value < 0 || value > 1)
        {
            throw new InvalidDataException($"An .ENV color channel must be between 0 and 1, but was {value}.");
        }

        return (int)Math.Round(value * MaximumEncodedChannel, MidpointRounding.AwayFromZero);
    }
}
