using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.KillStatus;

public sealed class KillStatusBonus : ISerializable
{
    public KillStatusBonusType BonusType { get; set; }

    public ushort BonusValue { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        BonusType = (KillStatusBonusType)binaryReader.ReadByte();
        BonusValue = binaryReader.ReadUInt16();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write((byte)BonusType);
        binaryWriter.Write(BonusValue);
    }
}
