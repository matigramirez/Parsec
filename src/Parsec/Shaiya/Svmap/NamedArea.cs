using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class NamedArea : IBinary
{
    [JsonConstructor]
    public NamedArea()
    {
    }

    public NamedArea(SBinaryReader binaryReader)
    {
        Area = new BoundingBox(binaryReader);
        NameIdentifier1 = binaryReader.Read<int>();
        NameIdentifier2 = binaryReader.Read<int>();
    }

    public BoundingBox Area { get; set; }
    public int NameIdentifier1 { get; set; }
    public int NameIdentifier2 { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Area.GetBytes());
        buffer.AddRange(NameIdentifier1.GetBytes());
        buffer.AddRange(NameIdentifier2.GetBytes());
        return buffer;
    }
}
