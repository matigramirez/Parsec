using System;
using System.Collections.Generic;
using Parsec.Shaiya.SVMAP;

namespace Parsec.Sample.SVMAP
{
    class Program
    {
        static void Main(string[] args)
        {
            var svmap0 = new Svmap("0.svmap");
            svmap0.Read();

            var svmap2 = new Svmap("2.svmap");
            svmap2.Read();

            Console.WriteLine($"File: {svmap2.FileName}");
            Console.WriteLine($"MapSize: {svmap2.MapSize}");
            Console.WriteLine($"Ladder Count: {svmap2.Ladders.Count}");
            Console.WriteLine($"Monster Area Count: {svmap2.MonsterAreas.Count}");
            Console.WriteLine($"Npc Count: {svmap2.Npcs.Count}");
            Console.WriteLine($"Portal Count: {svmap2.Portals.Count}");
            Console.WriteLine($"Spawn Count: {svmap2.Spawns.Count}");
            Console.WriteLine($"Named Area Count: {svmap2.NamedAreas.Count}");

            svmap2.Export($"{svmap2.FileNameWithoutExtension}.json", new List<string>
            {
                nameof(svmap2.MapHeights),
                nameof(svmap2.MapSize)
            });
        }
    }
}
