using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public sealed class Wld : FileBase
{
    public WldType WldType { get; set; } = WldType.Field;

    /// <summary>
    /// Map side size
    /// </summary>
    public uint MapSize { get; set; }

    /// <summary>
    /// Map used for Y coordinate calculation based on X and Z
    /// </summary>
    public byte[] TerrainHeightMap { get; set; }

    /// <summary>
    /// Terrain mappings for <see cref="TerrainLayers"/>
    /// </summary>
    public byte[] TerrainTextureMap { get; set; }

    public List<WldTerrainLayer> TerrainLayers { get; set; } = new();

    /// <summary>
    /// Defines the name of a water file (.wtr) for worlds of type "Field" and the name of a dungeon file (.dg) for worlds of type "Dungeon"
    /// </summary>
    public String256 LayoutName { get; set; } = string.Empty;

    /// <summary>
    /// List of assets from Entity/Building
    /// </summary>
    public List<String256> BuildingAssets { get; set; } = new();

    public List<WldObjectInstance> BuildingInstances { get; set; } = new();

    /// <summary>
    /// List of assets from Entity/Shape
    /// </summary>
    public List<String256> ShapeAssets { get; set; } = new();

    public List<WldObjectInstance> ShapeInstances { get; set; } = new();

    /// <summary>
    /// List of assets from Entity/Tree
    /// </summary>
    public List<String256> TreeAssets { get; set; } = new();

    public List<WldObjectInstance> TreeInstances { get; set; } = new();

    /// <summary>
    /// List of assets from Entity/Grass
    /// </summary>
    public List<String256> GrassAssets { get; set; } = new();

    public List<WldObjectInstance> GrassInstances { get; set; } = new();

    /// <summary>
    /// List of assets from Entity/VAni
    /// </summary>
    public List<String256> PrimaryVaniAssets { get; set; } = new();

    public List<WldObjectInstance> PrimaryVaniInstances { get; set; } = new();

    /// <summary>
    /// List of assets from Entity/VAni
    /// </summary>
    public List<String256> SecondaryVaniAssets { get; set; } = new();

    public List<WldObjectInstance> SecondaryVaniInstances { get; set; } = new();

    /// <summary>
    /// List of assets from World/dungeon
    /// </summary>
    public List<String256> DungeonAssets { get; set; } = new();

    public List<WldObjectInstance> DungeonInstances { get; set; } = new();

    /// <summary>
    /// List of assets from data/Entity/MAni
    /// </summary>
    public List<String256> ManiAssets { get; set; } = new();

    public List<WldManiCoordinate> ManiInstances { get; set; } = new();

    /// <summary>
    /// Name of the EFT file that is used by the world
    /// </summary>
    public String256 EffectFileName { get; set; } = string.Empty;

    /// <summary>
    /// List of effects that are available in <see cref="EffectFileName"/>
    /// </summary>
    public List<WldEffectInstance> EffectInstances { get; set; } = new();

    public int Unknown1 { get; set; }

    public int Unknown2 { get; set; }

    public int Unknown3 { get; set; }

    /// <summary>
    /// List of assets from data/Entity/Object
    /// </summary>
    public List<String256> ObjectAssets { get; set; } = new();

    public List<WldObjectInstance> ObjectInstances { get; set; } = new();

    /// <summary>
    /// List of assets from data/Sound/Music
    /// </summary>
    public List<String256> MusicAssets { get; set; } = new();

    public List<WldMusicZone> MusicZoneInstances { get; set; } = new();

    /// <summary>
    /// List of assets from data/Sound
    /// </summary>
    public List<String256> SoundEffectAssets { get; set; } = new();

    public List<WldZone> Zones { get; set; } = new();

    public List<WldSoundEffect> SoundEffectInstances { get; set; } = new();

    public List<WldMonsterRestrictedZone> WldMonsterRestrictedZones { get; set; } = new();

    public List<WldPortal> PortalInstances { get; set; } = new();

    public List<WldSpawn> SpawnInstances { get; set; } = new();

    public List<WldNamedArea> NamedAreaInstances { get; set; } = new();

    public List<WldNpc> NpcInstances { get; set; } = new();

    public String256 SkyFileName { get; set; } = string.Empty;

    public String256 PrimaryCloudFileName { get; set; } = string.Empty;

    public String256 SecondaryCloudFileName { get; set; } = string.Empty;

    /// <summary>
    /// Color field that always has its value set to (255, 255, 255) but it's not used in any way by the game client
    /// </summary>
    public Color UnusedColor1 { get; set; }

    /// <summary>
    /// Color field that always has its value set to (128, 128, 128) but it's not used in any way by the game client
    /// </summary>
    public Color UnusedColor2 { get; set; }

    public Color FogColor { get; set; }

    public float FogStartDistance { get; set; }

    public float FogEndDistance { get; set; }

    protected override void Read(SBinaryReader binaryReader)
    {
        var worldType = binaryReader.ReadString(4);

        if (worldType == "DUN")
        {
            WldType = WldType.Dungeon;
        }

        // FLD only fields
        if (WldType == WldType.Field)
        {
            MapSize = binaryReader.ReadUInt32();

            var mappingSize = (int)Math.Pow(MapSize / 2f + 1, 2);
            TerrainHeightMap = binaryReader.ReadBytes(mappingSize * 2);
            TerrainTextureMap = binaryReader.ReadBytes(mappingSize);
            TerrainLayers = binaryReader.ReadList<WldTerrainLayer>().ToList();
        }

        LayoutName = binaryReader.Read<String256>();

        ReadNamesAndCoordinates(binaryReader, BuildingAssets, BuildingInstances);
        ReadNamesAndCoordinates(binaryReader, ShapeAssets, ShapeInstances);
        ReadNamesAndCoordinates(binaryReader, TreeAssets, TreeInstances);
        ReadNamesAndCoordinates(binaryReader, GrassAssets, GrassInstances);
        ReadNamesAndCoordinates(binaryReader, PrimaryVaniAssets, PrimaryVaniInstances);
        ReadNamesAndCoordinates(binaryReader, SecondaryVaniAssets, SecondaryVaniInstances);
        ReadNamesAndCoordinates(binaryReader, DungeonAssets, DungeonInstances);
        ReadNames(binaryReader, ManiAssets);

        ManiInstances = binaryReader.ReadList<WldManiCoordinate>().ToList();
        EffectFileName = binaryReader.Read<String256>();
        EffectInstances = binaryReader.ReadList<WldEffectInstance>().ToList();

        Unknown1 = binaryReader.ReadInt32();
        Unknown2 = binaryReader.ReadInt32();
        Unknown3 = binaryReader.ReadInt32();

        ReadNamesAndCoordinates(binaryReader, ObjectAssets, ObjectInstances);
        ReadNames(binaryReader, MusicAssets);

        MusicZoneInstances = binaryReader.ReadList<WldMusicZone>().ToList();

        ReadNames(binaryReader, SoundEffectAssets);

        Zones = binaryReader.ReadList<WldZone>().ToList();
        SoundEffectInstances = binaryReader.ReadList<WldSoundEffect>().ToList();
        WldMonsterRestrictedZones = binaryReader.ReadList<WldMonsterRestrictedZone>().ToList();
        PortalInstances = binaryReader.ReadList<WldPortal>().ToList();
        SpawnInstances = binaryReader.ReadList<WldSpawn>().ToList();
        NamedAreaInstances = binaryReader.ReadList<WldNamedArea>().ToList();

        // NOTE: npcCount is the real npc count + the patrol coordinates count
        var npcCount = binaryReader.ReadInt32();

        while (npcCount > 0)
        {
            var npc = binaryReader.Read<WldNpc>();
            NpcInstances.Add(npc);
            npcCount -= npc.PatrolPositions.Count;
            npcCount--;
        }

        if (WldType == WldType.Field)
        {
            SkyFileName = binaryReader.Read<String256>();
            PrimaryCloudFileName = binaryReader.Read<String256>();
            SecondaryCloudFileName = binaryReader.Read<String256>();
        }

        UnusedColor1 = binaryReader.Read<Color>();
        UnusedColor2 = binaryReader.Read<Color>();
        FogColor = binaryReader.Read<Color>();

        FogStartDistance = binaryReader.ReadSingle();
        FogEndDistance = binaryReader.ReadSingle();
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
                                         ICollection<WldObjectInstance> coordinatesList)
    {
        ReadNames(binaryReader, namesList);

        var coordinatesCount = binaryReader.ReadInt32();
        for (var i = 0; i < coordinatesCount; i++)
        {
            var coordinate = binaryReader.Read<WldObjectInstance>();
            coordinatesList.Add(coordinate);
        }
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        var typeStr = WldType == WldType.Field ? "FLD" : "DUN";
        binaryWriter.Write(typeStr, isLengthPrefixed: false, includeStringTerminator: true);

        // FLD only fields
        if (WldType == WldType.Field)
        {
            binaryWriter.Write(MapSize);
            binaryWriter.Write(TerrainHeightMap);
            binaryWriter.Write(TerrainTextureMap);
            binaryWriter.Write(TerrainLayers.ToSerializable());
        }

        binaryWriter.Write(LayoutName);

        binaryWriter.Write(BuildingAssets.ToSerializable());
        binaryWriter.Write(BuildingInstances.ToSerializable());
        binaryWriter.Write(ShapeAssets.ToSerializable());
        binaryWriter.Write(ShapeInstances.ToSerializable());
        binaryWriter.Write(TreeAssets.ToSerializable());
        binaryWriter.Write(TreeInstances.ToSerializable());
        binaryWriter.Write(GrassAssets.ToSerializable());
        binaryWriter.Write(GrassInstances.ToSerializable());
        binaryWriter.Write(PrimaryVaniAssets.ToSerializable());
        binaryWriter.Write(PrimaryVaniInstances.ToSerializable());
        binaryWriter.Write(SecondaryVaniAssets.ToSerializable());
        binaryWriter.Write(SecondaryVaniInstances.ToSerializable());
        binaryWriter.Write(DungeonAssets.ToSerializable());
        binaryWriter.Write(DungeonInstances.ToSerializable());
        binaryWriter.Write(ManiAssets.ToSerializable());
        binaryWriter.Write(ManiInstances.ToSerializable());
        binaryWriter.Write(EffectFileName);
        binaryWriter.Write(EffectInstances.ToSerializable());

        binaryWriter.Write(Unknown1);
        binaryWriter.Write(Unknown2);
        binaryWriter.Write(Unknown3);

        binaryWriter.Write(ObjectAssets.ToSerializable());
        binaryWriter.Write(ObjectInstances.ToSerializable());
        binaryWriter.Write(MusicAssets.ToSerializable());
        binaryWriter.Write(MusicZoneInstances.ToSerializable());
        binaryWriter.Write(SoundEffectAssets.ToSerializable());
        binaryWriter.Write(Zones.ToSerializable());
        binaryWriter.Write(SoundEffectInstances.ToSerializable());
        binaryWriter.Write(WldMonsterRestrictedZones.ToSerializable());
        binaryWriter.Write(PortalInstances.ToSerializable());
        binaryWriter.Write(SpawnInstances.ToSerializable());
        binaryWriter.Write(NamedAreaInstances.ToSerializable());

        var npcCount = NpcInstances.Count + NpcInstances.Sum(npc => npc.PatrolPositions.Count);
        binaryWriter.Write(npcCount);

        foreach (var npc in NpcInstances)
        {
            binaryWriter.Write(npc);
        }

        if (WldType == WldType.Field)
        {
            binaryWriter.Write(SkyFileName);
            binaryWriter.Write(PrimaryCloudFileName);
            binaryWriter.Write(SecondaryCloudFileName);
        }

        binaryWriter.Write(UnusedColor1);
        binaryWriter.Write(UnusedColor2);
        binaryWriter.Write(FogColor);

        binaryWriter.Write(FogStartDistance);
        binaryWriter.Write(FogEndDistance);
    }
}
