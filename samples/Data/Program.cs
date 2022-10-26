using System;
using Parsec;
using Parsec.Shaiya.Data;
using Parsec.Shaiya.Svmap;

namespace Sample.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Read Data

        // Read data from .sah and .saf files
        Parsec.Shaiya.Data.Data data = new("data.sah");

        // Find the file you want to extract with it's full relative path
        // Keep in mind that in Episode 8, the relative path for this same case would be "data/world/2.svmap
        if (data.FileIndex.TryGetValue("world/2.svmap", out SFile file))
        {
            // Extract the selected file
            data.Extract(file, "extracted");

            // Read and parse the file's content directly from the saf file
            Svmap svmap = Reader.ReadFromBuffer<Svmap>(file.Name, data.GetFileBuffer(file));

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
        Parsec.Shaiya.Data.Data createdData = DataBuilder.CreateFromDirectory("input", "output");

        Console.WriteLine($"Data file count: {createdData.FileCount}");

        #endregion
    }
}
