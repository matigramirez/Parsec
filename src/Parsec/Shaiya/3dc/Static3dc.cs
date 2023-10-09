using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3dc;

/// <summary>
/// Class that represents a .3DC model which is used for capes
/// </summary>
public sealed class Static3dc : FileBase
{
    /// <summary>
    /// List of vertices which are used to make faces (polygons)
    /// </summary>
    public List<_3dcVertex> Vertices { get; set; } = new();

    /// <summary>
    /// List of faces (polygons) that give shape to the mesh of the 3d model. Faces can only be made up of 3 vertices, so
    /// they'll all be triangular
    /// </summary>
    public List<MeshFace> Faces { get; set; } = new();

    [JsonIgnore]
    public override string Extension => "3DC";

    protected override void Read(SBinaryReader binaryReader)
    {
        var version = binaryReader.ReadInt32();
        Episode = Episode.EP5;

        if (version == 444)
        {
            Episode = Episode.EP6;
        }

        // Vertex instances expect the episode to be set on the serialization options
        binaryReader.SerializationOptions.Episode = Episode;

        Vertices = binaryReader.ReadList<_3dcVertex>().ToList();
        Faces = binaryReader.ReadList<MeshFace>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        var version = 0;

        if (Episode >= Episode.EP6)
        {
            version = 444;
        }

        // Vertex instances expect the episode to be set on the serialization options
        binaryWriter.SerializationOptions.Episode = Episode;

        binaryWriter.Write(version);
        binaryWriter.Write(Vertices.ToSerializable());
        binaryWriter.Write(Faces.ToSerializable());
    }
}
