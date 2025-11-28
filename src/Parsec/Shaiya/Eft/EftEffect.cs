using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public class EftEffect : ISerializable
{
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Boolean
    /// </summary>
    public int Unknown1 { get; set; }

    /// <summary>
    /// Boolean
    /// </summary>
    public int Unknown2 { get; set; }

    /// <summary>
    /// Boolean
    /// </summary>
    public int Unknown3 { get; set; }

    public int Loop { get; set; }

    public int SrcBlend { get; set; }

    /// <summary>
    /// Values 0 to 3. Likely to be an enum
    /// </summary>
    public int Unknown6 { get; set; }

    public int DestBlend { get; set; }

    /// <summary>
    /// Boolean
    /// </summary>
    public int Unknown8 { get; set; }

    /// <summary>
    /// Index of the 3DE mesh object
    /// </summary>
    public int MeshIndex { get; set; }

    /// <summary>
    /// Boolean
    /// </summary>
    public int Unknown10 { get; set; }

    public float DelayPerFrame { get; set; }

    /// <summary>
    /// Values between 0.0f 6000.0f
    /// </summary>
    public float Unknown12 { get; set; }

    /// <summary>
    /// Values between 0.0f 10000.0f
    /// </summary>
    public float Unknown13 { get; set; }

    /// <summary>
    /// Values between 0.0f 6000.0f
    /// </summary>
    public float Unknown14 { get; set; }

    public float StartDelay { get; set; }

    /// <summary>
    /// Values between 0.0f 34.0f
    /// </summary>
    public float Unknown16 { get; set; }

    /// <summary>
    /// Values between -100.0f and 100.0f
    /// </summary>
    public float Unknown17 { get; set; }

    /// <summary>
    /// Values between 0.0f and 3.0f
    /// </summary>
    public float Unknown18 { get; set; }

    public Vector3 OffsetFrame { get; set; }

    public Vector3 Trembling { get; set; }

    /// <summary>
    /// The position where the effect should be rendered, relative to the effect's origin.
    /// In the case of mob effects, the origin is the bone to which the effect is attached to.
    /// </summary>
    public Vector3 Position { get; set; }

    public Vector3 Spread1 { get; set; }

    public Vector3 Spread2 { get; set; }

    /// <summary>
    /// Values 0 to 3. Likely to be an enum
    /// </summary>
    public int BaseAxis { get; set; }

    /// <summary>
    /// Boolean
    /// </summary>
    public int Unknown20 { get; set; }

    /// <summary>
    /// Boolean
    /// </summary>
    public int Unknown21 { get; set; }

    public Vector3 UnknownVec6 { get; set; }

    public float RotationSpeedMin { get; set; }

    public int RotationRandomEnabled { get; set; }

    public int RotationEnabled { get; set; }

    public float RotationSpeedMax { get; set; }

    /// <summary>
    /// Value between 1 and 3. Probably an enum
    /// </summary>
    public int RotationAxis { get; set; }

    /// <summary>
    /// Only present in EF3
    /// </summary>
    public float Unknown27 { get; set; }

    /// <summary>
    /// Only present in EF3
    /// </summary>
    public float Unknown28 { get; set; }

    public List<EftColorFrame> ColorFrames { get; set; } = new();

    public List<EftRotationFrame> RotationFrames { get; set; } = new();

    public List<EftSizeFrame> SizeFrames { get; set; } = new();

    /// <summary>
    /// Boolean
    /// </summary>
    public int Unknown29 { get; set; }

    /// <summary>
    /// Value between 1 and 3. Probably an enum
    /// </summary>
    public int Unknown30 { get; set; }

    /// <summary>
    /// Value between -360 and 364
    /// </summary>
    public int Unknown31 { get; set; }

    /// <summary>
    /// Value between -360 and 720. Probably an angle
    /// </summary>
    public int Unknown32 { get; set; }

    public List<EftEffectTexture> Sprites { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        var format = EftFormat.EFT;

        if (binaryReader.SerializationOptions.ExtraOption is EftFormat formatOption)
        {
            format = formatOption;
        }

        Name = binaryReader.ReadString();
        Unknown1 = binaryReader.ReadInt32();
        Unknown2 = binaryReader.ReadInt32();
        Unknown3 = binaryReader.ReadInt32();
        Loop = binaryReader.ReadInt32();
        SrcBlend = binaryReader.ReadInt32();
        Unknown6 = binaryReader.ReadInt32();
        DestBlend = binaryReader.ReadInt32();
        Unknown8 = binaryReader.ReadInt32();
        MeshIndex = binaryReader.ReadInt32();
        Unknown10 = binaryReader.ReadInt32();

        DelayPerFrame = binaryReader.ReadSingle();
        Unknown12 = binaryReader.ReadSingle();
        Unknown13 = binaryReader.ReadSingle();
        Unknown14 = binaryReader.ReadSingle();
        StartDelay = binaryReader.ReadSingle();
        Unknown16 = binaryReader.ReadSingle();
        Unknown17 = binaryReader.ReadSingle();
        Unknown18 = binaryReader.ReadSingle();

        OffsetFrame = binaryReader.Read<Vector3>();
        Trembling = binaryReader.Read<Vector3>();
        Position = binaryReader.Read<Vector3>();
        Spread1 = binaryReader.Read<Vector3>();
        Spread2 = binaryReader.Read<Vector3>();

        BaseAxis = binaryReader.ReadInt32();
        Unknown20 = binaryReader.ReadInt32();
        Unknown21 = binaryReader.ReadInt32();

        UnknownVec6 = binaryReader.Read<Vector3>();

        RotationSpeedMin = binaryReader.ReadSingle();
        RotationRandomEnabled = binaryReader.ReadInt32();
        RotationEnabled = binaryReader.ReadInt32();
        RotationSpeedMax = binaryReader.ReadSingle();
        RotationAxis = binaryReader.ReadInt32();

        if (format == EftFormat.EF3)
        {
            Unknown27 = binaryReader.ReadSingle();
            Unknown28 = binaryReader.ReadSingle();
        }

        ColorFrames = binaryReader.ReadList<EftColorFrame>().ToList();
        RotationFrames = binaryReader.ReadList<EftRotationFrame>().ToList();
        SizeFrames = binaryReader.ReadList<EftSizeFrame>().ToList();

        Unknown29 = binaryReader.ReadInt32();
        Unknown30 = binaryReader.ReadInt32();
        Unknown31 = binaryReader.ReadInt32();
        Unknown32 = binaryReader.ReadInt32();

        Sprites = binaryReader.ReadList<EftEffectTexture>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var format = EftFormat.EFT;

        if (binaryWriter.SerializationOptions.ExtraOption is EftFormat formatOption)
        {
            format = formatOption;
        }

        binaryWriter.Write(Name);
        binaryWriter.Write(Unknown1);
        binaryWriter.Write(Unknown2);
        binaryWriter.Write(Unknown3);
        binaryWriter.Write(Loop);
        binaryWriter.Write(SrcBlend);
        binaryWriter.Write(Unknown6);
        binaryWriter.Write(DestBlend);
        binaryWriter.Write(Unknown8);
        binaryWriter.Write(MeshIndex);
        binaryWriter.Write(Unknown10);
        binaryWriter.Write(DelayPerFrame);
        binaryWriter.Write(Unknown12);
        binaryWriter.Write(Unknown13);
        binaryWriter.Write(Unknown14);
        binaryWriter.Write(StartDelay);
        binaryWriter.Write(Unknown16);
        binaryWriter.Write(Unknown17);
        binaryWriter.Write(Unknown18);

        binaryWriter.Write(OffsetFrame);
        binaryWriter.Write(Trembling);
        binaryWriter.Write(Position);
        binaryWriter.Write(Spread1);
        binaryWriter.Write(Spread2);

        binaryWriter.Write(BaseAxis);
        binaryWriter.Write(Unknown20);
        binaryWriter.Write(Unknown21);

        binaryWriter.Write(UnknownVec6);

        binaryWriter.Write(RotationSpeedMin);
        binaryWriter.Write(RotationRandomEnabled);
        binaryWriter.Write(RotationEnabled);
        binaryWriter.Write(RotationSpeedMax);
        binaryWriter.Write(RotationAxis);

        if (format == EftFormat.EF3)
        {
            binaryWriter.Write(Unknown27);
            binaryWriter.Write(Unknown28);
        }

        binaryWriter.Write(ColorFrames.ToSerializable());
        binaryWriter.Write(RotationFrames.ToSerializable());
        binaryWriter.Write(SizeFrames.ToSerializable());

        binaryWriter.Write(Unknown29);
        binaryWriter.Write(Unknown30);
        binaryWriter.Write(Unknown31);
        binaryWriter.Write(Unknown32);

        binaryWriter.Write(Sprites.ToSerializable());
    }
}
