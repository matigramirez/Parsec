using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT;

public sealed class Rotation : IBinary
{
    [JsonConstructor]
    public Rotation()
    {
    }

    public Rotation(SBinaryReader binaryReader)
    {
        Quaternion = new Quaternion(binaryReader);
        Time = binaryReader.Read<float>();
    }

    public Quaternion Quaternion { get; set; }
    public float Time { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Quaternion.GetBytes());
        buffer.AddRange(Time.GetBytes());
        return buffer;
    }
}
