using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;
using Parsec.Shaiya.Wld;

namespace Parsec.Shaiya.WLD;

public sealed class WLD : FileBase
{
    public WldType Type { get; set; } = WldType.FLD;

    #region FLD Only fields

    /// <summary>
    /// Map Size, must be a power of 2 (1024 or 2048)
    /// </summary>
    public int MapSize { get; set; }

    /// <summary>
    /// Map used for Y coordinate calculation based on X and Z
    /// </summary>
    public byte[] Heightmap { get; set; }

    /// <summary>
    /// Map used for texture usage based on X and Z
    /// </summary>
    public byte[] TextureMap { get; set; }

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

    public Vector3 Point1 { get; set; }

    public Vector3 Point2 { get; set; }

    public Vector3 Point3 { get; set; }

    public float Unknown5 { get; set; }

    public float Unknown6 { get; set; }

    // This structure is incomplete, there's a bunch of unknown fields missing

    [JsonIgnore]
    public override string Extension => "wld";

    public override void Read()
    {
        string typeStr = _binaryReader.ReadString(4).Trim('\0');

        if (typeStr == "DUN")
            Type = WldType.DUN;


        // FLD only fields
        if (Type == WldType.FLD)
        {
            MapSize = _binaryReader.Read<int>();

            int mappingSize = (int)Math.Pow(MapSize / 2f + 1, 2);
            Heightmap = _binaryReader.ReadBytes(mappingSize * 2);
            TextureMap = _binaryReader.ReadBytes(mappingSize);

            int textureCount = _binaryReader.Read<int>();
            for (int i = 0; i < textureCount; i++)
                Textures.Add(new WldTexture(_binaryReader));
        }

        InnerLayout = new String256(_binaryReader);

        ReadNamesAndCoordinates(BuildingNames, BuildingCoordinates);
        ReadNamesAndCoordinates(ShapeNames, ShapeCoordinates);
        ReadNamesAndCoordinates(TreeNames, TreeCoordinates);
        ReadNamesAndCoordinates(GrassNames, GrassCoordinates);
        ReadNamesAndCoordinates(VAniNames1, VAniCoordinates1);
        ReadNamesAndCoordinates(VAniNames2, VAniCoordinates2);
        ReadNamesAndCoordinates(DungeonNames, DungeonCoordinates);
        ReadNames(MAniNames);

        int maniCoordinatesCount = _binaryReader.Read<int>();
        for (int i = 0; i < maniCoordinatesCount; i++)
            MAniCoordinates.Add(new WldManiCoordinate(_binaryReader));

        EffectName = new String256(_binaryReader);

        int effectCount = _binaryReader.Read<int>();
        for (int i = 0; i < effectCount; i++)
            Effects.Add(new WldEffect(_binaryReader));

        Unknown1 = _binaryReader.Read<int>();
        Unknown2 = _binaryReader.Read<int>();
        Unknown3 = _binaryReader.Read<int>();

        ReadNamesAndCoordinates(ObjectNames, ObjectCoordinates);
        ReadNames(MusicNames);

        int musicZoneCount = _binaryReader.Read<int>();
        for (int i = 0; i < musicZoneCount; i++)
            MusicZones.Add(new WldMusicZone(_binaryReader));

        ReadNames(SoundEffectNames);

        int zoneCount = _binaryReader.Read<int>();
        for (int i = 0; i < zoneCount; i++)
            Zones.Add(new WldZone(_binaryReader));

        int backgroundMusicSpotCount = _binaryReader.Read<int>();
        for (int i = 0; i < backgroundMusicSpotCount; i++)
            SoundEffects.Add(new WldSoundEffect(_binaryReader));

        int unknownBoundingBoxesCount = _binaryReader.Read<int>();
        for (int i = 0; i < unknownBoundingBoxesCount; i++)
            UnknownBoundingBoxes.Add(new WldUnknownBox(_binaryReader));

        int portalCount = _binaryReader.Read<int>();
        for (int i = 0; i < portalCount; i++)
            Portals.Add(new WldPortal(_binaryReader));

        int spawnCount = _binaryReader.Read<int>();
        for (int i = 0; i < spawnCount; i++)
            Spawns.Add(new WldSpawn(_binaryReader));

        int namedAreaCount = _binaryReader.Read<int>();
        for (int i = 0; i < namedAreaCount; i++)
            NamedAreas.Add(new WldNamedArea(_binaryReader));

        // NOTE: npcCount is the real npc count + the patrol coordinates count
        int npcCount = _binaryReader.Read<int>();

        while (npcCount > 0)
        {
            var npc = new WldNpc(_binaryReader);
            Npcs.Add(npc);
            npcCount -= npc.PatrolCoordinates.Count;
            npcCount--;
        }

        if (Type == WldType.FLD)
        {
            SkyName = new String256(_binaryReader);
            CloudsName1 = new String256(_binaryReader);
            CloudsName2 = new String256(_binaryReader);
        }

        Point1 = new Vector3(_binaryReader);
        Point2 = new Vector3(_binaryReader);
        Point3 = new Vector3(_binaryReader);

        Unknown5 = _binaryReader.Read<float>();
        Unknown6 = _binaryReader.Read<float>();
    }

