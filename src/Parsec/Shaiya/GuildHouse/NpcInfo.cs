using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.GuildHouse;

public class NpcInfo : IBinary
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

    [JsonConstructor]
    public NpcInfo()
    {
    }

    public NpcInfo(SBinaryReader binaryReader)
    {
        PriceRate = binaryReader.Read<byte>();
        NpcLvl = binaryReader.Read<byte>();
        RapiceMixPercentRate = binaryReader.Read<byte>();
        RapiceMixDecreRate = binaryReader.Read<byte>();
        MinRank = binaryReader.Read<byte>();
        Icon = binaryReader.Read<ushort>();
        SysMsgId = binaryReader.Read<ushort>();
        UpPrice = binaryReader.Read<ushort>();
        ServicePrice = binaryReader.Read<ushort>();
        NpcType = binaryReader.Read<byte>();
        Group = binaryReader.Read<byte>();
    }

    /// <inheritdoc />
    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.Add(PriceRate);
        buffer.Add(NpcLvl);
        buffer.Add(RapiceMixPercentRate);
        buffer.Add(RapiceMixDecreRate);
        buffer.Add(MinRank);
        buffer.AddRange(Icon.GetBytes());
        buffer.AddRange(SysMsgId.GetBytes());
        buffer.AddRange(UpPrice.GetBytes());
        buffer.AddRange(ServicePrice.GetBytes());
        buffer.Add(NpcType);
        buffer.Add(Group);
        return buffer;
    }
}
