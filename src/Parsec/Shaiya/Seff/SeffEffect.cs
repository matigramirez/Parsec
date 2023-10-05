using System.Text;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Seff;

public sealed class SeffEffect : ISerializable
{
    public uint ParticleCount { get; set; }

    public float ParticleVelocity { get; set; }

    /// <summary>
    /// Supported values are 0-3. 0 appears to be Normal. To-do: enumeration.
    /// https://en.wikipedia.org/wiki/Blend_modes
    /// </summary>
    public uint TextureBlendMode { get; set; }

    /// <summary>
    /// Supported values are 0-9.
    /// </summary>
    public uint StartPositionMultiplier { get; set; }

    /// <summary>
    /// Milliseconds
    /// </summary>
    public uint ParticleLifetime { get; set; }

    public float Unknown6 { get; set; }

    public string TextureFileName { get; set; } = string.Empty;

    public byte Red { get; set; }

    public byte Green { get; set; }

    public byte Blue { get; set; }

    public Vector3 ParticleStartPosition { get; set; }

    public float Unknown10 { get; set; }

    public float ParticleStartSize { get; set; }

    public bool IsVisible { get; set; }

    public float Unknown12 { get; set; }

    public float RotateWithStretchMultiplier { get; set; }

    public float VelocityMultiplier { get; set; }

    public uint Unknown15 { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        var format = 0;

        if (binaryReader.SerializationOptions.ExtraOption is int formatOption)
        {
            format = formatOption;
        }

        ParticleCount = binaryReader.ReadUInt32();
        ParticleVelocity = binaryReader.ReadSingle();
        TextureBlendMode = binaryReader.ReadUInt32();
        StartPositionMultiplier = binaryReader.ReadUInt32();
        ParticleLifetime = binaryReader.ReadUInt32();
        Unknown6 = binaryReader.ReadSingle();
        TextureFileName = binaryReader.ReadString(Encoding.Unicode);
        Red = binaryReader.ReadByte();
        Green = binaryReader.ReadByte();
        Blue = binaryReader.ReadByte();
        ParticleStartPosition = binaryReader.Read<Vector3>();
        Unknown10 = binaryReader.ReadSingle();
        ParticleStartSize = binaryReader.ReadSingle();
        IsVisible = binaryReader.ReadBool();

        Unknown12 = binaryReader.ReadSingle();

        if (format > 2)
        {
            RotateWithStretchMultiplier = binaryReader.ReadSingle();
        }

        if (format > 3)
        {
            VelocityMultiplier = binaryReader.ReadSingle();
        }

        if (format > 5)
        {
            Unknown15 = binaryReader.ReadUInt32();
        }
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var format = 0;

        if (binaryWriter.SerializationOptions.ExtraOption is int formatOption)
        {
            format = formatOption;
        }

        binaryWriter.Write(ParticleCount);
        binaryWriter.Write(ParticleVelocity);
        binaryWriter.Write(TextureBlendMode);
        binaryWriter.Write(StartPositionMultiplier);
        binaryWriter.Write(ParticleLifetime);
        binaryWriter.Write(Unknown6);
        binaryWriter.Write(TextureFileName, Encoding.Unicode, false);
        binaryWriter.Write(Red);
        binaryWriter.Write(Green);
        binaryWriter.Write(Blue);
        binaryWriter.Write(ParticleStartPosition);
        binaryWriter.Write(Unknown10);
        binaryWriter.Write(ParticleStartSize);
        binaryWriter.Write(IsVisible);

        binaryWriter.Write(Unknown12);

        if (format > 2)
        {
            binaryWriter.Write(RotateWithStretchMultiplier);
        }

        if (format > 3)
        {
            binaryWriter.Write(VelocityMultiplier);
        }

        if (format > 5)
        {
            binaryWriter.Write(Unknown15);
        }
    }
}
