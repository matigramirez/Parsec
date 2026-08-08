using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Itm;

public sealed class ItmRecord : ISerializable
{
    /// <summary>
    /// Index of the .3DO filename
    /// </summary>
    public int MeshIndex { get; set; }

    /// <summary>
    /// Index of the .DDS filename
    /// </summary>
    public int TextureIndex { get; set; }

    public AlphaBlendingMode AlphaBlendingMode { get; set; }

    public int Unknown1 { get; set; }

    /// <summary>
    /// Record format. 0 or 1.
    /// </summary>
    public ItmRecordFormat RecordFormat { get; set; }

    public int Unknown2 { get; set; }

    /// <summary>
    /// Present if <see cref="RecordFormat"/> is Extended.
    /// </summary>
    public uint RGBA { get; set; }

    /// <summary>
    /// Present if <see cref="RecordFormat"/> is Extended.
    /// </summary>
    public float Rotation { get; set; }

    /// <summary>
    /// Present if <see cref="RecordFormat"/> is Extended.
    /// </summary>
    public float Scale { get; set; }

    /// <summary>
    /// Present if <see cref="RecordFormat"/> is Extended.
    /// </summary>
    public int Unknown3 { get; set; }

    /// <summary>
    /// Present if <see cref="ItmFormat"/> is "IT2". IT2 stores two bone,
    /// position, and quaternion transforms for each of its sixteen character
    /// archetypes.
    /// </summary>
    public List<ItmCharacterTransforms> CharacterTransforms { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        MeshIndex = binaryReader.ReadInt32();
        TextureIndex = binaryReader.ReadInt32();
        AlphaBlendingMode = (AlphaBlendingMode)binaryReader.ReadInt32();
        Unknown1 = binaryReader.ReadInt32();
        RecordFormat = (ItmRecordFormat)binaryReader.ReadInt32();
        Unknown2 = binaryReader.ReadInt32();

        if (RecordFormat == ItmRecordFormat.Extended)
        {
            RGBA = binaryReader.ReadUInt32();
            Rotation = binaryReader.ReadSingle();
            Scale = binaryReader.ReadSingle();
            Unknown3 = binaryReader.ReadInt32();
        }

        if (binaryReader.SerializationOptions.ExtraOption is ItmFormat.IT2)
        {
            CharacterTransforms = new List<ItmCharacterTransforms>(16);
            for (var characterIndex = 0; characterIndex < 16; characterIndex++)
            {
                var transforms = binaryReader.Read<ItmCharacterTransforms>();
                transforms.CharacterCode = (ItmCharacterCode)characterIndex;
                CharacterTransforms.Add(transforms);
            }
        }
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(MeshIndex);
        binaryWriter.Write(TextureIndex);
        binaryWriter.Write((int)AlphaBlendingMode);
        binaryWriter.Write(Unknown1);
        binaryWriter.Write((int)RecordFormat);
        binaryWriter.Write(Unknown2);

        if (RecordFormat == ItmRecordFormat.Extended)
        {
            binaryWriter.Write(RGBA);
            binaryWriter.Write(Rotation);
            binaryWriter.Write(Scale);
            binaryWriter.Write(Unknown3);
        }

        if (binaryWriter.SerializationOptions.ExtraOption is ItmFormat.IT2)
        {
            for (var characterIndex = 0; characterIndex < 16; characterIndex++)
            {
                var characterCode = (ItmCharacterCode)characterIndex;
                var matches = CharacterTransforms
                    .Where(transforms => transforms.CharacterCode == characterCode)
                    .ToList();

                if (matches.Count != 1)
                {
                    throw new InvalidDataException(
                        $"IT2 records require exactly one transform pair for {characterCode}.");
                }

                binaryWriter.Write(matches[0]);
            }
        }
    }
}
