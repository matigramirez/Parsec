using System.Text.Json.Serialization;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public sealed class Wld : FileBase
{
    public WldType WldType { get; set; } = WldType.FLD;

    #region FLD Only fields

    /// <summary>
    /// Map Size, must be a power of 2 (1024 or 2048)
    /// </summary>
    public uint MapSize { get; set; }

    /// <summary>
    /// Map used for Y coordinate calculation based on X and Z
    /// </summary>
    public byte[] Heightmap { get; set; } = Array.Empty<byte>();

    /// <summary>
    /// Map used for texture usage based on X and Z
    /// </summary>
    public byte[] TextureMap { get; set; } = Array.Empty<byte>();

    public List<WldTexture> Textures { get; set; } = new();

    #endregion

    /// <summary>
    /// Fixed length string, length = 256. "inner layout", ".wtr" (water) for a field, ".dg" for a dungeon
    /// </summary>
    public String256 InnerLayout { get; set; } = string.Empty;

    /// <summary>
    /// Files from Entity/Building
    /// </summary>
    public List<String256> BuildingNames { get; set; } = new();

    public List<WldCoordinate> BuildingCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Entity/Shape
    /// </summary>
    public List<String256> ShapeNames { get; set; } = new();

    public List<WldCoordinate> ShapeCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Entity/Tree
    /// </summary>
    public List<String256> TreeNames { get; set; } = new();

    public List<WldCoordinate> TreeCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Entity/Grass
    /// </summary>
    public List<String256> GrassNames { get; set; } = new();

    public List<WldCoordinate> GrassCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Entity/VAni
    /// </summary>
    public List<String256> VAniNames1 { get; set; } = new();

    public List<WldCoordinate> VAniCoordinates1 { get; set; } = new();

    /// <summary>
    /// Files from Entity/VAni
    /// </summary>
    public List<String256> VAniNames2 { get; set; } = new();

    public List<WldCoordinate> VAniCoordinates2 { get; set; } = new();

    /// <summary>
    /// Files from World/dungeon
    /// </summary>
    public List<String256> DungeonNames { get; set; } = new();

    public List<WldCoordinate> DungeonCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Entity/MAni
    /// </summary>
    public List<String256> MAniNames { get; set; } = new();

    public List<WldManiCoordinate> MAniCoordinates { get; set; } = new();

    public String256 EffectName { get; set; } = string.Empty;

    /// <summary>
    /// Files from Effect/
    /// </summary>
    public List<WldEffect> Effects { get; set; } = new();

    public int Unknown1 { get; set; }

    public int Unknown2 { get; set; }

    public int Unknown3 { get; set; }

    /// <summary>
    /// Files from Entity/Object
    /// </summary>
    public List<String256> ObjectNames { get; set; } = new();

    public List<WldCoordinate> ObjectCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Sound/Music
    /// </summary>
    public List<String256> MusicNames { get; set; } = new();

    public List<WldMusicZone> MusicZones { get; set; } = new();

    /// <summary>
    /// Files from Sound/Music
    /// </summary>
    public List<String256> SoundEffectNames { get; set; } = new();

    public List<WldZone> Zones { get; set; } = new();

    public List<WldSoundEffect> SoundEffects { get; set; } = new();

    public List<WldUnknownBox> UnknownBoundingBoxes { get; set; } = new();

    public List<WldPortal> Portals { get; set; } = new();

    public List<WldSpawn> Spawns { get; set; } = new();

    public List<WldNamedArea> NamedAreas { get; set; } = new();

    public List<WldNpc> Npcs { get; set; } = new();

    #region FLD Only fields

    public String256 SkyName { get; set; } = string.Empty;

    public String256 CloudsName1 { get; set; } = string.Empty;

    public String256 CloudsName2 { get; set; } = string.Empty;

    #endregion

    public Vector3 Point1 { get; set; } = new();

    public Vector3 Point2 { get; set; } = new();

    public Vector3 Point3 { get; set; } = new();

    public float Unknown5 { get; set; }

    public float Unknown6 { get; set; }

    // This structure is incomplete, there's a bunch of unknown fields missing

    protected override void Read(SBinaryReader binaryReader)
    {
        var typeStr = binaryReader.ReadString(4);

        if (typeStr == "DUN")
        {
            WldType = WldType.DUN;
        }

        // FLD only fields
        if (WldType == WldType.FLD)
        {
            MapSize = binaryReader.ReadUInt32();

            var mappingSize = (int)Math.Pow(MapSize / 2f + 1, 2);
            Heightmap = binaryReader.ReadBytes(mappingSize * 2);
            TextureMap = binaryReader.ReadBytes(mappingSize);
            Textures = binaryReader.ReadList<WldTexture>().ToList();
        }

        InnerLayout = binaryReader.Read<String256>();

        ReadNamesAndCoordinates(binaryReader, BuildingNames, BuildingCoordinates);
        ReadNamesAndCoordinates(binaryReader, ShapeNames, ShapeCoordinates);
        ReadNamesAndCoordinates(binaryReader, TreeNames, TreeCoordinates);
        ReadNamesAndCoordinates(binaryReader, GrassNames, GrassCoordinates);
        ReadNamesAndCoordinates(binaryReader, VAniNames1, VAniCoordinates1);
        ReadNamesAndCoordinates(binaryReader, VAniNames2, VAniCoordinates2);
        ReadNamesAndCoordinates(binaryReader, DungeonNames, DungeonCoordinates);
        ReadNames(binaryReader, MAniNames);

        MAniCoordinates = binaryReader.ReadList<WldManiCoordinate>().ToList();
        EffectName = binaryReader.Read<String256>();
        Effects = binaryReader.ReadList<WldEffect>().ToList();

        Unknown1 = binaryReader.ReadInt32();
        Unknown2 = binaryReader.ReadInt32();
        Unknown3 = binaryReader.ReadInt32();

        ReadNamesAndCoordinates(binaryReader, ObjectNames, ObjectCoordinates);
        ReadNames(binaryReader, MusicNames);

        MusicZones = binaryReader.ReadList<WldMusicZone>().ToList();

        ReadNames(binaryReader, SoundEffectNames);

        Zones = binaryReader.ReadList<WldZone>().ToList();
        SoundEffects = binaryReader.ReadList<WldSoundEffect>().ToList();
        UnknownBoundingBoxes = binaryReader.ReadList<WldUnknownBox>().ToList();
        Portals = binaryReader.ReadList<WldPortal>().ToList();
        Spawns = binaryReader.ReadList<WldSpawn>().ToList();
        NamedAreas = binaryReader.ReadList<WldNamedArea>().ToList();

        // NOTE: npcCount is the real npc count + the patrol coordinates count
        var npcCount = binaryReader.ReadInt32();

        while (npcCount > 0)
        {
            var npc = binaryReader.Read<WldNpc>();
            Npcs.Add(npc);
            npcCount -= npc.PatrolCoordinates.Count;
            npcCount--;
        }

        if (WldType == WldType.FLD)
        {
            SkyName = binaryReader.Read<String256>();
            CloudsName1 = binaryReader.Read<String256>();
            CloudsName2 = binaryReader.Read<String256>();
        }

        Point1 = binaryReader.Read<Vector3>();
        Point2 = binaryReader.Read<Vector3>();
        Point3 = binaryReader.Read<Vector3>();

        Unknown5 = binaryReader.ReadSingle();
        Unknown6 = binaryReader.ReadSingle();
    }

    private void ReadNames(SBinaryReader binaryReader, ICollection<String256> namesList)
    {
        var namesCount = binaryReader.ReadInt32();
        for (var i = 0; i < namesCount; i++)
        {
            var str256 = binaryReader.Read<String256>();
            namesList.Add(str256);
        }
    }

    private void ReadNamesAndCoordinates(SBinaryReader binaryReader, ICollection<String256> namesList,
        ICollection<WldCoordinate> coordinatesList)
    {
        ReadNames(binaryReader, namesList);

        var coordinatesCount = binaryReader.ReadInt32();
        for (var i = 0; i < coordinatesCount; i++)
        {
            var coordinate = binaryReader.Read<WldCoordinate>();
            coordinatesList.Add(coordinate);
        }
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        var typeStr = WldType == WldType.FLD ? "FLD" : "DUN";
        binaryWriter.Write(typeStr, isLengthPrefixed: false, includeStringTerminator: true);

        // FLD only fields
        if (WldType == WldType.FLD)
        {
            binaryWriter.Write(MapSize);
            binaryWriter.Write(Heightmap);
            binaryWriter.Write(TextureMap);
            binaryWriter.Write(Textures.ToSerializable());
        }

        binaryWriter.Write(InnerLayout);

        binaryWriter.Write(BuildingNames.ToSerializable());
        binaryWriter.Write(BuildingCoordinates.ToSerializable());
        binaryWriter.Write(ShapeNames.ToSerializable());
        binaryWriter.Write(ShapeCoordinates.ToSerializable());
        binaryWriter.Write(TreeNames.ToSerializable());
        binaryWriter.Write(TreeCoordinates.ToSerializable());
        binaryWriter.Write(GrassNames.ToSerializable());
        binaryWriter.Write(GrassCoordinates.ToSerializable());
        binaryWriter.Write(VAniNames1.ToSerializable());
        binaryWriter.Write(VAniCoordinates1.ToSerializable());
        binaryWriter.Write(VAniNames2.ToSerializable());
        binaryWriter.Write(VAniCoordinates2.ToSerializable());
        binaryWriter.Write(DungeonNames.ToSerializable());
        binaryWriter.Write(DungeonCoordinates.ToSerializable());
        binaryWriter.Write(MAniNames.ToSerializable());
        binaryWriter.Write(MAniCoordinates.ToSerializable());
        binaryWriter.Write(EffectName);
        binaryWriter.Write(Effects.ToSerializable());

        binaryWriter.Write(Unknown1);
        binaryWriter.Write(Unknown2);
        binaryWriter.Write(Unknown3);

        binaryWriter.Write(ObjectNames.ToSerializable());
        binaryWriter.Write(ObjectCoordinates.ToSerializable());
        binaryWriter.Write(MusicNames.ToSerializable());
        binaryWriter.Write(MusicZones.ToSerializable());
        binaryWriter.Write(SoundEffectNames.ToSerializable());
        binaryWriter.Write(Zones.ToSerializable());
        binaryWriter.Write(SoundEffects.ToSerializable());
        binaryWriter.Write(UnknownBoundingBoxes.ToSerializable());
        binaryWriter.Write(Portals.ToSerializable());
        binaryWriter.Write(Spawns.ToSerializable());
        binaryWriter.Write(NamedAreas.ToSerializable());

        var npcCount = Npcs.Count + Npcs.Sum(npc => npc.PatrolCoordinates.Count);
        binaryWriter.Write(npcCount);

        foreach (var npc in Npcs)
        {
            binaryWriter.Write(npc);
        }

        if (WldType == WldType.FLD)
        {
            binaryWriter.Write(SkyName);
            binaryWriter.Write(CloudsName1);
            binaryWriter.Write(CloudsName2);
        }

        binaryWriter.Write(Point1);
        binaryWriter.Write(Point2);
        binaryWriter.Write(Point3);

        binaryWriter.Write(Unknown5);
        binaryWriter.Write(Unknown6);
    }
}
