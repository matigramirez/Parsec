using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class QuestItemLink : ISerializable
{
    public List<ushort> StartQuestIds { get; set; } = new();

    public List<ushort> EndQuestIds { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        var previousQuestIdCount = binaryReader.ReadInt32();

        for (int i = 0; i < previousQuestIdCount; i++)
        {
            StartQuestIds.Add(binaryReader.ReadUInt16());
        }

        var nextQuestIdCount = binaryReader.ReadInt32();

        for (int i = 0; i < nextQuestIdCount; i++)
        {
            EndQuestIds.Add(binaryReader.ReadUInt16());
        }
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(StartQuestIds.Count);

        foreach (var previousQuestId in StartQuestIds)
        {
            binaryWriter.Write(previousQuestId);
        }

        binaryWriter.Write(EndQuestIds.Count);

        foreach (var nextQuestId in EndQuestIds)
        {
            binaryWriter.Write(nextQuestId);
        }
    }
}
