using Parsec.Common;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class GateTarget : ISerializable
{
    public ushort MapId { get; set; }

    public Vector3 Position { get; set; }

    public string TargetName { get; set; } = string.Empty;

    /// <summary>
    /// Teleporting gold cost
    /// </summary>
    public uint Cost { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        MapId = binaryReader.ReadUInt16();
        Position = binaryReader.Read<Vector3>();

        if (binaryReader.SerializationOptions.Episode < Episode.EP8)
        {
            TargetName = binaryReader.ReadString();
        }

        Cost = binaryReader.ReadUInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(MapId);
        binaryWriter.Write(Position);

        if (binaryWriter.SerializationOptions.Episode < Episode.EP8)
        {
            binaryWriter.Write(TargetName);
        }

        binaryWriter.Write(Cost);
    }
}
