using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT;

public sealed class EffectSequence : IBinary
{
    [JsonConstructor]
    public EffectSequence()
    {
    }

    public EffectSequence(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString();

        int recordCount = binaryReader.Read<int>();
        for (int i = 0; i < recordCount; i++)
        {
            var record = new SequenceRecord(binaryReader);
            Records.Add(record);
        }
    }

    public string Name { get; set; }
    public List<SequenceRecord> Records { get; } = new();

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Name.GetLengthPrefixedBytes());
        buffer.AddRange(Records.GetBytes());
        return buffer;
    }
}
