using Newtonsoft.Json;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cloak.Physics;

/// <summary>
/// Represents a .PC cloak-physics configuration.
/// </summary>
public sealed class Pc : FileBase
{
    public const int MaximumMeshReferenceCount = 1024;
    public const int MaximumClothLinkCount = 4096;

    /// <summary>
    /// Flexible .3DC meshes used by the cloth simulation.
    /// </summary>
    public List<PcMeshReference> FlexibleMeshes { get; set; } = new();

    /// <summary>
    /// Links between flexible cloth meshes, textures, rigid meshes, and skeleton anchors.
    /// </summary>
    public List<PcClothLink> Links { get; set; } = new();

    /// <summary>
    /// Rigid .3DC meshes used to bind the cloth to an animated skeleton.
    /// </summary>
    public List<PcMeshReference> RigidMeshes { get; set; } = new();

    [JsonIgnore]
    public override string Extension => "PC";

    protected override void Read(SBinaryReader binaryReader)
    {
        var flexibleMeshCount = ReadCount(binaryReader, PcMeshReference.SerializedSize, MaximumMeshReferenceCount, "flexible mesh");
        FlexibleMeshes = binaryReader.ReadList<PcMeshReference>(flexibleMeshCount);

        var linkCount = ReadCount(binaryReader, PcClothLink.SerializedSize, MaximumClothLinkCount, "cloth link");
        Links = binaryReader.ReadList<PcClothLink>(linkCount);

        var rigidMeshCount = ReadCount(binaryReader, PcMeshReference.SerializedSize, MaximumMeshReferenceCount, "rigid mesh");
        RigidMeshes = binaryReader.ReadList<PcMeshReference>(rigidMeshCount);

        if (binaryReader.Position != binaryReader.StreamLength)
        {
            throw new InvalidDataException($"The .PC file has {binaryReader.StreamLength - binaryReader.Position} trailing bytes.");
        }

        ValidateStructure();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        ValidateStructure();

        binaryWriter.Write((uint)FlexibleMeshes.Count);
        binaryWriter.Write(FlexibleMeshes, lengthPrefixed: false);

        binaryWriter.Write((uint)Links.Count);
        binaryWriter.Write(Links, lengthPrefixed: false);

        binaryWriter.Write((uint)RigidMeshes.Count);
        binaryWriter.Write(RigidMeshes, lengthPrefixed: false);
    }

    private static int ReadCount(SBinaryReader binaryReader, int recordSize, int maximum, string sectionName)
    {
        var count = binaryReader.ReadUInt32();
        var remainingByteCount = binaryReader.StreamLength - binaryReader.Position;

        if (count > maximum || (long)count * recordSize > remainingByteCount)
        {
            throw new InvalidDataException($"The .PC file has an invalid {sectionName} count of {count}.");
        }

        return (int)count;
    }

    private void ValidateStructure()
    {
        if (FlexibleMeshes.Count > MaximumMeshReferenceCount)
        {
            throw new InvalidDataException($"A .PC file cannot contain more than {MaximumMeshReferenceCount} flexible meshes.");
        }

        if (Links.Count > MaximumClothLinkCount)
        {
            throw new InvalidDataException($"A .PC file cannot contain more than {MaximumClothLinkCount} cloth links.");
        }

        if (RigidMeshes.Count > MaximumMeshReferenceCount)
        {
            throw new InvalidDataException($"A .PC file cannot contain more than {MaximumMeshReferenceCount} rigid meshes.");
        }

        for (var i = 0; i < Links.Count; i++)
        {
            var link = Links[i];
            if (link.ClothMeshIndex < 0 || link.ClothMeshIndex >= FlexibleMeshes.Count)
            {
                throw new InvalidDataException($"Cloth link {i} has an invalid flexible mesh index of {link.ClothMeshIndex}.");
            }

            if (link.RigidMeshIndex < 0 || link.RigidMeshIndex >= RigidMeshes.Count)
            {
                throw new InvalidDataException($"Cloth link {i} has an invalid rigid mesh index of {link.RigidMeshIndex}.");
            }
        }
    }
}
