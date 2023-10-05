using Parsec.Common;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class QuestResult : ISerializable
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

    public void Read(SBinaryReader binaryReader)
    {
        NeedMobId = binaryReader.ReadUInt16();
        NeedMobCount = binaryReader.ReadByte();
        NeedItemId = binaryReader.ReadByte();
        NeedItemCount = binaryReader.ReadByte();
        NeedTime = binaryReader.ReadUInt32();
        NeedHG = binaryReader.ReadUInt16();
        NeedVG = binaryReader.ReadInt16();
        NeedOG = binaryReader.ReadByte();
        Exp = binaryReader.ReadUInt32();
        Money = binaryReader.ReadUInt32();
        ItemType1 = binaryReader.ReadByte();
        ItemTypeId1 = binaryReader.ReadByte();

        if (binaryReader.SerializationOptions.Episode > Episode.EP5)
        {
            ItemCount1 = binaryReader.ReadByte();
            ItemType2 = binaryReader.ReadByte();
            ItemTypeId2 = binaryReader.ReadByte();
            ItemCount2 = binaryReader.ReadByte();
            ItemType3 = binaryReader.ReadByte();
            ItemTypeId3 = binaryReader.ReadByte();
            ItemCount3 = binaryReader.ReadByte();
        }

        NextQuestId = binaryReader.ReadUInt16();

        if (binaryReader.SerializationOptions.Episode < Episode.EP8)
        {
            CompletionMessage = binaryReader.ReadString();
        }
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(NeedMobId);
        binaryWriter.Write(NeedMobCount);
        binaryWriter.Write(NeedItemId);
        binaryWriter.Write(NeedItemCount);
        binaryWriter.Write(NeedTime);
        binaryWriter.Write(NeedHG);
        binaryWriter.Write(NeedVG);
        binaryWriter.Write(NeedOG);
        binaryWriter.Write(Exp);
        binaryWriter.Write(Money);
        binaryWriter.Write(ItemType1);
        binaryWriter.Write(ItemTypeId1);

        if (binaryWriter.SerializationOptions.Episode > Episode.EP5)
        {
            binaryWriter.Write(ItemCount1);
            binaryWriter.Write(ItemType2);
            binaryWriter.Write(ItemTypeId2);
            binaryWriter.Write(ItemCount2);
            binaryWriter.Write(ItemType3);
            binaryWriter.Write(ItemTypeId3);
            binaryWriter.Write(ItemCount3);
        }

        binaryWriter.Write(NextQuestId);
    }
}
