using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public class WldUnknownBox : ISerializable
{
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// BoundingBox Radius
    /// </summary>
    public float Radius { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        BoundingBox = binaryReader.Read<BoundingBox>();
        Radius = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(Radius);
    }
}
