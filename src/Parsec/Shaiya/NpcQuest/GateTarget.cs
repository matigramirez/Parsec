using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class GateTarget : IBinary
{
    public short MapId { get; set; }
    public Vector3 Position { get; set; }
    public string TargetName { get; set; }

    /// <summary>
    /// Teleporting gold cost
    /// </summary>
    public int Cost { get; set; }

    public GateTarget(SBinaryReader binaryReader, Episode episode)
    {
        MapId = binaryReader.Read<short>();
        Position = new Vector3(binaryReader);

        if (episode < Episode.EP8) // In ep 8, messages are moved to separate translation files.
            TargetName = binaryReader.ReadString(false);

        Cost = binaryReader.Read<int>();
    }

    [JsonConstructor]
    public GateTarget()
    {
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var episode = Episode.EP5;

        if (options.Length > 0)
            episode = (Episode)options[0];

        var buffer = new List<byte>();
        buffer.AddRange(MapId.GetBytes());
        buffer.AddRange(Position.GetBytes());

        if (episode < Episode.EP8) // In ep 8, messages are moved to separate translation files.
            buffer.AddRange(TargetName.GetLengthPrefixedBytes(false));

        buffer.AddRange(Cost.GetBytes());
        return buffer;
    }
}
