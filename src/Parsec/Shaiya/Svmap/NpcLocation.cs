using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class NpcLocation : IBinary
{
    [JsonConstructor]
    public NpcLocation()
    {
    }

    public NpcLocation(SBinaryReader binaryReader)
    {
        Position = new Vector3(binaryReader);
        Orientation = binaryReader.Read<float>();
    }

    public Vector3 Position { get; set; }
    public float Orientation { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Position.GetBytes());
        buffer.AddRange(Orientation.GetBytes());
        return buffer;
    }
}
