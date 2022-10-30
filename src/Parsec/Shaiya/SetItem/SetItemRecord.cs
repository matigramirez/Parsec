using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SetItem;

public sealed class SetItemRecord : IBinary
{
    [JsonConstructor]
    public SetItemRecord()
    {
    }

    public SetItemRecord(SBinaryReader binaryReader)
    {
        Index = binaryReader.Read<short>();
        Name = binaryReader.ReadString();

        for (int i = 0; i < 13; i++)
            Items.Add(new SetItemItem(binaryReader));

        for (int i = 0; i < 13; i++)
        {
            string synergy = binaryReader.ReadString();
            Synergies.Add(synergy);
        }
    }

    public short Index { get; set; }
    public string Name { get; set; }
    public List<SetItemItem> Items { get; } = new();
    public List<string> Synergies { get; } = new();

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Index.GetBytes());
        buffer.AddRange(Name.GetLengthPrefixedBytes());

        foreach (var item in Items.Take(13))
            buffer.AddRange(item.GetBytes());

        foreach (string synergy in Synergies.Take(13))
            buffer.AddRange(synergy.GetLengthPrefixedBytes());

        return buffer;
    }
}