    private void ReadNames(ICollection<String256> namesList)
    {
        int namesCount = _binaryReader.Read<int>();
        for (int i = 0; i < namesCount; i++)
            namesList.Add(new String256(_binaryReader));
    }

    private void ReadNamesAndCoordinates(ICollection<String256> namesList, ICollection<WldCoordinate> coordinatesList)
    {
        ReadNames(namesList);

        int coordinatesCount = _binaryReader.Read<int>();
        for (int i = 0; i < coordinatesCount; i++)
            coordinatesList.Add(new WldCoordinate(_binaryReader));
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Type == WldType.FLD ? "FLD".GetBytes(true) : "DUN".GetBytes(true));

        // FLD only fields
        if (Type == WldType.FLD)
        {
            buffer.AddRange(MapSize.GetBytes());
            buffer.AddRange(Heightmap);
            buffer.AddRange(TextureMap);
            buffer.AddRange(Textures.GetBytes());
        }

        buffer.AddRange(InnerLayout.GetBytes());

        buffer.AddRange(BuildingNames.GetBytes());
        buffer.AddRange(BuildingCoordinates.GetBytes());
        buffer.AddRange(ShapeNames.GetBytes());
        buffer.AddRange(ShapeCoordinates.GetBytes());
        buffer.AddRange(TreeNames.GetBytes());
        buffer.AddRange(TreeCoordinates.GetBytes());
        buffer.AddRange(GrassNames.GetBytes());
        buffer.AddRange(GrassCoordinates.GetBytes());
        buffer.AddRange(VAniNames1.GetBytes());
        buffer.AddRange(VAniCoordinates1.GetBytes());
        buffer.AddRange(VAniNames2.GetBytes());
        buffer.AddRange(VAniCoordinates2.GetBytes());
        buffer.AddRange(DungeonNames.GetBytes());
        buffer.AddRange(DungeonCoordinates.GetBytes());
        buffer.AddRange(MAniNames.GetBytes());
        buffer.AddRange(MAniCoordinates.GetBytes());
        buffer.AddRange(EffectName.GetBytes());
        buffer.AddRange(Effects.GetBytes());

        buffer.AddRange(Unknown1.GetBytes());
        buffer.AddRange(Unknown2.GetBytes());
        buffer.AddRange(Unknown3.GetBytes());

        buffer.AddRange(ObjectNames.GetBytes());
        buffer.AddRange(ObjectCoordinates.GetBytes());
        buffer.AddRange(MusicNames.GetBytes());

        buffer.AddRange(MusicZones.GetBytes());
        buffer.AddRange(SoundEffectNames.GetBytes());
        buffer.AddRange(Zones.GetBytes());
        buffer.AddRange(SoundEffects.GetBytes());
        buffer.AddRange(UnknownBoundingBoxes.GetBytes());
        buffer.AddRange(Portals.GetBytes());
        buffer.AddRange(Spawns.GetBytes());
        buffer.AddRange(NamedAreas.GetBytes());

        int npcCount = Npcs.Count + Npcs.Sum(npc => npc.PatrolCoordinates.Count);
        buffer.AddRange(npcCount.GetBytes());

        foreach (var npc in Npcs)
            buffer.AddRange(npc.GetBytes());

        if (Type == WldType.FLD)
        {
            buffer.AddRange(SkyName.GetBytes());
            buffer.AddRange(CloudsName1.GetBytes());
            buffer.AddRange(CloudsName2.GetBytes());
        }

        buffer.AddRange(Point1.GetBytes());
        buffer.AddRange(Point2.GetBytes());
        buffer.AddRange(Point3.GetBytes());

        buffer.AddRange(Unknown5.GetBytes());
        buffer.AddRange(Unknown6.GetBytes());

        return buffer;
    }
}
