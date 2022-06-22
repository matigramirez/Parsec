using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Seff;

public class Record : IBinary
{
    public int Id { get; set; }
    public List<Effect> Effects { get; } = new();

    [JsonConstructor]
    public Record()
    {
    }

    public Record(SBinaryReader binaryReader, int format)
    {
        Id = binaryReader.Read<int>();

        var effectCount = binaryReader.Read<int>();

        for (int i = 0; i < effectCount; i++)
        {
            var effect = new Effect(binaryReader, format);
            Effects.Add(effect);
        }
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        int format = 0;

        var buffer = new List<byte>();

        if (options.Length > 0)
            format = (int)options[0];

        buffer.AddRange(Id.GetBytes());
        buffer.AddRange(Effects.Count.GetBytes());

        foreach (var effectInfo in Effects)
            buffer.AddRange(effectInfo.GetBytes(format));

        return buffer;
    }
}
