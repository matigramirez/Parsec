using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Mlt;

public sealed class Mlt : FileBase
{
    /// <summary>
    /// File Signature. Read as char[3]
    /// </summary>
    public string Signature { get; set; } = string.Empty;

    /// <summary>
    /// List of .3DC object names
    /// </summary>
    public List<string> MeshNames { get; set; } = new();

    /// <summary>
    ///  List of .dds texture names
    /// </summary>
    public List<string> TextureNames { get; set; } = new();

    /// <summary>
    /// List of MLT records
    /// </summary>
    public List<MltRecord> Records { get; set; } = new();

    public override string Extension => "MLT";

    protected override void Read(SBinaryReader binaryReader)
    {
        Signature = binaryReader.ReadString(3);

        var meshNameCount = binaryReader.ReadInt32();
        for (var i = 0; i < meshNameCount; i++)
        {
            var meshName = binaryReader.ReadString();
            MeshNames.Add(meshName);
        }

        int textureNameCount = binaryReader.ReadInt32();
        for (int i = 0; i < textureNameCount; i++)
        {
            string textureName = binaryReader.ReadString();
            TextureNames.Add(textureName);
        }

        Records = binaryReader.ReadList<MltRecord>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Signature);

        binaryWriter.Write(MeshNames.Count);
        foreach (var meshName in MeshNames)
        {
            binaryWriter.WriteLengthPrefixedString(meshName);
        }

        binaryWriter.Write(TextureNames.Count);
        foreach (var textureName in TextureNames)
        {
            binaryWriter.WriteLengthPrefixedString(textureName);
        }

        binaryWriter.Write(Records.ToSerializable());
    }
}
