using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Dg;

public class DgMesh : ISerializable
{
    public AlphaBlendingMode AlphaBlendingMode { get; set; }

    public List<DgSegmentVertex> Vertices { get; set; } = new();

    public List<MeshFace> Faces { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        AlphaBlendingMode = (AlphaBlendingMode)binaryReader.ReadInt32();
        Vertices = binaryReader.ReadList<DgSegmentVertex>().ToList();
        Faces = binaryReader.ReadList<MeshFace>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write((int)AlphaBlendingMode);
        binaryWriter.Write(Vertices.ToSerializable());
        binaryWriter.Write(Faces.ToSerializable());
    }
}
