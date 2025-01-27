using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public sealed class WldZone : ISerializable
{
    public BoundingBox BoundingBox { get; set; }

    public List<int> Identifiers { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        BoundingBox = binaryReader.Read<BoundingBox>();

        var identifierCount = binaryReader.ReadInt32();

        for (var i = 0; i < identifierCount; i++)
        {
            var identifier = binaryReader.ReadInt32();
            Identifiers.Add(identifier);
        }
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(Identifiers.Count);

        foreach (var identifier in Identifiers)
        {
            binaryWriter.Write(identifier);
        }
    }
}
