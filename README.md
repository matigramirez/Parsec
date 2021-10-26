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
// Load the svmap file
var svmap = new Svmap("0.svmap");

// Parse the file's data
svmap.Read();

Console.WriteLine($"MapSize: {svmap.MapSize}");
Console.WriteLine($"Ladder Count: {svmap.LadderCount}");
Console.WriteLine($"Monster Area Count: {svmap.MonsterAreaCount}");
Console.WriteLine($"Npc Count: {svmap.NpcCount}");
Console.WriteLine($"Portal Count: {svmap.PortalCount}");
Console.WriteLine($"Spawn Count: {svmap.SpawnCount}");
Console.WriteLine($"Named Area Count: {svmap.NamedAreaCount}");
```

More samples in the [samples section](https://github.com/matigramirez/Parsec/tree/main/samples).
