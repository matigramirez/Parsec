using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public class Monster : IBinary
{
    public int MobId { get; set; }
    public int Count { get; set; }

    [JsonConstructor]
    public Monster()
    {
    }

    public Monster(SBinaryReader binaryReader)
    {
        MobId = binaryReader.Read<int>();
        Count = binaryReader.Read<int>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(MobId.GetBytes());
        buffer.AddRange(Count.GetBytes());
        return buffer;
    }
}
