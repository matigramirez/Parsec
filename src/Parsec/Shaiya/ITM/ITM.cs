using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.ITM;

public sealed class ITM : FileBase
{
    /// <summary>
    /// File Signature. Read as char[3]. "ITM" or "IT2"
    /// </summary>
    public string Signature { get; set; }

    [JsonIgnore]
    public ITMFormat Format { get; set; }

    /// <summary>
    /// List of .3DO object names
    /// </summary>
    public List<string> Obj3DONames { get; } = new();

    /// <summary>
    ///  List of .dds texture names
    /// </summary>
    public List<string> TextureNames { get; } = new();

    /// <summary>
    /// List of ITM records
    /// </summary>
    public List<Record> Records { get; } = new();

    [JsonIgnore]
    public override string Extension => "ITM";

    public override void Read(params object[] options)
    {
        Signature = _binaryReader.ReadString(3);

        Format = Signature switch
        {
            "ITM" => ITMFormat.ITM,
            "IT2" => ITMFormat.IT2,
            _ => ITMFormat.Unknown
        };

        int obj3doCount = _binaryReader.Read<int>();
        for (int i = 0; i < obj3doCount; i++)
        {
            string obj3doName = _binaryReader.ReadString();
            Obj3DONames.Add(obj3doName);
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
            var record = new Record(Format, _binaryReader);
            Records.Add(record);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Signature.GetBytes());

        buffer.AddRange(Obj3DONames.Count.GetBytes());
        foreach (string obj3doName in Obj3DONames)
            buffer.AddRange(obj3doName.GetLengthPrefixedBytes());

        buffer.AddRange(TextureNames.Count.GetBytes());
        foreach (string textureName in TextureNames)
            buffer.AddRange(textureName.GetLengthPrefixedBytes());

        buffer.AddRange(Records.Count.GetBytes());
        foreach (var record in Records)
            buffer.AddRange(record.GetBytes(Format));

        return buffer;
    }
}
