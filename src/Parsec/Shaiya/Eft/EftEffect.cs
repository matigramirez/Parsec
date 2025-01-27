﻿using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public class EftEffect : ISerializable
{
    public string Name { get; set; } = string.Empty;

    public int Unknown1 { get; set; }

    public int Unknown2 { get; set; }

    public int Unknown3 { get; set; }

    public int Loop { get; set; }

    public int SrcBlend { get; set; }

    public int Unknown6 { get; set; }

    public int DestBlend { get; set; }

    public int Unknown8 { get; set; }

    /// <summary>
    /// Index of the 3DE mesh object
    /// </summary>
    public int MeshIndex { get; set; }

    public int Unknown10 { get; set; }

    public float DelayPerFrame { get; set; }

    public float Unknown12 { get; set; }

    public float Unknown13 { get; set; }

    public float Unknown14 { get; set; }

    public float InitialDelay { get; set; }

    public float Unknown16 { get; set; }

    public float Unknown17 { get; set; }

    public float Unknown18 { get; set; }

    public Vector3 OffsetFrame { get; set; }

    public Vector3 Trembling { get; set; }

    /// <summary>
    /// The position where the effect should be rendered, relative to the effect's origin.
    /// In the case of mob effects, the origin is the bone to which the effect is attached to.
    /// </summary>
    public Vector3 Position { get; set; } = new();

    public Vector3 Spread1 { get; set; }

    public Vector3 Spread2 { get; set; }

    public int BaseAxis { get; set; }

    public int Unknown20 { get; set; }

    public int Unknown21 { get; set; }

    public Vector3 UnknownVec6 { get; set; } = new();

    public float RotationSpeedMin { get; set; }

    public int RotationRandomEnabled { get; set; }

    public int RotationEnabled { get; set; }

    public float RotationSpeedMax { get; set; }

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

    public List<EftOpacityFrame> OpacityFrames { get; set; } = new();

    public List<EftEffectSub3> EffectSub3List { get; set; } = new();

    public int Unknown29 { get; set; }

    public int Unknown30 { get; set; }

    public int Unknown31 { get; set; }

    public int Unknown32 { get; set; }

    public List<EftEffectTexture> Textures { get; set; } = new();

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
        InitialDelay = binaryReader.ReadSingle();
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
        OpacityFrames = binaryReader.ReadList<EftOpacityFrame>().ToList();
        EffectSub3List = binaryReader.ReadList<EftEffectSub3>().ToList();

        Unknown29 = binaryReader.ReadInt32();
        Unknown30 = binaryReader.ReadInt32();
        Unknown31 = binaryReader.ReadInt32();
        Unknown32 = binaryReader.ReadInt32();

        Textures = binaryReader.ReadList<EftEffectTexture>().ToList();
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
        binaryWriter.Write(InitialDelay);
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
        binaryWriter.Write(OpacityFrames.ToSerializable());
        binaryWriter.Write(EffectSub3List.ToSerializable());

        binaryWriter.Write(Unknown29);
        binaryWriter.Write(Unknown30);
        binaryWriter.Write(Unknown31);
        binaryWriter.Write(Unknown32);

        binaryWriter.Write(Textures.ToSerializable());
    }
}
