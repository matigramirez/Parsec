using System.Text.Json.Serialization;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class Svmap : FileBase
{
    public int MapSize { get; set; }

    /// <summary>
    /// This array should be interpreted as a 1-bit array and its size is equal to <see cref="MapSize"/> * <see cref="MapSize"/> / 8.
    /// The information in this bit array is used to determine which (x,z) coordinates are accessible by monsters and which aren't.
    /// A value of 0 represents an accessible (x,z) coordinate, whereas a value of 1 represents an inaccessible (x,z) coordinate.
    /// Even though this information is available for all map types, it's used mostly for dungeons, where mobs need to stay within
    /// the dungeon's wall limits.
    /// </summary>
    public byte[] MapMask { get; set; } = Array.Empty<byte>();

    public int CellSize { get; set; }

    public List<SvmapLadder> Ladders { get; set; } = new();

    public List<SvmapMonsterSpawnArea> MonsterAreas { get; set; } = new();

    public List<SvmapNpc> Npcs { get; set; } = new();

    public List<SvmapPortal> Portals { get; set; } = new();

    public List<SvmapSpawnArea> Spawns { get; set; } = new();

    public List<SvmapNamedArea> NamedAreas { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        MapSize = binaryReader.ReadInt32();

        var mapMaskLength = MapSize * MapSize / 8;
        MapMask = binaryReader.ReadBytes(mapMaskLength);

        CellSize = binaryReader.ReadInt32();
        Ladders = binaryReader.ReadList<SvmapLadder>().ToList();
        MonsterAreas = binaryReader.ReadList<SvmapMonsterSpawnArea>().ToList();
        Npcs = binaryReader.ReadList<SvmapNpc>().ToList();
        Portals = binaryReader.ReadList<SvmapPortal>().ToList();
        Spawns = binaryReader.ReadList<SvmapSpawnArea>().ToList();
        NamedAreas = binaryReader.ReadList<SvmapNamedArea>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(MapSize);
        binaryWriter.Write(MapMask.ToArray());
        binaryWriter.Write(CellSize);
        binaryWriter.Write(Ladders.ToSerializable());
        binaryWriter.Write(MonsterAreas.ToSerializable());
        binaryWriter.Write(Npcs.ToSerializable());
        binaryWriter.Write(Portals.ToSerializable());
        binaryWriter.Write(Spawns.ToSerializable());
        binaryWriter.Write(NamedAreas.ToSerializable());
    }
}
