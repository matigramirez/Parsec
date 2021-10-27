# Parsec
`Parsec` is a simple file parsing library for Shaiya file formats built with C# and .NET Standard 2.1. Its goal is to make reading and manipulating the game's file formats with ease.

## Currently Supported files/formats
- `data.sah/saf`
- `svmap`
- `NpcQuest.SData` (partial support - Quests are missing)
- `KillStatus.SData`

## Getting Started
TBA

## Samples
### `svmap`
```cs
// Open svmap file
var svmap = new Svmap("2.svmap");

// Parse its content
svmap.Read();

// Print content
Console.WriteLine($"File: {svmap.FileName}");
Console.WriteLine($"MapSize: {svmap.MapSize}");
Console.WriteLine($"Ladder Count: {svmap.Ladders.Count}");
Console.WriteLine($"Monster Area Count: {svmap.MonsterAreas.Count}");
Console.WriteLine($"Npc Count: {svmap.Npcs.Count}");
Console.WriteLine($"Portal Count: {svmap.Portals.Count}");
Console.WriteLine($"Spawn Count: {svmap.Spawns.Count}");
Console.WriteLine($"Named Area Count: {svmap.NamedAreas.Count}");

// Export json file
svmap.Export($"{svmap.FileNameWithoutExtension}.json", new List<string>
{
  nameof(svmap2.MapHeights),
  nameof(svmap2.MapSize)
});
```

More samples in the [samples section](https://github.com/matigramirez/Parsec/tree/main/samples).
