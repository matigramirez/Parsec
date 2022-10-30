using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class QuestResult : IBinary
{
    public ushort NeedMobId { get; set; }
    public byte NeedMobCount { get; set; }
    public byte NeedItemId { get; set; }
    public byte NeedItemCount { get; set; }
    public uint NeedTime { get; set; }
    public ushort NeedHG { get; set; }
    public short NeedVG { get; set; }
    public byte NeedOG { get; set; }
    public uint Exp { get; set; }
    public uint Money { get; set; }
    public byte ItemType1 { get; set; }
    public byte ItemTypeId1 { get; set; }
    public byte ItemCount1 { get; set; }
    public byte ItemType2 { get; set; }
    public byte ItemTypeId2 { get; set; }
    public byte ItemCount2 { get; set; }
    public byte ItemType3 { get; set; }
    public byte ItemTypeId3 { get; set; }
    public byte ItemCount3 { get; set; }
    public ushort NextQuestId { get; set; }

    public string CompletionMessage { get; set; } = string.Empty;

    public QuestResult(SBinaryReader binaryReader, Episode episode)
    {
        NeedMobId = binaryReader.Read<ushort>();
        NeedMobCount = binaryReader.Read<byte>();
        NeedItemId = binaryReader.Read<byte>();
        NeedItemCount = binaryReader.Read<byte>();
        NeedTime = binaryReader.Read<uint>();
        NeedHG = binaryReader.Read<ushort>();
        NeedVG = binaryReader.Read<short>();
        NeedOG = binaryReader.Read<byte>();
        Exp = binaryReader.Read<uint>();
        Money = binaryReader.Read<uint>();
        ItemType1 = binaryReader.Read<byte>();
        ItemTypeId1 = binaryReader.Read<byte>();

        // Some extra values are read here for EP6+
        if (episode > Episode.EP5)
        {
            ItemCount1 = binaryReader.Read<byte>();

            ItemType2 = binaryReader.Read<byte>();
            ItemTypeId2 = binaryReader.Read<byte>();
            ItemCount2 = binaryReader.Read<byte>();

            ItemType3 = binaryReader.Read<byte>();
            ItemTypeId3 = binaryReader.Read<byte>();
            ItemCount3 = binaryReader.Read<byte>();
        }

        NextQuestId = binaryReader.Read<ushort>();
    }

    [JsonConstructor]
    public QuestResult()
    {
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var episode = Episode.EP5;

        if (options.Length > 0)
            episode = (Episode)options[0];

        var buffer = new List<byte>();
        buffer.AddRange(NeedMobId.GetBytes());
        buffer.Add(NeedMobCount);
        buffer.Add(NeedItemId);
        buffer.Add(NeedItemCount);
        buffer.AddRange(NeedTime.GetBytes());
        buffer.AddRange(NeedHG.GetBytes());
        buffer.AddRange(NeedVG.GetBytes());
        buffer.Add(NeedOG);
        buffer.AddRange(Exp.GetBytes());
        buffer.AddRange(Money.GetBytes());
        buffer.Add(ItemType1);
        buffer.Add(ItemTypeId1);

        if (episode > Episode.EP5)
        {
            buffer.Add(ItemCount1);

            buffer.Add(ItemType2);
            buffer.Add(ItemTypeId2);
            buffer.Add(ItemCount2);

            buffer.Add(ItemType3);
            buffer.Add(ItemTypeId3);
            buffer.Add(ItemCount3);
        }

        buffer.AddRange(NextQuestId.GetBytes());
        return buffer;
    }
}
