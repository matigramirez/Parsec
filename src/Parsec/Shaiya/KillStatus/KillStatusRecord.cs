using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.KillStatus;

public class KillStatusRecord : IBinary
{
    public FactionInt Faction { get; set; }
    public int BlessValue { get; set; }
    public short Index { get; set; }
    public List<KillStatusBonus> Bonuses { get; } = new();

    [JsonConstructor]
    public KillStatusRecord()
    {
    }

    public KillStatusRecord(SBinaryReader binaryReader)
    {
        Faction = (FactionInt)binaryReader.Read<byte>();
        BlessValue = binaryReader.Read<int>();
        Index = binaryReader.Read<short>();

        for (int i = 0; i < 6; i++)
        {
            var bonus = new KillStatusBonus(binaryReader);
            Bonuses.Add(bonus);
        }
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();

        buffer.Add((byte)Faction);
        buffer.AddRange(BlessValue.GetBytes());
        buffer.AddRange(Index.GetBytes());

        foreach (var bonus in Bonuses)
            buffer.AddRange(bonus.GetBytes());

        return buffer;
    }
}
