using System;
using Parsec;
using Parsec.Shaiya.Svmap;
using Parsec.Shaiya.Zon;

namespace Sample.Maps;

class Program
{
    static void Main(string[] args)
    {
        #region svmap

        var svmap = Reader.ReadFromFile<Svmap>("2.svmap");

        Console.WriteLine($"File: {svmap.FileName}");
        Console.WriteLine($"MapSize: {svmap.MapSize}");
        Console.WriteLine($"Ladder Count: {svmap.Ladders.Count}");
        Console.WriteLine($"Monster Area Count: {svmap.MonsterAreas.Count}");
        Console.WriteLine($"Npc Count: {svmap.Npcs.Count}");
        Console.WriteLine($"Portal Count: {svmap.Portals.Count}");
        Console.WriteLine($"Spawn Count: {svmap.Spawns.Count}");
        Console.WriteLine($"Named Area Count: {svmap.NamedAreas.Count}");

        svmap.ExportJson($"{svmap.FileNameWithoutExtension}.json", nameof(svmap.MapHeight));

        #endregion

        #region zon

        var zon = Reader.ReadFromFile<Zon>("TacticsZone.zon");
        zon.ExportJson($"{zon.FileName}.json");

        var zonfromjson = Reader.ReadFromJson<Zon>($"{zon.FileName}.json");
        zonfromjson.Write($"{zonfromjson.FileNameWithoutExtension}.Created.zon");

        #endregion
    }
}
