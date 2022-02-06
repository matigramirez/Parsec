# Parsec

[![.NET](https://github.com/matigramirez/Parsec/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/matigramirez/Parsec/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/Parsec.svg)](https://www.nuget.org/packages/Parsec/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

`Parsec` is a simple file parsing library for Shaiya file formats built with C# and .NET Standard 2.1. Its goal is to
make reading and manipulating the game's file formats easy.

## Currently supported files/formats

- `data.sah/saf`
- `NpcQuest.SData` (EP4-5 supported, EP5+ is pending)
- `KillStatus.SData`
- `Cash.SData`
- `SetItem.SData`
- `DualLayerClothes.SData`
- `GuildHouse.SData`
- `svmap`
- `ANI`
- `3DC`
- `3DO`
- `3DE`
- `MLT`
- `ITM`
- `SMOD`
- `EFT`
- `seff`
- `zon`
- `ALT`

## Features

- `data` extraction, patching and creation
- `SData` encryption/decryption
- Export and import most supported formats as `json` (you can modify files as json and convert them back to their
  original format)

## Getting Started

### Prerequisites

- `.NET 6 SDK (recommended)` or `.NET 5 SDK`

### Run

1. Create a C# project in Visual Studio/Rider/VSCode/CLI
2. Add `Parsec` as a dependency, either through the NuGet package or the library's source code itself

or... Use one of the samples from the [samples section](https://github.com/matigramirez/Parsec/tree/main/samples).

## Documentation

### Reading

From a standalone file

```cs
// Read file
var svmap = Reader.ReadFromFile<Svmap>("0.svmap");
```

From data.saf

```cs
// Load data (sah and saf)
var data = new Data("data.sah");

// Find the file you want to read
if (data.FileIndex.TryGetValue("world/2.svmap", out var file))
{
  // Read and parse the file's content directly from the saf file
  var svmap = Reader.ReadFromBuffer<Svmap>(file.Name, data.GetFileBuffer(file));
}
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

`Parsec` supports importing a file as JSON, which can be later exported as its original format. The user must make sure
that the JSON file is properly formatted to match the JSON standards and contain all the fields present in the chosen
format.

```cs
var svmap = Reader.ReadFromJson<Svmap>("map0.json");
```

It is advised to first read a file from its original format, export it as JSON, edit it, and importing it once again as
JSON, so that all the original fields are present in the JSON file.

## Samples

### `sah/saf`

Read and extract

```cs
// Load data (sah and saf)
var data = new Data("data.sah");

// Find the file you want to extract
if (data.Sah.FileIndex.TryGetValue("world/2.svmap", out var file))
{
  // Extract the selected file
  data.Extract(file, "extracted");
}
```

Create data or patch from a directory

```cs
// Create patch data
var createdData = DataBuilder.CreateFromDirectory("input", "output", "update");

Console.WriteLine($"Data file count: {createdData.FileCount}");
```

### `SData`

Encryption / Decryption

```cs
var npcQuest = Reader.ReadFromFile<NpcQuest>("NpcQuest.EP5.SData", Format.EP5);

// Save encrypted file
var encryptedBytes = SData.Encrypt(npcQuest.Buffer);
FileHelper.WriteFile("NpcQuest.SData.Encrypted", encryptedBytes);

var decryptedBytes = SData.Decrypt(npcQuest.Buffer);
FileHelper.WriteFile("NpcQuest.SData.Decrypted", decryptedBytes);
```

### `svmap`

```cs
// Open svmap file
var svmap = Reader.ReadFromFile<Svmap>("2.svmap");

// Print its content
Console.WriteLine($"File: {svmap.FileName}");
Console.WriteLine($"MapSize: {svmap.MapSize}");
Console.WriteLine($"Ladder Count: {svmap.Ladders.Count}");
Console.WriteLine($"Monster Area Count: {svmap.MonsterAreas.Count}");
Console.WriteLine($"Npc Count: {svmap.Npcs.Count}");
Console.WriteLine($"Portal Count: {svmap.Portals.Count}");
Console.WriteLine($"Spawn Count: {svmap.Spawns.Count}");
Console.WriteLine($"Named Area Count: {svmap.NamedAreas.Count}");

// Export file as json file ignoring some fields
svmap.ExportJson($"{svmap.FileName}.json", nameof(svmap.MapHeight));
```

More samples in the [samples section](https://github.com/matigramirez/Parsec/tree/main/samples).
