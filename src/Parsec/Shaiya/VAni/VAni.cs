using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.VAni;

public sealed class VAni : FileBase
{
    /// <summary>
    /// Coordinates of the center of the 3d object
    /// </summary>
    public Vector3 Center { get; set; }

    /// <summary>
    /// The distance between the vertices of the <see cref="BoundingBox"/> and the <see cref="Center"/> of the VAni object. Used for game calculations.
    /// </summary>
    public float DistanceToCenter { get; set; }

    /// <summary>
    /// Rectangular bounding box
    /// </summary>
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// Amount of frames
    /// </summary>
    public int FrameCount { get; set; }

    /// <summary>
    /// Castor's notes: "__int32	features;	// bitmask of rendering options?"
    /// </summary>
    public int Unknown1 { get; set; }

    public List<VAniObject> Objects { get; } = new();

    public BoundingBox BoundingBox2 { get; set; }

    /// <summary>
    /// Always 00?
    /// </summary>
    public int Unknown2 { get; set; }

    public override string Extension => "VANI";

    public override void Read(params object[] options)
    {
        Center = new Vector3(_binaryReader);
        DistanceToCenter = _binaryReader.Read<float>();
        BoundingBox = new BoundingBox(_binaryReader);
        int objectCount = _binaryReader.Read<int>();
        FrameCount = _binaryReader.Read<int>();
        Unknown1 = _binaryReader.Read<int>();

        for (int i = 0; i < objectCount; i++)
            Objects.Add(new VAniObject(_binaryReader, FrameCount));

        BoundingBox2 = new BoundingBox(_binaryReader);
        Unknown2 = _binaryReader.Read<int>();
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Center.GetBytes());
        buffer.AddRange(DistanceToCenter.GetBytes());
        buffer.AddRange(BoundingBox.GetBytes());
        buffer.AddRange(Objects.Count.GetBytes());
        buffer.AddRange(FrameCount.GetBytes());
        buffer.AddRange(Unknown1.GetBytes());

        foreach (var obj in Objects)
            buffer.AddRange(obj.GetBytes());

        buffer.AddRange(BoundingBox2.GetBytes());
        buffer.AddRange(Unknown2.GetBytes());
        return buffer;
    }
}
