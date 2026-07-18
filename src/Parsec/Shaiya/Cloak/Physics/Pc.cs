using Newtonsoft.Json;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cloak.Physics;

/// <summary>
/// Represents a .PC cloak-physics configuration.
/// </summary>
public sealed class Pc : FileBase
{
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
        var flexibleMeshCount = ReadCount(binaryReader, PcMeshReference.SerializedSize, "flexible mesh");
        FlexibleMeshes = binaryReader.ReadList<PcMeshReference>(flexibleMeshCount);

        var linkCount = ReadCount(binaryReader, PcClothLink.SerializedSize, "cloth link");
        Links = binaryReader.ReadList<PcClothLink>(linkCount);

        var rigidMeshCount = ReadCount(binaryReader, PcMeshReference.SerializedSize, "rigid mesh");
        RigidMeshes = binaryReader.ReadList<PcMeshReference>(rigidMeshCount);

        if (binaryReader.Position != binaryReader.StreamLength)
        {
            throw new InvalidDataException($"The .PC file has {binaryReader.StreamLength - binaryReader.Position} trailing bytes.");
        }
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write((uint)FlexibleMeshes.Count);
        binaryWriter.Write(FlexibleMeshes, lengthPrefixed: false);

        binaryWriter.Write((uint)Links.Count);
        binaryWriter.Write(Links, lengthPrefixed: false);

        binaryWriter.Write((uint)RigidMeshes.Count);
        binaryWriter.Write(RigidMeshes, lengthPrefixed: false);
    }

    private static int ReadCount(SBinaryReader binaryReader, int recordSize, string sectionName)
    {
        var count = binaryReader.ReadUInt32();
        var remainingByteCount = binaryReader.StreamLength - binaryReader.Position;

        if (count > int.MaxValue || (long)count * recordSize > remainingByteCount)
        {
            throw new InvalidDataException($"The .PC file has an invalid {sectionName} count of {count}.");
        }

        return (int)count;
    }
}
