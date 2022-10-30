using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3DO;

/// <summary>
/// Class that represents a .3DO which is used for weapons and shields. This format doesn't contain bones, it's just a mesh with a texture.
/// </summary>
[DefaultVersion(Episode.EP5)]
public sealed class _3DO : FileBase
{
    [ShaiyaProperty]
    [LengthPrefixedString(includeStringTerminator: false)]
    public string TextureName { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Vertex))]
    public List<Vertex> Vertices { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Face))]
    public List<Face> Faces { get; set; } = new();

    [JsonIgnore]
    public override string Extension => "3DO";
}
