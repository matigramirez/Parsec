using System.Text.Json.Serialization;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cloak.Emblem;

public sealed class EmblemDat : FileBase
{
    public List<String256> Textures { get; set; } = new();

    [JsonIgnore]
    public override string Extension => "dat";

    protected override void Read(SBinaryReader binaryReader)
    {
        Textures = binaryReader.ReadList<String256>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Textures.ToSerializable());
    }
}
