using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Seff;

public sealed class Record : IBinary
{
    [JsonConstructor]
    public Record()
    {
    }

    public Record(SBinaryReader binaryReader, int format)
    {
        Id = binaryReader.Read<int>();

        int effectCount = binaryReader.Read<int>();

        for (int i = 0; i < effectCount; i++)
        {
            var effect = new SeffEffect(binaryReader, format);
            Effects.Add(effect);
        }
    }

    public int Id { get; set; }
    public List<SeffEffect> Effects { get; } = new();

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        int format = 0;

        var buffer = new List<byte>();

        if (options.Length > 0)
            format = (int)options[0];

        buffer.AddRange(Id.GetBytes());
        buffer.AddRange(Effects.Count.GetBytes());
        foreach (var effect in Effects)
            buffer.AddRange(effect.GetBytes(format));

        return buffer;
    }
}
