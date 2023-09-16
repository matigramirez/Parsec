using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3DC;

/// <summary>
/// Class that represents a .3DC model which is used for capes
/// </summary>
[DefaultVersion(Episode.EP5)]
[VersionPrefixed(typeof(int), 0, Episode.EP5)]
[VersionPrefixed(typeof(int), 444, Episode.EP6)]
public sealed class Static3DC : FileBase
{
    /// <summary>
    /// List of vertices which are used to make faces (polygons)
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Vertex))]
    public List<Vertex> Vertices { get; set; } = new();

    /// <summary>
    /// List of faces (polygons) that give shape to the mesh of the 3d model. Faces can only be made up of 3 vertices, so
    /// they'll all be triangular
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Face))]
    public List<Face> Faces { get; set; } = new();

    [JsonIgnore]
    public override string Extension => "3DC";
}
