using System;

namespace Parsec.Sample.Svmap
{
    class Program
    {
        static void Main(string[] args)
        {
            var svmap = new Shaiya.SVMAP.Svmap("0.svmap");
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
