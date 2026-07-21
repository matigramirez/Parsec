using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Env;

/// <summary>
/// Describes one normal or weather interval in an environment timeline.
/// </summary>
public sealed class EnvRecord : ISerializable
{
    public const int ColorCount = 3;
    public const int SkyNameCount = 4;
    public const int LightingParameterCount = 6;
    public const int MaximumSkyNameByteLength = 4096;
    public const int MinutesPerDay = 24 * 60;

    public ushort StartMinute { get; set; }

    public ushort EndMinute { get; set; }

    public EnvColor[] Colors { get; set; } = new EnvColor[ColorCount];

    public string[] SkyNames { get; set; } =
    {
        "empty.tga",
        "empty.tga",
        "empty.tga",
        "empty.tga"
    };

    public float[] Lighting { get; set; } = new float[LightingParameterCount];

    public bool Weather { get; set; }

    public uint TransitionMilliseconds { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        StartMinute = DecodeTime(binaryReader.ReadInt32());
        EndMinute = DecodeTime(binaryReader.ReadInt32());

        Colors = new EnvColor[ColorCount];
        for (var i = 0; i < Colors.Length; i++)
        {
            Colors[i] = binaryReader.Read<EnvColor>();
        }

        SkyNames = new string[SkyNameCount];
        for (var i = 0; i < SkyNames.Length; i++)
        {
            SkyNames[i] = ReadSkyName(binaryReader);
        }

        Lighting = new float[LightingParameterCount];
        for (var i = 0; i < Lighting.Length; i++)
        {
            var value = binaryReader.ReadSingle();
            ValidateLighting(value);
            Lighting[i] = value;
        }

        Weather = binaryReader.ReadByte() != 0;

        var transitionMilliseconds = binaryReader.ReadInt32();
        if (transitionMilliseconds < 0)
        {
            throw new InvalidDataException("An .ENV transition duration cannot be negative.");
        }

        TransitionMilliseconds = (uint)transitionMilliseconds;
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        ValidateStructure(binaryWriter);

        binaryWriter.Write(EncodeTime(StartMinute));
        binaryWriter.Write(EncodeTime(EndMinute));

        foreach (var color in Colors)
        {
            binaryWriter.Write(color);
        }

        foreach (var skyName in SkyNames)
        {
            WriteSkyName(binaryWriter, skyName);
        }

        foreach (var value in Lighting)
        {
            binaryWriter.Write(value);
        }

        binaryWriter.Write(Weather ? (byte)1 : (byte)0);
        binaryWriter.Write((int)TransitionMilliseconds);
    }

    private static ushort DecodeTime(int value)
    {
        if (value < 0)
        {
            throw new InvalidDataException($"The .ENV file contains an invalid time of {value}.");
        }

        var hour = value / 100;
        var minute = value % 100;
        if (hour > 23 || minute > 59)
        {
            throw new InvalidDataException($"The .ENV file contains an invalid time of {value}.");
        }

        return (ushort)(hour * 60 + minute);
    }

    private static int EncodeTime(ushort minuteOfDay)
    {
        ValidateMinute(minuteOfDay);
        return minuteOfDay / 60 * 100 + minuteOfDay % 60;
    }

    private static string ReadSkyName(SBinaryReader binaryReader)
    {
        var byteLength = binaryReader.ReadUInt32();
        if (byteLength > MaximumSkyNameByteLength)
        {
            throw new InvalidDataException($"An .ENV sky name cannot exceed {MaximumSkyNameByteLength} bytes.");
        }

        if (byteLength > binaryReader.StreamLength - binaryReader.Position)
        {
            throw new InvalidDataException("The .ENV file contains a truncated sky name.");
        }

        var bytes = binaryReader.ReadBytes((int)byteLength);
        return binaryReader.SerializationOptions.Encoding.GetString(bytes);
    }

    private static void WriteSkyName(SBinaryWriter binaryWriter, string skyName)
    {
        if (skyName == null)
        {
            throw new InvalidDataException("An .ENV sky name cannot be null.");
        }

        var bytes = binaryWriter.SerializationOptions.Encoding.GetBytes(skyName);
        if (bytes.Length > MaximumSkyNameByteLength)
        {
            throw new InvalidDataException($"An .ENV sky name cannot exceed {MaximumSkyNameByteLength} bytes.");
        }

        binaryWriter.Write((uint)bytes.Length);
        binaryWriter.Write(bytes);
    }

    private void ValidateStructure(SBinaryWriter binaryWriter)
    {
        ValidateMinute(StartMinute);
        ValidateMinute(EndMinute);

        if (Colors == null || Colors.Length != ColorCount)
        {
            throw new InvalidDataException($"An .ENV record must contain exactly {ColorCount} colors.");
        }

        if (SkyNames == null || SkyNames.Length != SkyNameCount)
        {
            throw new InvalidDataException($"An .ENV record must contain exactly {SkyNameCount} sky names.");
        }

        foreach (var skyName in SkyNames)
        {
            var byteLength = skyName == null ? -1 : binaryWriter.SerializationOptions.Encoding.GetByteCount(skyName);
            if (byteLength < 0 || byteLength > MaximumSkyNameByteLength)
            {
                throw new InvalidDataException($"An .ENV sky name must contain at most {MaximumSkyNameByteLength} bytes.");
            }
        }

        if (Lighting == null || Lighting.Length != LightingParameterCount)
        {
            throw new InvalidDataException($"An .ENV record must contain exactly {LightingParameterCount} lighting parameters.");
        }

        foreach (var value in Lighting)
        {
            ValidateLighting(value);
        }

        if (TransitionMilliseconds > int.MaxValue)
        {
            throw new InvalidDataException($"An .ENV transition duration cannot exceed {int.MaxValue} milliseconds.");
        }
    }

    private static void ValidateMinute(ushort minuteOfDay)
    {
        if (minuteOfDay >= MinutesPerDay)
        {
            throw new InvalidDataException($"An .ENV minute-of-day value must be less than {MinutesPerDay}.");
        }
    }

    private static void ValidateLighting(float value)
    {
        if (float.IsNaN(value) || float.IsInfinity(value) || value < 0 || value > 100)
        {
            throw new InvalidDataException($"The .ENV file contains an invalid lighting value of {value}.");
        }
    }
}
