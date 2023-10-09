using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.SetItem;

public sealed class DBSetItemDataRecord : IBinarySDataRecord
{
    public long Id { get; set; }

    public long Category1 { get; set; }

    public long Number1 { get; set; }

    public long Category2 { get; set; }

    public long Number2 { get; set; }

    public long Category3 { get; set; }

    public long Number3 { get; set; }

    public long Category4 { get; set; }

    public long Number4 { get; set; }

    public long Category5 { get; set; }

    public long Number5 { get; set; }

    public long Category6 { get; set; }

    public long Number6 { get; set; }

    public long Category7 { get; set; }

    public long Number7 { get; set; }

    public long Category8 { get; set; }

    public long Number8 { get; set; }

    public long Category9 { get; set; }

    public long Number9 { get; set; }

    public long Category10 { get; set; }

    public long Number10 { get; set; }

    public long Category11 { get; set; }

    public long Number11 { get; set; }

    public long Category12 { get; set; }

    public long Number12 { get; set; }

    public long Category13 { get; set; }

    public long Number13 { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt64();
        Category1 = binaryReader.ReadInt64();
        Number1 = binaryReader.ReadInt64();
        Category2 = binaryReader.ReadInt64();
        Number2 = binaryReader.ReadInt64();
        Category3 = binaryReader.ReadInt64();
        Number3 = binaryReader.ReadInt64();
        Category4 = binaryReader.ReadInt64();
        Number4 = binaryReader.ReadInt64();
        Category5 = binaryReader.ReadInt64();
        Number5 = binaryReader.ReadInt64();
        Category6 = binaryReader.ReadInt64();
        Number6 = binaryReader.ReadInt64();
        Category7 = binaryReader.ReadInt64();
        Number7 = binaryReader.ReadInt64();
        Category8 = binaryReader.ReadInt64();
        Number8 = binaryReader.ReadInt64();
        Category9 = binaryReader.ReadInt64();
        Number9 = binaryReader.ReadInt64();
        Category10 = binaryReader.ReadInt64();
        Number10 = binaryReader.ReadInt64();
        Category11 = binaryReader.ReadInt64();
        Number11 = binaryReader.ReadInt64();
        Category12 = binaryReader.ReadInt64();
        Number12 = binaryReader.ReadInt64();
        Category13 = binaryReader.ReadInt64();
        Number13 = binaryReader.ReadInt64();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.Write(Category1);
        binaryWriter.Write(Number1);
        binaryWriter.Write(Category2);
        binaryWriter.Write(Number2);
        binaryWriter.Write(Category3);
        binaryWriter.Write(Number3);
        binaryWriter.Write(Category4);
        binaryWriter.Write(Number4);
        binaryWriter.Write(Category5);
        binaryWriter.Write(Number5);
        binaryWriter.Write(Category6);
        binaryWriter.Write(Number6);
        binaryWriter.Write(Category7);
        binaryWriter.Write(Number7);
        binaryWriter.Write(Category8);
        binaryWriter.Write(Number8);
        binaryWriter.Write(Category9);
        binaryWriter.Write(Number9);
        binaryWriter.Write(Category10);
        binaryWriter.Write(Number10);
        binaryWriter.Write(Category11);
        binaryWriter.Write(Number11);
        binaryWriter.Write(Category12);
        binaryWriter.Write(Number12);
        binaryWriter.Write(Category13);
        binaryWriter.Write(Number13);
    }
}
