using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Attributes.Wld;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

public enum WldType
{
    FLD,
    DUN
}

public sealed class WLD : FileBase
{
    public WldType WldType => Type == "DUN" ? WldType.DUN : WldType.FLD;

    [ShaiyaProperty]
    [FixedLengthString(4)]
    public string Type { get; set; }

    #region FLD Only fields

    /// <summary>
    /// 1024 or 2048
    /// </summary>
    [ShaiyaProperty]
    [ConditionalProperty(nameof(WldType), WldType.FLD)]
    public int MapSize { get; set; }

    /// <summary>
    ///
    /// </summary>
    [ShaiyaProperty]
    [ConditionalProperty(nameof(WldType), WldType.FLD)]
    [Heightmap(nameof(MapSize))]
    public byte[] Heightmap { get; set; }

    /// <summary>
    ///
    /// </summary>
    [ShaiyaProperty]
    [ConditionalProperty(nameof(WldType), WldType.FLD)]
    [TextureMap(nameof(MapSize))]
    public byte[] TextureMap { get; set; }

    [ShaiyaProperty]
    [ConditionalProperty(nameof(WldType), WldType.FLD)]
    [LengthPrefixedList(typeof(TextSound))]
    public List<TextSound> TextSounds { get; set; }

    #endregion

    /// <summary>
    /// Fixed length string, length = 256. "inner layout", ".wtr" (water) for a field, ".dg" for a dungeon
    /// </summary>
    [ShaiyaProperty]
    [FixedLengthString(isString256: true)]
    public string InnerLayout { get; set; }

    /// <summary>
    /// Files from Entity/Building
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(String256))]
    public List<String256> BuildingNames { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Coordinate))]
    public List<Coordinate> BuildingCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Entity/Shape
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(String256))]
    public List<String256> ShapeNames { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Coordinate))]
    public List<Coordinate> ShapeCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Entity/Tree
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(String256))]
    public List<String256> TreeNames { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Coordinate))]
    public List<Coordinate> TreeCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Entity/Grass
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(String256))]
    public List<String256> GrassNames { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Coordinate))]
    public List<Coordinate> GrassCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Entity/VAni
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(String256))]
    public List<String256> VAniNames1 { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Coordinate))]
    public List<Coordinate> VAniCoordinates1 { get; set; } = new();

    /// <summary>
    /// Files from Entity/VAni
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(String256))]
    public List<String256> VAniNames2 { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Coordinate))]
    public List<Coordinate> VAniCoordinates2 { get; set; } = new();

    /// <summary>
    /// Files from World/dungeon
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(String256))]
    public List<String256> DungeonNames { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Coordinate))]
    public List<Coordinate> DungeonCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Entity/MAni
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(String256))]
    public List<String256> MAniNames { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(ManiCoordinate))]
    public List<ManiCoordinate> MAniCoordinates { get; set; } = new();

    [ShaiyaProperty]
    [FixedLengthString(isString256: true)]
    public string EffectName { get; set; }

    /// <summary>
    /// Files from Effect/
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Effect))]
    public List<Effect> Effects { get; set; } = new();

    [ShaiyaProperty]
    public int Unknown1 { get; set; }

    [ShaiyaProperty]
    public int Unknown2 { get; set; }

    [ShaiyaProperty]
    public int Unknown3 { get; set; }

    /// <summary>
    /// Files from Entity/Objects
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(String256))]
    public List<String256> ObjectNames { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Coordinate))]
    public List<Coordinate> ObjectCoordinates { get; set; } = new();

    /// <summary>
    /// Files from Sound/Music
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(String256))]
    public List<String256> MusicNames { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(MusicZone))]
    public List<MusicZone> MusicZones { get; set; } = new();

    /// <summary>
    /// Files from Sound/Music
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(String256))]
    public List<String256> BackgroundSoundNames { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(ZoneList))]
    public List<ZoneList> Zones { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(MusicSpot))]
    public List<MusicSpot> BackgroundMusicSpots { get; set; } = new();

    [ShaiyaProperty]
    public int Unknown4 { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Portal))]
    public List<Portal> Portals { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Spawn))]
    public List<Spawn> Spawns { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(NamedArea))]
    public List<NamedArea> NamedAreas { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Npc))]
    public List<Npc> Npcs { get; set; } = new();

    #region FLD Only fields

    [ShaiyaProperty]
    [ConditionalProperty(nameof(WldType), WldType.FLD)]
    [FixedLengthString(isString256: true)]
    public string SkyName { get; set; }

    [ShaiyaProperty]
    [ConditionalProperty(nameof(WldType), WldType.FLD)]
    [FixedLengthString(isString256: true)]
    public string CloudsName1 { get; set; }

    [ShaiyaProperty]
    [ConditionalProperty(nameof(WldType), WldType.FLD)]
    [FixedLengthString(isString256: true)]
    public string CloudsName2 { get; set; }

    #endregion

    [ShaiyaProperty]
    public Vector3 Point1 { get; set; }

    [ShaiyaProperty]
    public Vector3 Point2 { get; set; }

    [ShaiyaProperty]
    public Vector3 Point3 { get; set; }

    [ShaiyaProperty]
    public float Unknown5 { get; set; }

    [ShaiyaProperty]
    public float Unknown6 { get; set; }

    [JsonIgnore]
    public override string Extension => "wld";
}
