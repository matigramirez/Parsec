using Parsec.Common;
using Parsec.Serialization;

namespace Parsec.Shaiya.NpcQuest;

public abstract class BaseNpc
{
    public NpcType NpcType { get; set; }

    public short NpcTypeId { get; set; }

    public int Model { get; set; }

    public int MoveDistance { get; set; }

    public int MoveSpeed { get; set; }

    public NpcFaction Faction { get; set; }

    public string Name { get; set; } = string.Empty;

    public string WelcomeMessage { get; set; } = string.Empty;

    public List<short> InQuestIds { get; set; } = new();

    public List<short> OutQuestIds { get; set; } = new();

    protected void ReadNpcBaseComplete(SBinaryReader binaryReader)
    {
        ReadBaseNpcFirstSegment(binaryReader);
        ReadBaseNpcSecondSegment(binaryReader);
        ReadBaseNpcThirdSegment(binaryReader);
    }

    protected void ReadBaseNpcFirstSegment(SBinaryReader binaryReader)
    {
        NpcType = (NpcType)binaryReader.ReadByte();
        NpcTypeId = binaryReader.ReadInt16();
    }

    protected void WriteBaseNpcFirstSegment(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write((byte)NpcType);
        binaryWriter.Write(NpcTypeId);
    }

    protected void ReadBaseNpcSecondSegment(SBinaryReader binaryReader)
    {
        Model = binaryReader.ReadInt32();
        MoveDistance = binaryReader.ReadInt32();
        MoveSpeed = binaryReader.ReadInt32();
        Faction = (NpcFaction)binaryReader.ReadInt32();

        // In Ep8 strings are stored in separate translation files
        if (binaryReader.SerializationOptions.Episode < Episode.EP8)
        {
            Name = binaryReader.ReadString(false);
            WelcomeMessage = binaryReader.ReadString(false);
        }
    }

    protected void WriteBaseNpcSecondSegment(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Model);
        binaryWriter.Write(MoveDistance);
        binaryWriter.Write(MoveSpeed);
        binaryWriter.Write((int)Faction);

        // In Ep8 strings are stored in separate translation files
        if (binaryWriter.SerializationOptions.Episode < Episode.EP8)
        {
            binaryWriter.Write(Name, false);
            binaryWriter.Write(WelcomeMessage, false);
        }
    }

    protected void ReadBaseNpcThirdSegment(SBinaryReader binaryReader)
    {
        var inQuestQuantity = binaryReader.ReadInt32();

        for (var i = 0; i < inQuestQuantity; i++)
        {
            var questId = binaryReader.ReadInt16();
            InQuestIds.Add(questId);
        }

        var outQuestQuantity = binaryReader.ReadInt32();

        for (var i = 0; i < outQuestQuantity; i++)
        {
            var questId = binaryReader.ReadInt16();
            OutQuestIds.Add(questId);
        }
    }

    protected void WriteBaseNpcThirdSegment(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(InQuestIds.Count);
        foreach (var inQuestId in InQuestIds)
        {
            binaryWriter.Write(inQuestId);
        }

        binaryWriter.Write(OutQuestIds.Count);
        foreach (var outQuestId in OutQuestIds)
        {
            binaryWriter.Write(outQuestId);
        }
    }

    protected void WriteNpcBaseComplete(SBinaryWriter binaryWriter)
    {
        WriteBaseNpcFirstSegment(binaryWriter);
        WriteBaseNpcSecondSegment(binaryWriter);
        WriteBaseNpcThirdSegment(binaryWriter);
    }
}
