using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

public sealed class WldZone : IBinary
{
    public BoundingBox BoundingBox { get; set; }
    public List<int> Identifiers { get; set; } = new();

    public WldZone(SBinaryReader binaryReader)
    {
        BoundingBox = new BoundingBox(binaryReader);

        int identifierCount = binaryReader.Read<int>();

        for (int i = 0; i < identifierCount; i++)
        {
            int identifier = binaryReader.Read<int>();
            Identifiers.Add(identifier);
        }
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(BoundingBox.GetBytes());

        buffer.AddRange(Identifiers.Count.GetBytes());
        foreach (int identifier in Identifiers)
            buffer.AddRange(identifier.GetBytes());

        return buffer;
    }
}
