using System;
using Parsec.Shaiya.Data;
using Parsec.Shaiya.Svmap;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Read Data

            // Read data
            var data = new Data("data.sah");

            // Find the file you want to extract
            if (data.FileIndex.TryGetValue("world/2.svmap", out var file))
            {
                // Extract the selected file
                data.Extract(file, "extracted");

                // Read and parse the file's content directly from the saf file
                var svmap = Reader.ReadFromBuffer<Svmap>(file.Name, data.GetFileBuffer(file));

                Console.WriteLine($"File: {svmap.FileName}");
                Console.WriteLine($"MapSize: {svmap.MapSize}");
                Console.WriteLine($"Ladder Count: {svmap.Ladders.Count}");
                Console.WriteLine($"Monster Area Count: {svmap.MonsterAreas.Count}");
                Console.WriteLine($"Npc Count: {svmap.Npcs.Count}");
                Console.WriteLine($"Portal Count: {svmap.Portals.Count}");
                Console.WriteLine($"Spawn Count: {svmap.Spawns.Count}");
                Console.WriteLine($"Named Area Count: {svmap.NamedAreas.Count}");
            }

            #endregion

            #region Create Data/Patch

            // Create patch data
            var createdData = DataBuilder.CreateFromDirectory("input", "output");

            Console.WriteLine($"Data file count: {createdData.FileCount}");

            #endregion
        }
    }
}
