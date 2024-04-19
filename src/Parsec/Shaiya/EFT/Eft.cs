using System.Text.Json.Serialization;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class Eft : FileBase
{
    [JsonIgnore]
    public EftFormat Format { get; set; }

    public List<EftEffectMesh> Meshes { get; set; } = new();

    public List<EftTexture> Textures { get; set; } = new();

    public List<EftEffect> Effects { get; set; } = new();

    public List<EftEffectSequence> EffectSequences { get; set; } = new();

    [JsonIgnore]
    public override string Extension => "EFT";

    protected override void Read(SBinaryReader binaryReader)
    {
        var signature = binaryReader.ReadString(3);

        Format = signature switch
        {
            "EFT" => EftFormat.EFT,
            "EF2" => EftFormat.EF2,
            "EF3" => EftFormat.EF3,
            _ => EftFormat.Unknown
        };

        // Effect instances expect the Format to be set as the ExtraOption property on the serialization settings
        binaryReader.SerializationOptions.ExtraOption = Format;

        Meshes = binaryReader.ReadList<EftEffectMesh>().ToList();
        Textures = binaryReader.ReadList<EftTexture>().ToList();
        Effects = binaryReader.ReadList<EftEffect>().ToList();
        EffectSequences = binaryReader.ReadList<EftEffectSequence>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        var signature = Format switch
        {
            EftFormat.EFT => "EFT",
            EftFormat.EF2 => "EF2",
            EftFormat.EF3 => "EF3",
            _ => "EFT"
        };

        // Effect instances expect the Format to be set as the ExtraOption property on the serialization settings
        binaryWriter.SerializationOptions.ExtraOption = Format;

        binaryWriter.Write(signature, isLengthPrefixed: false, includeStringTerminator: false);
        binaryWriter.Write(Meshes.ToSerializable());
        binaryWriter.Write(Textures.ToSerializable());
        binaryWriter.Write(Effects.ToSerializable());
        binaryWriter.Write(EffectSequences.ToSerializable());
    }
}
