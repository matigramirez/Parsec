# Parsec

[![.NET](https://github.com/matigramirez/Parsec/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/matigramirez/Parsec/actions/workflows/dotnet.yml)
[![codecov](https://codecov.io/github/matigramirez/Parsec/branch/main/graph/badge.svg?token=XJSNSRDLTP)](https://codecov.io/github/matigramirez/Parsec)
[![Nuget](https://img.shields.io/nuget/v/Parsec.svg)](https://www.nuget.org/packages/Parsec/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

`Parsec` is a simple .NET file parsing library for `Shaiya` file formats which provides easy to use APIs
for serialization and deserialization of the game's file formats, as well as JSON and CSV support.

Parsec works on any .NET Standard 2.0 compliant platform, including .NET 7.0, .NET Framework 4.6.1+, .NET Core 2.0+,
Unity's Mono and Godot (C# version).

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
- `Skill.SData`
- `NpcSkill.SData`
- `svmap`
- `WLD`
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

NOTE: These file formats have been tested on Episodes 5, 6 & 8. Other episodes might differ slightly and this library
might not work with them.

## Features

- Shaiya file formats parsing and serialization (including JSON and CSV support)
- `data` extraction, building and patching
- `SData` encryption/decryption

## Getting Started

### Prerequisites

- `.NET 7 SDK (recommended)` or any `.NET Standard 2.0` compliant platform

## Documentation

### Reading

#### From a standalone file

```cs
// Read file with default episode (EP5) and encoding (ASCII)
var svmap = Reader.ReadFromFile<Svmap>("0.svmap");

// Read file with a specific episode and default encoding
var svmap = Reader.ReadFromFile<Svmap>("0.svmap", Episode.Ep6);

// Read file with a specific episode and a specific encoding
var windows1252Encoding = CodePagesEncodingProvider.Instance.GetEncoding(1252);
var svmap = Reader.ReadFromFile<Svmap>("0.svmap", Episode.Ep6, windows1252Encoding);
```

#### From data.saf

```cs
// Load data (sah and saf)
var data = new Data("data.sah");

// Find the file you want to read
var file = data.GetFile("world/0.svmap");

// Read and parse the file's content directly from the saf file
var svmap = Reader.ReadFromBuffer<Svmap>(file.Name, data.GetFileBuffer(file));
```

#### From a JSON file

`Parsec` supports importing a file as JSON, which can be later exported as its original format. The user must make sure
that the JSON file is properly formatted to match the JSON standards and contain all the fields present in the chosen
format.

```cs
// Read JSON file
var svmap = Reader.ReadFromJsonFile<Svmap>("0_svmap.json");
```

It is advised to first read a file from its original format, export it as JSON, edit it, and import it once again as
JSON, so that all the original fields are present in the JSON file.

#### From a CSV file

Only some pre-Ep8 `SData` formats support reading as `CSV`.
All of the Episode 8 `BinarySData` formats have `CSV` support.

```cs
// Read csv file
var item = Item.ReadFromCsv("Item.csv");
```

### Encoding

When reading files, the default encoding is `ASCII`. If you want to read a file with a different encoding, you can
specify it as a parameter when calling the ReadFromFile/Json/Csv methods.

### Writing

#### Writing a standalone file

After modifying the file, you can save it in its original format by calling the `Write` method. If you specified
the episode and encoding when reading the file, you don't need to specify them again when writing it.

```cs
// Write file with previously defined episode and encoding (defined when reading the file)
svmap.Write("0_modified.svmap");

// Write file with a specific episode and default encoding
svmap.Write("0_modified.svmap", Episode.Ep6);

// Write file with a specific episode and a specific encoding
var windows1252Encoding = CodePagesEncodingProvider.Instance.GetEncoding(1252);
svmap.Write("0_modified.svmap", Episode.Ep6, windows1252Encoding);
```

#### Writing as JSON

Call the `WriteJson` method

```cs
svmap.WriteJson("map0.json");
```

#### Writing as CSV

Only some pre-Ep8 `SData` formats support exporting as `CSV`.
All of the Episode 8 `BinarySData` formats have `CSV` support.

```cs
// Write as csv
item.WriteCsv("Item.csv")
```

### Encoding

When writing files, the default encoding is `ASCII`. If you want to write a file with a different encoding, you can
specify it as a parameter when calling the `Write`, `WriteJson` and `WriteCsv` methods.

```cs

## Samples

### `sah/saf`

#### Read and extract

```cs
// Load data (sah and saf)
var data = new Data("data.sah");

// Find the file you want to extract
var file = data.GetFile("world/2.svmap");

// Extract the selected file
data.Extract(file, "extracted");
```

#### Data/Patch building

```cs
// Create data from directory
DataBuilder.CreateFromDirectory("input", "output");
```

#### Patch

```cs
// Load target data and patch data
var data = new Data("data.sah");
var update = new Data("update.sah");

// Patch data
using (var dataPatcher = new DataPatcher())
{
    dataPatcher.Patch(data, update);
}
```

### `SData`

#### Encryption / Decryption

SData encryption is slightly different for pre-Ep8 and Ep8 SData files. The `SDataVersion` enum is used to specify
which version of SData is being encrypted (it's not necessary when decrypting);

```cs
// Encrypt
SData.EncryptFile("NpcQuest.SData", "NpcQuest.encrypted.SData", SDataVersion.Regular);

// Decrypt
SData.DecryptFile("NpcQuest.SData", "NpcQuest.decrypted.SData");
```

More examples can be found in the [samples](https://github.com/matigramirez/Parsec/tree/main/samples) directory.
