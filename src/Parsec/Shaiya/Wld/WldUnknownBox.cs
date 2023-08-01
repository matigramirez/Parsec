using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public class WldUnknownBox : IBinary
{
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// BoundingBox Radius
    /// </summary>
    public float Radius { get; set; }

    [JsonConstructor]
    public WldUnknownBox()
    {
    }

    public WldUnknownBox(SBinaryReader binaryReader)
    {
        BoundingBox = new BoundingBox(binaryReader);
        Radius = binaryReader.Read<float>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(BoundingBox.GetBytes());
        buffer.AddRange(Radius.GetBytes());
        return buffer;
    }
}
