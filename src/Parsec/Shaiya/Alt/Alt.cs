﻿using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Alt;

/// <summary>
/// Class that represents the ALT format which is used to define the available animations for characters.
/// </summary>
public sealed class Alt : FileBase
{
    public string Header { get; set; } = string.Empty;

    public List<AltAnimation> Animations { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        Header = binaryReader.ReadString(3);
        Animations = binaryReader.ReadList<AltAnimation>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Header, isLengthPrefixed: false, includeStringTerminator: false);
        binaryWriter.Write(Animations.ToSerializable());
    }
}
