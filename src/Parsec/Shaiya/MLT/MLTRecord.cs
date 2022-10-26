using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MLT;

public sealed class MLTRecord : IBinary
{
    [JsonConstructor]
    public MLTRecord()
    {
    }

    public MLTRecord(SBinaryReader binaryReader)
    {
        Obj3DCIndex = binaryReader.Read<int>();
        TextureIndex = binaryReader.Read<int>();
        Alpha = binaryReader.Read<int>();
    }

    /// <summary>
    /// Index of the .3DC filename
    /// </summary>
    public int Obj3DCIndex { get; set; }

    /// <summary>
    /// Index of the .DDS filename
    /// </summary>
    public int TextureIndex { get; set; }

    /// <summary>
    /// Alpha channel flag. 0: visibility  1: glow
    /// </summary>
    public int Alpha { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Obj3DCIndex.GetBytes());
        buffer.AddRange(TextureIndex.GetBytes());
        buffer.AddRange(Alpha.GetBytes());
        return buffer;
    }
}
