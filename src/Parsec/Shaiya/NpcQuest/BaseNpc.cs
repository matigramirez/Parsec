using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public abstract class BaseNpc : IBinary
{
    public NpcType Type { get; set; }
    public short TypeId { get; set; }
    public int Model { get; set; }
    public int MoveDistance { get; set; }
    public int MoveSpeed { get; set; }
    public NpcFaction Faction { get; set; }
    public string Name { get; set; }
    public string WelcomeMessage { get; set; }

    public List<short> InQuestIds { get; } = new();
    public List<short> OutQuestIds { get; } = new();

    protected void ReadNpcBaseComplete(SBinaryReader binaryReader, Episode episode)
    {
        ReadBaseNpcFirstSegment(binaryReader);
        ReadBaseNpcSecondSegment(binaryReader, episode);
        ReadBaseNpcThirdSegment(binaryReader);
    }

    protected void ReadBaseNpcFirstSegment(SBinaryReader binaryReader)
    {
        Type = (NpcType)binaryReader.Read<byte>();
        TypeId = binaryReader.Read<short>();
    }

    protected void WriteBaseNpcFirstSegmentBytes(List<byte> buffer)
    {
        buffer.Add((byte)Type);
        buffer.AddRange(TypeId.GetBytes());
    }

    protected void ReadBaseNpcSecondSegment(SBinaryReader binaryReader, Episode episode)
    {
        Model = binaryReader.Read<int>();
        MoveDistance = binaryReader.Read<int>();
        MoveSpeed = binaryReader.Read<int>();
        Faction = (NpcFaction)binaryReader.Read<int>();

        if (episode < Episode.EP8) // In ep 8, messages are moved to separate translation files.
        {
            Name = binaryReader.ReadString(false);
            WelcomeMessage = binaryReader.ReadString(false);
        }
    }

    protected void WriteBaseNpcSecondSegmentBytes(List<byte> buffer, Episode episode)
    {
        buffer.AddRange(Model.GetBytes());
        buffer.AddRange(MoveDistance.GetBytes());
        buffer.AddRange(MoveSpeed.GetBytes());
        buffer.AddRange(((int)Faction).GetBytes());

        if (episode < Episode.EP8) // In ep 8, messages are moved to separate translation files.
        {
            buffer.AddRange(Name.GetLengthPrefixedBytes(false));
            buffer.AddRange(WelcomeMessage.GetLengthPrefixedBytes(false));
        }
    }

    protected void ReadBaseNpcThirdSegment(SBinaryReader binaryReader)
    {
        int inQuestQuantity = binaryReader.Read<int>();

        for (int i = 0; i < inQuestQuantity; i++)
        {
            short questId = binaryReader.Read<short>();
            InQuestIds.Add(questId);
        }

        int outQuestQuantity = binaryReader.Read<int>();

        for (int i = 0; i < outQuestQuantity; i++)
        {
            short questId = binaryReader.Read<short>();
            OutQuestIds.Add(questId);
        }
    }

    protected void WriteBaseNpcThirdSegmentBytes(List<byte> buffer)
    {
        buffer.AddRange(InQuestIds.Count.GetBytes());

        foreach (short inQuestId in InQuestIds)
            buffer.AddRange(inQuestId.GetBytes());

        buffer.AddRange(OutQuestIds.Count.GetBytes());

        foreach (short outQuestId in OutQuestIds)
            buffer.AddRange(outQuestId.GetBytes());
    }

    public virtual IEnumerable<byte> GetBytes(params object[] options)
    {
        var episode = Episode.EP5;

        if (options.Length > 0)
            episode = (Episode)options[0];

        var buffer = new List<byte>();
        WriteBaseNpcFirstSegmentBytes(buffer);
        WriteBaseNpcSecondSegmentBytes(buffer, episode);
        WriteBaseNpcThirdSegmentBytes(buffer);
        return buffer;
    }
}
