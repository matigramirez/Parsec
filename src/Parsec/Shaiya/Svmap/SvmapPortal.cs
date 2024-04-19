using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class SvmapPortal : ISerializable
{
    public Vector3 PortalPosition { get; set; } = new();

    public int FactionOrPortalId { get; set; }

    public ushort MinLevel { get; set; }

    public ushort MaxLevel { get; set; }

    public uint TargetMapId { get; set; }

    public Vector3 TargetMapPosition { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        PortalPosition = binaryReader.Read<Vector3>();
        FactionOrPortalId = binaryReader.ReadInt32();
        MinLevel = binaryReader.ReadUInt16();
        MaxLevel = binaryReader.ReadUInt16();
        TargetMapId = binaryReader.ReadUInt32();
        TargetMapPosition = binaryReader.Read<Vector3>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(PortalPosition);
        binaryWriter.Write(FactionOrPortalId);
        binaryWriter.Write(MinLevel);
        binaryWriter.Write(MaxLevel);
        binaryWriter.Write(TargetMapId);
        binaryWriter.Write(TargetMapPosition);
    }
}
