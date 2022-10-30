# Parsec

[![.NET](https://github.com/matigramirez/Parsec/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/matigramirez/Parsec/actions/workflows/dotnet.yml)
[![codecov](https://codecov.io/github/matigramirez/Parsec/branch/main/graph/badge.svg?token=XJSNSRDLTP)](https://codecov.io/github/matigramirez/Parsec)
[![Nuget](https://img.shields.io/nuget/v/Parsec.svg)](https://www.nuget.org/packages/Parsec/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

`Parsec` is a simple file parsing library for Shaiya file formats built with C# and .NET Standard 2.0. Its goal is to
make reading and manipulating the game's file formats easy.

## Supported file formats

- `data.sah/saf`
- `NpcQuest.SData`
- `KillStatus.SData`
- `Cash.SData`
- `SetItem.SData`
- `DualLayerClothes.SData`
- `GuildHouse.SData`
- `Monster.SData`
- `Item.SData`
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
- `VAni`
- `MAni`
- `MLX`
- `MON`
- `CTL`
- `dat` (Cloth/Emblem)
- `DBItemData.SData`
- `DBItemText.SData`
- `DBMonsterData.SData`
- `DBMonsterText.SData`
- `DBSkillData.SData`
- `DBSkillText.SData`
- `DBItemSellData.SData`
- `DBItemSellText.SData`
- `DBNpcSkillData.SData`
- `DBNpcSkillText.SData`
- `DBDualLayerClothesData.SData`
- `DBSetItemData.SData`
- `DBSetItemText.SData`
- `DBTransformModelData.SData`
- `DBTransformWeaponModelData.SData`

NOTE: These file formats have been tested on Episodes 5, 6 & 8. Lower episodes might be slightly different and this library might not work for them.

## Features

- `data` extraction, building and patching
- `SData` encryption/decryption
- Export and import most supported formats as `JSON` (modify files as json and convert them back to their original format)

## Getting Started

### Prerequisites

- `.NET 6 SDK (recommended)` or any .NET version that can run on top of `.NET Standard 2.0`

## Documentation

### Reading

#### From a standalone file

```cs
// Read file
var svmap = Reader.ReadFromFile<Svmap>("0.svmap");
```

#### From data.saf

```cs
// Load data (sah and saf)
var data = new Data("data.sah");

// Find the file you want to read in the FileIndex Dictionary
if (data.FileIndex.TryGetValue("world/2.svmap", out var file))
{
  // Read and parse the file's content directly from the saf file
  var svmap = Reader.ReadFromBuffer<Svmap>(file.Name, data.GetFileBuffer(file));
}
```

NOTE: The `FileIndex` dictionary key is the file's relative path, for episodes below Episode 8, `world/2.svmap` should
work just fine, but in Episode 8 the root folder was renamed to `data`, so the key in that case is `data/world/2.svmap`.

### Export

After modifying the file, you can save it in its original format by calling the `Write` method

```cs
svmap.Write("0.modified.svmap");

// NOTE: Some Episode 8 BinarySData files require you to pass the episode as a parameter
itemEp8.Write("ItemEp8.SData", Episode.EP8);
```

### Export as JSON

Call the `ExportJson` method

```cs
svmap.ExportJson("map0.json");
```

### Import from a JSON file

`Parsec` supports importing a file as JSON, which can be later exported as its original format. The user must make sure
that the JSON file is properly formatted to match the JSON standards and contain all the fields present in the chosen
format.

```cs
var svmap = Reader.ReadFromJson<Svmap>("map0.json");
```

It is advised to first read a file from its original format, export it as JSON, edit it, and import it once again as
JSON, so that all the original fields are present in the JSON file.

## Samples

### `sah/saf`

#### Read and extract

```cs
// Load data (sah and saf)
var data = new Data("data.sah");

// Find the file you want to extract
if (data.FileIndex.TryGetValue("world/2.svmap", out var file))
{
  // Extract the selected file
  data.Extract(file, "extracted");
}
```

#### Data/Patch building

```cs
// Create data from directory
var createdData = DataBuilder.CreateFromDirectory("input", "output");

Console.WriteLine($"Data file count: {createdData.FileCount}");
```

#### Patch

```cs
// Load target data and patch data
var data = new Data("data.sah");
var patchData = new Data("update.sah");

// Patch data
DataPatcher.Patch(data, patchData);
```

### `SData`

#### Encryption / Decryption

```cs
// Encrypt
SData.EncryptFile("NpcQuest.SData", "NpcQuest.encrypted.SData");

// Decrypt
SData.DecryptFile("NpcQuest.SData", "NpcQuest.decrypted.SData");
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

### Export as CSV

The `Item.SData` format, represented by the `Item` class, can also be imported/exported as csv. The same applies for
the `Monster.SData` format, represented by the `Monster` class.

```cs
// Export as csv
var item = Reader.ReadFromFile<Item>("Item.SData");
item.ExportCsv("Item.csv")

// Read from csv
var item = Item.ReadFromCsv("Item.csv");
```

All of the Episode 8 `BinarySData` formats also support exporting and importing as `CSV`.

More examples can be found in the [samples](https://github.com/matigramirez/Parsec/tree/main/samples) directory.
