using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public sealed class WldZone : ISerializable
{
    public BoundingBox BoundingBox { get; set; }

    public List<WldZoneIdentifier> Identifiers { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        BoundingBox = binaryReader.Read<BoundingBox>();
        Identifiers = binaryReader.ReadList<WldZoneIdentifier>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(Identifiers.ToSerializable());
    }
}
