using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// A circular area of the world in which music is played
/// </summary>
public sealed class WldSoundEffect : ISerializable
{
    /// <summary>
    /// Id of the wav file (from the linked name list of files)
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The center point of the circle
    /// </summary>
    public Vector3 Center { get; set; } = new();

    /// <summary>
    /// The radius of the circle
    /// </summary>
    public float Radius { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt32();
        Center = binaryReader.Read<Vector3>();
        Radius = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.Write(Center);
        binaryWriter.Write(Radius);
    }
}
