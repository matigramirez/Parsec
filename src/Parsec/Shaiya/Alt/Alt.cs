using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Alt;

/// <summary>
/// Class that represents the ALT format which is used to define the available animations for characters.
/// This class has custom implementations of the <see cref="Read"/> and <see cref="GetBytes"/> methods because its subclass <see cref="AltAnimation"/>
/// has a serialization anti-pattern.
/// </summary>
public sealed class Alt : FileBase
{
    public string Signature { get; set; } = string.Empty;
    public List<AltAnimation> Animations { get; set; } = new();

    public override string Extension => ".ALT";

    protected override void Read(SBinaryReader binaryReader)
    {
        Signature = binaryReader.ReadString(3);
        Animations = binaryReader.ReadList<AltAnimation>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Signature, isLengthPrefixed: false, includeStringTerminator: false);
        binaryWriter.Write(Animations.ToSerializable());
    }
}
