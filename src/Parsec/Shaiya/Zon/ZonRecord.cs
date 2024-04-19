using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Zon;

public sealed class ZonRecord : ISerializable
{
    public byte Index { get; set; }

    public byte P1 { get; set; }

    /// <summary>
    /// Present only if Format > 2
    /// </summary>
    public byte P2 { get; set; }

    public Vector3 Coordinates1 { get; set; } = new();

    public Vector3 Coordinates2 { get; set; } = new();

    /// <summary>
    /// Present only if Format > 2
    /// </summary>
    public Vector3 Coordinates3 { get; set; } = new();

    /// <summary>
    /// Present only if Format > 2
    /// </summary>
    public Vector3 Coordinates4 { get; set; } = new();

    /// <summary>
    /// Present only if Format > 2
    /// </summary>
    public float Unknown1 { get; set; }

    /// <summary>
    /// Present only if Format > 2
    /// </summary>
    public float Unknown2 { get; set; }

    public ushort MapId { get; set; }

    public string Description { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        var format = 0;

        if (binaryReader.SerializationOptions.ExtraOption is int optionFormat)
        {
            format = optionFormat;
        }

        Index = binaryReader.ReadByte();
        P1 = binaryReader.ReadByte();

        if (format > 2)
        {
            P2 = binaryReader.ReadByte();
        }

        Coordinates1 = binaryReader.Read<Vector3>();
        Coordinates2 = binaryReader.Read<Vector3>();

        if (format > 2)
        {
            Coordinates3 = binaryReader.Read<Vector3>();
            Coordinates4 = binaryReader.Read<Vector3>();
            Unknown1 = binaryReader.ReadSingle();
            Unknown2 = binaryReader.ReadSingle();
        }

        MapId = binaryReader.ReadUInt16();
        Description = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var format = 0;

        if (binaryWriter.SerializationOptions.ExtraOption is int optionFormat)
        {
            format = optionFormat;
        }

        binaryWriter.Write(Index);
        binaryWriter.Write(P1);

        if (format > 2)
        {
            binaryWriter.Write(P2);
        }

        binaryWriter.Write(Coordinates1);
        binaryWriter.Write(Coordinates2);

        if (format > 2)
        {
            binaryWriter.Write(Coordinates3);
            binaryWriter.Write(Coordinates4);
            binaryWriter.Write(Unknown1);
            binaryWriter.Write(Unknown2);
        }

        binaryWriter.Write(MapId);
        binaryWriter.Write(Description);
    }
}
