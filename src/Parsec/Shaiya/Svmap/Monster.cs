using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class Monster : IBinary
{
    [JsonConstructor]
    public Monster()
    {
    }

    public Monster(SBinaryReader binaryReader)
    {
        MobId = binaryReader.Read<int>();
        Count = binaryReader.Read<int>();
    }

    public int MobId { get; set; }
    public int Count { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(MobId.GetBytes());
        buffer.AddRange(Count.GetBytes());
        return buffer;
    }
}
