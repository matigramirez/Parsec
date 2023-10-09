using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.GuildHouse;

public class GuildHouseNpcInfo : ISerializable
{
    public byte PriceRate { get; set; }

    public byte NpcLvl { get; set; }

    public byte RapiceMixPercentRate { get; set; }

    public byte RapiceMixDecreRate { get; set; }

    public byte MinRank { get; set; }

    public ushort Icon { get; set; }

    public ushort SysMsgId { get; set; }

    public ushort UpPrice { get; set; }

    public ushort ServicePrice { get; set; }

    public byte NpcType { get; set; }

    public byte Group { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        PriceRate = binaryReader.ReadByte();
        NpcLvl = binaryReader.ReadByte();
        RapiceMixPercentRate = binaryReader.ReadByte();
        RapiceMixDecreRate = binaryReader.ReadByte();
        MinRank = binaryReader.ReadByte();
        Icon = binaryReader.ReadUInt16();
        SysMsgId = binaryReader.ReadUInt16();
        UpPrice = binaryReader.ReadUInt16();
        ServicePrice = binaryReader.ReadUInt16();
        NpcType = binaryReader.ReadByte();
        Group = binaryReader.ReadByte();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(PriceRate);
        binaryWriter.Write(NpcLvl);
        binaryWriter.Write(RapiceMixPercentRate);
        binaryWriter.Write(RapiceMixDecreRate);
        binaryWriter.Write(MinRank);
        binaryWriter.Write(Icon);
        binaryWriter.Write(SysMsgId);
        binaryWriter.Write(UpPrice);
        binaryWriter.Write(ServicePrice);
        binaryWriter.Write(NpcType);
        binaryWriter.Write(Group);
    }
}
