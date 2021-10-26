using System;
using Parsec.Shaiya.SVMAP;

namespace Parsec.Sample.SVMAP
{
    class Program
    {
        static void Main(string[] args)
        {
            var svmap = new Svmap("0.svmap");
            svmap.Read();

            Console.WriteLine($"MapSize: {svmap.MapSize}");
            Console.WriteLine($"Ladder Count: {svmap.LadderCount}");
            Console.WriteLine($"Monster Area Count: {svmap.MonsterAreaCount}");
            Console.WriteLine($"Npc Count: {svmap.NpcCount}");
            Console.WriteLine($"Portal Count: {svmap.PortalCount}");
            Console.WriteLine($"Spawn Count: {svmap.SpawnCount}");
            Console.WriteLine($"Named Area Count: {svmap.NamedAreaCount}");
        }
    }
}
