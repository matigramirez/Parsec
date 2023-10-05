using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.GuildHouse;

public sealed class GuildHouse : SData.SData
{
    public int Unknown { get; set; }

    public int HousePrice { get; set; }

    public int ServicePrice { get; set; }

    /// <summary>
    /// Npc detail list. 36 elements
    /// </summary>
    public List<GuildHouseNpcInfo> NpcInfoList { get; set; } = new();

    /// <summary>
    /// Npc Id list. 24 elements
    /// </summary>
    public List<GuildHouseNpc> Npcs { get; set; } = new();

    /// <inheritdoc />
    protected override void Read(SBinaryReader binaryReader)
    {
        Unknown = binaryReader.ReadInt32();
        HousePrice = binaryReader.ReadInt32();
        ServicePrice = binaryReader.ReadInt32();
        NpcInfoList = binaryReader.ReadList<GuildHouseNpcInfo>(36).ToList();
        Npcs = binaryReader.ReadList<GuildHouseNpc>(24).ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Unknown);
        binaryWriter.Write(HousePrice);
        binaryWriter.Write(ServicePrice);
        binaryWriter.Write(NpcInfoList.ToSerializable());
        binaryWriter.Write(Npcs.ToSerializable());
    }
}
