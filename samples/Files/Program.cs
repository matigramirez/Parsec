using System;
using Parsec;
using Parsec.Shaiya.Svmap;

namespace Sample.Files;

internal static class Program
{
    private static void Main(string[] args)
    {
        // This sample shows how you can convert a shaiya file format (in this case svmap) into json to be able to
        // edit its properties as plain text, and then, convert it back to its original format

        // Step 1: Read a svmap from a file
        Svmap svmap = Reader.ReadFromFile<Svmap>("2.svmap");

        // You can go through and modify its properties here too
        foreach (Npc npc in svmap.Npcs)
        {
            Console.WriteLine($"NpcId: {npc.NpcId}, Type: {npc.Type}");
        }

        // Step 2: Export svmap as JSON
        svmap.ExportJson("2.svmap.json");

        // Step 3: Modify the json file in any text editor

        // Step 4: Read svmap from the modified JSON file
        Svmap svmapFromJson = Reader.ReadFromJson<Svmap>("2.svmap.json");

        // Step 5: Write the edited instance as .svmap
        svmapFromJson.Write("2.edited.svmap");
    }
}
