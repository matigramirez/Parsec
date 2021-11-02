# Parsec
[![.NET](https://github.com/matigramirez/Parsec/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/matigramirez/Parsec/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/Parsec.svg)](https://www.nuget.org/packages/Parsec/)

`Parsec` is a simple file parsing library for Shaiya file formats built with C# and .NET Standard 2.1. Its goal is to make reading and manipulating the game's file formats easy.

## Currently Supported files/formats
- `data.sah/saf`
- `svmap`
- `NpcQuest.SData` (partial support - Quests are missing)
- `KillStatus.SData`

## Getting Started
TBA

## Documentation
TBA

## Samples
### `sah/saf`
```cs
// Load sah
var sah = new Sah("data.sah");
sah.Load();

// Find the file you want to extract
var file = sah.FileIndex.Values.FirstOrDefault(f => f.Name == "sysmsg-uni.txt");

// Check that file isn't null
if (file == null)
    return;

// Create file instance
var saf = new Saf(sah);

// Read saf and extract the selected file
saf.Extract(file, "extracted");
```

### `SData`
Encryption / Decryption
```cs
// Load NpcQuest.SData
var npcQuest = new NpcQuest("NpcQuest.SData");

// Save decrypted file (original encryption status doesn't matter
npcQuest.SaveDecrypted("NpcQuest.decrypted.SData");

// Save encrypted file (original encryption status doesn't matter)
npcQuest.SaveEncrypted("NpcQuest.encrypted.SData");
```

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

// Export json file ignoring some fields
svmap.Export($"{svmap.FileNameWithoutExtension}.json", new List<string>
{
  nameof(svmap.MapHeights),
  nameof(svmap.MapSize)
});
```

More samples in the [samples section](https://github.com/matigramirez/Parsec/tree/main/samples).
