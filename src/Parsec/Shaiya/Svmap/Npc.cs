using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class Npc : IBinary
{
    [JsonConstructor]
    public Npc()
    {
    }

    public Npc(SBinaryReader binaryReader)
    {
        Type = binaryReader.Read<int>();
        NpcId = binaryReader.Read<int>();

        var locationCount = binaryReader.Read<int>();

        for (int i = 0; i < locationCount; i++)
        {
            var npcLocation = new NpcLocation(binaryReader);
            Locations.Add(npcLocation);
        }
    }

    public int Type { get; set; }
    public int NpcId { get; set; }
    public List<NpcLocation> Locations { get; set; } = new();

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Type.GetBytes());
        buffer.AddRange(NpcId.GetBytes());
        buffer.AddRange(Locations.GetBytes());
        return buffer;
    }
}
