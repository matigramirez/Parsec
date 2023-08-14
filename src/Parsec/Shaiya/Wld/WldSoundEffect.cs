using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// A circular area of the world in which music is played
/// </summary>
public sealed class WldSoundEffect : IBinary
{
    /// <summary>
    /// Id of the wav file (from the linked name list of files)
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The center point of the circle
    /// </summary>
    public Vector3 Center { get; set; }

    /// <summary>
    /// The radius of the circle
    /// </summary>
    public float Radius { get; set; }

    [JsonConstructor]
    public WldSoundEffect()
    {
    }

    public WldSoundEffect(SBinaryReader binaryReader)
    {
        Id = binaryReader.Read<int>();
        Center = new Vector3(binaryReader);
        Radius = binaryReader.Read<float>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Id.GetBytes());
        buffer.AddRange(Center.GetBytes());
        buffer.AddRange(Radius.GetBytes());
        return buffer;
    }
}
