using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.SetItem;

public sealed class DBSetItemTextRecord : IBinarySDataRecord
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public long SetEff1 { get; set; }

    public long SetEff2 { get; set; }

    public long SetEff3 { get; set; }

    public long SetEff4 { get; set; }

    public long SetEff5 { get; set; }

    public long SetEff6 { get; set; }

    public long SetEff7 { get; set; }

    public long SetEff8 { get; set; }

    public long SetEff9 { get; set; }

    public long SetEff10 { get; set; }

    public long SetEff11 { get; set; }

    public long SetEff12 { get; set; }

    public long SetEff13 { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt64();
        Name = binaryReader.ReadString();
        SetEff1 = binaryReader.ReadInt64();
        SetEff2 = binaryReader.ReadInt64();
        SetEff3 = binaryReader.ReadInt64();
        SetEff4 = binaryReader.ReadInt64();
        SetEff5 = binaryReader.ReadInt64();
        SetEff6 = binaryReader.ReadInt64();
        SetEff7 = binaryReader.ReadInt64();
        SetEff8 = binaryReader.ReadInt64();
        SetEff9 = binaryReader.ReadInt64();
        SetEff10 = binaryReader.ReadInt64();
        SetEff11 = binaryReader.ReadInt64();
        SetEff12 = binaryReader.ReadInt64();
        SetEff13 = binaryReader.ReadInt64();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.Write(Name, false);
        binaryWriter.Write(SetEff1);
        binaryWriter.Write(SetEff2);
        binaryWriter.Write(SetEff3);
        binaryWriter.Write(SetEff4);
        binaryWriter.Write(SetEff5);
        binaryWriter.Write(SetEff6);
        binaryWriter.Write(SetEff7);
        binaryWriter.Write(SetEff8);
        binaryWriter.Write(SetEff9);
        binaryWriter.Write(SetEff10);
        binaryWriter.Write(SetEff11);
        binaryWriter.Write(SetEff12);
        binaryWriter.Write(SetEff13);
    }
}
