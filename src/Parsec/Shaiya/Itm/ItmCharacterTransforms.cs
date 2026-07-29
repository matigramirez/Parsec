using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Itm;

/// <summary>
/// The two attachment transforms stored for one character archetype in an
/// IT2 record.
/// </summary>
public sealed class ItmCharacterTransforms : ISerializable
{
    public ItmCharacterCode CharacterCode { get; set; }

    public ItmBoneTransform Primary { get; set; } = new();

    public ItmBoneTransform Secondary { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Primary = binaryReader.Read<ItmBoneTransform>();
        Secondary = binaryReader.Read<ItmBoneTransform>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Primary);
        binaryWriter.Write(Secondary);
    }
}
