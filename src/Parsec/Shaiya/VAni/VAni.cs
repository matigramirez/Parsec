using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.VAni;

public class VAni : FileBase, IJsonReadable
{
    /// <summary>
    /// Coordinates of the center of the 3d object
    /// </summary>
    public Vector3 Center { get; set; }

    /// <summary>
    /// Rotation on the Y-Axis in radians
    /// </summary>
    public float Orientation { get; set; }

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
        Orientation = _binaryReader.Read<float>();
        BoundingBox = new BoundingBox(_binaryReader);
        var objectCount = _binaryReader.Read<int>();
        FrameCount = _binaryReader.Read<int>();
        Unknown1 = _binaryReader.Read<int>();

        for (int i = 0; i < objectCount; i++)
        {
            var obj = new VAniObject(_binaryReader, FrameCount);
            Objects.Add(obj);
        }

        BoundingBox2 = new BoundingBox(_binaryReader);
        Unknown2 = _binaryReader.Read<int>();
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Center.GetBytes());
        buffer.AddRange(Orientation.GetBytes());
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
