using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class QuestItem : IBinary
{
    public byte Type { get; set; }
    public byte TypeId { get; set; }
    public byte Count { get; set; }

    [JsonConstructor]
    public QuestItem()
    {
    }

    public QuestItem(SBinaryReader binaryReader)
    {
        Type = binaryReader.Read<byte>();
        TypeId = binaryReader.Read<byte>();
        Count = binaryReader.Read<byte>();
    }

    public IEnumerable<byte> GetBytes(params object[] options) => new[] { Type, TypeId, Count };
}
