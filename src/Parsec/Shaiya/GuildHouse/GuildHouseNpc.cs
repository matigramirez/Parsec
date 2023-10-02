using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.GuildHouse;

public class GuildHouseNpc : IBinary
{
    public int NpcId { get; set; }

    [JsonConstructor]
    public GuildHouseNpc()
    {
    }

    public GuildHouseNpc(SBinaryReader binaryReader)
    {
        NpcId = binaryReader.Read<int>();
    }

    /// <inheritdoc />
    public IEnumerable<byte> GetBytes(params object[] options) => NpcId.GetBytes();
}
