using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Dg;

public class DgObject : ISerializable
{
    public int TextureIndex { get; set; }

    public List<DgMesh> Meshes { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        TextureIndex = binaryReader.ReadInt32();
        Meshes = binaryReader.ReadList<DgMesh>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(TextureIndex);
        binaryWriter.Write(Meshes.ToSerializable());
    }
}
