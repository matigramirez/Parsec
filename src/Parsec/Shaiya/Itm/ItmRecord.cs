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
    public int RecordFormat { get; set; }

    public int Unknown2 { get; set; }

    /// <summary>
    /// Present if <see cref="RecordFormat"/> is 1.
    /// </summary>
    public uint RGBA { get; set; }

    /// <summary>
    /// Present if <see cref="RecordFormat"/> is 1.
    /// </summary>
    public float Rotation { get; set; }

    /// <summary>
    /// Present if <see cref="RecordFormat"/> is 1.
    /// </summary>
    public float Scale { get; set; }

    /// <summary>
    /// Present if <see cref="RecordFormat"/> is 1.
    /// </summary>
    public int Unknown3 { get; set; }

    /// <summary>
    /// Present if <see cref="ItmFormat"/> is "IT2".
    /// 1024 unknown bytes. 32 blocks of 8 uint32.
    /// </summary>
    public byte[] Unknown4 { get; set; } = new byte[1024];

    public void Read(SBinaryReader binaryReader)
    {
        MeshIndex = binaryReader.ReadInt32();
        TextureIndex = binaryReader.ReadInt32();
        AlphaBlendingMode = (AlphaBlendingMode)binaryReader.ReadInt32();
        Unknown1 = binaryReader.ReadInt32();
        RecordFormat = binaryReader.ReadInt32();
        Unknown2 = binaryReader.ReadInt32();

        if (RecordFormat == 1)
        {
            RGBA = binaryReader.ReadUInt32();
            Rotation = binaryReader.ReadSingle();
            Scale = binaryReader.ReadSingle();
            Unknown3 = binaryReader.ReadInt32();
        }

        if (binaryReader.SerializationOptions.ExtraOption is ItmFormat.IT2)
        {
            Unknown4 = binaryReader.ReadBytes(1024);
        }
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(MeshIndex);
        binaryWriter.Write(TextureIndex);
        binaryWriter.Write((int)AlphaBlendingMode);
        binaryWriter.Write(Unknown1);
        binaryWriter.Write(RecordFormat);
        binaryWriter.Write(Unknown2);

        if (RecordFormat == 1)
        {
            binaryWriter.Write(RGBA);
            binaryWriter.Write(Rotation);
            binaryWriter.Write(Scale);
            binaryWriter.Write(Unknown3);
        }

        if (binaryWriter.SerializationOptions.ExtraOption is ItmFormat.IT2)
        {
            binaryWriter.Write(Unknown4);
        }
    }
}
