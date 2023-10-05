using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.KillStatus;

public sealed class KillStatusRecord : ISerializable
{
    /// <summary>
    /// The faction that will receive the bonus
    /// </summary>
    public KillStatusFaction Faction { get; set; }

    /// <summary>
    /// The absolute bless value at which the bonuses will take effect
    /// </summary>
    public int BlessValue { get; set; }

    /// <summary>
    /// The index of this record
    /// </summary>
    public ushort Index { get; set; }

    /// <summary>
    /// The bonuses to be applied (fixed length of 6)
    /// </summary>
    public List<KillStatusBonus> Bonuses { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Faction = (KillStatusFaction)binaryReader.ReadByte();
        BlessValue = binaryReader.ReadInt32();
        Index = binaryReader.ReadUInt16();
        Bonuses = binaryReader.ReadList<KillStatusBonus>(6).ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write((byte)Faction);
        binaryWriter.Write(BlessValue);
        binaryWriter.Write(Index);
        binaryWriter.Write(Bonuses.ToSerializable());
    }
}
