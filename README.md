# Parsec
[![.NET](https://github.com/matigramirez/Parsec/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/matigramirez/Parsec/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/Parsec.svg)](https://www.nuget.org/packages/Parsec/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

`Parsec` is a simple file parsing library for Shaiya file formats built with C# and .NET Standard 2.1. Its goal is to make reading and manipulating the game's file formats easy.

## Currently supported files/formats
- `data.sah/saf`
- `svmap`
- `ANI`
- `3DC`
- `MLT`
- `3DO`
- `ITM`
- `SMOD`
- `EFT`
- `seff`
- `NpcQuest.SData` (EP5 support, EP5+ is pending)
- `KillStatus.SData`
- `Cash.SData`
- `SetItem.SData`
- `DualLayerClothes.SData`
- `GuldHouse.SData`

## Features
- `data` extraction, patching and creation
- `SData` encryption/decryption
- Export and import most supported formats as `json` (you can modify files as json and convert them back to their original format)

## Getting Started
### Prerequisites
- `.NET 5 SDK`

### Run
1. Create a C# project in Visual Studio/Rider/VSCode/CLI
2. Add `Parsec` as a dependency, either through the NuGet package or the library's source code itself

or... Use one of the samples from the [samples section](https://github.com/matigramirez/Parsec/tree/main/samples).

## Documentation
### Reading
1. Create an instance of the file you want to read:
```cs
var svmap = new Svmap("0.svmap");
```
2. Call the `Read` method to parse the file's content. All the fields in the file will become available.
```cs
svmap.Read();
```

### Export
After modifying the file, you can save it in its original format by calling the `Write` method
```cs
svmap.Write("0.modified.svmap");
```

### Export as JSON
Call the `ExportJson` method
```cs
svmap.ExportJson("map0.json");
```

### Import as JSON
`Parsec` supports importing a file as JSON, which can be later exported as its original format. The user must make sure that the JSON file is properly formatted to match the JSON standards and contain all the fields present in the chosen format.
```cs
var svmap = Deserializer.ReadFromJson<Svmap>("map0.json");
```
It is adviced to first read a file from its original format, export it as JSON, edit it, and importing it once again as JSON, so that all the original fields are present in the JSON file.

## Samples
### `sah/saf`
```cs
// Read sah
var sah = new Sah("data.sah");
sah.Read();

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

// Save decrypted file (original encryption status doesn't matter)
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
svmap.ExportJson($"{svmap.FileNameWithoutExtension}.json", new List<string>
{
  nameof(svmap.MapHeight),
  nameof(svmap.MapSize)
});
```

More samples in the [samples section](https://github.com/matigramirez/Parsec/tree/main/samples).
