using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MLT;

public sealed class MLT : FileBase
{
    /// <summary>
    /// File Signature. Read as char[3]
    /// </summary>
    public string Signature { get; set; }

    /// <summary>
    /// List of .3DC object names
    /// </summary>
    public List<string> Obj3DCNames { get; } = new();

    /// <summary>
    ///  List of .dds texture names
    /// </summary>
    public List<string> TextureNames { get; } = new();

    /// <summary>
    /// List of MLT records
    /// </summary>
    public List<MLTRecord> Records { get; } = new();

    public override string Extension => "MLT";

    public override void Read(params object[] options)
    {
        Signature = _binaryReader.ReadString(3);

        int obj3dcCount = _binaryReader.Read<int>();
        for (int i = 0; i < obj3dcCount; i++)
        {
            string obj3dcName = _binaryReader.ReadString();
            Obj3DCNames.Add(obj3dcName);
        }

        int textureNameCount = _binaryReader.Read<int>();
        for (int i = 0; i < textureNameCount; i++)
        {
            string textureName = _binaryReader.ReadString();
            TextureNames.Add(textureName);
        }

        int recordCount = _binaryReader.Read<int>();
        for (int i = 0; i < recordCount; i++)
        {
            var record = new MLTRecord(_binaryReader);
            Records.Add(record);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Signature.GetBytes());

        buffer.AddRange(Obj3DCNames.Count.GetBytes());
        foreach (string obj3dcName in Obj3DCNames)
            buffer.AddRange(obj3dcName.GetLengthPrefixedBytes());

        buffer.AddRange(TextureNames.Count.GetBytes());
        foreach (string textureName in TextureNames)
            buffer.AddRange(textureName.GetLengthPrefixedBytes());

        buffer.AddRange(Records.GetBytes());
        return buffer;
    }
}
