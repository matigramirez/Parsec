using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public class WldSub1 : IBinary
{
    public BoundingBox BoundingBox { get; set; }

    public float DistanceToCenter { get; set; }

    public WldSub1(SBinaryReader binaryReader)
    {
        BoundingBox = new BoundingBox(binaryReader);
        DistanceToCenter = binaryReader.Read<float>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(BoundingBox.GetBytes());
        buffer.AddRange(DistanceToCenter.GetBytes());
        return buffer;
    }
}
