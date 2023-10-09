using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.SetItem;

public sealed class DBSetItemTextRecord : IBinarySDataRecord
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string SetEff1 { get; set; } = string.Empty;

    public string SetEff2 { get; set; } = string.Empty;

    public string SetEff3 { get; set; } = string.Empty;

    public string SetEff4 { get; set; } = string.Empty;

    public string SetEff5 { get; set; } = string.Empty;

    public string SetEff6 { get; set; } = string.Empty;

    public string SetEff7 { get; set; } = string.Empty;

    public string SetEff8 { get; set; } = string.Empty;

    public string SetEff9 { get; set; } = string.Empty;

    public string SetEff10 { get; set; } = string.Empty;

    public string SetEff11 { get; set; } = string.Empty;

    public string SetEff12 { get; set; } = string.Empty;

    public string SetEff13 { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt64();
        Name = binaryReader.ReadString();
        SetEff1 = binaryReader.ReadString();
        SetEff2 = binaryReader.ReadString();
        SetEff3 = binaryReader.ReadString();
        SetEff4 = binaryReader.ReadString();
        SetEff5 = binaryReader.ReadString();
        SetEff6 = binaryReader.ReadString();
        SetEff7 = binaryReader.ReadString();
        SetEff8 = binaryReader.ReadString();
        SetEff9 = binaryReader.ReadString();
        SetEff10 = binaryReader.ReadString();
        SetEff11 = binaryReader.ReadString();
        SetEff12 = binaryReader.ReadString();
        SetEff13 = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.Write(Name, includeStringTerminator: false);
        binaryWriter.Write(SetEff1, includeStringTerminator: false);
        binaryWriter.Write(SetEff2, includeStringTerminator: false);
        binaryWriter.Write(SetEff3, includeStringTerminator: false);
        binaryWriter.Write(SetEff4, includeStringTerminator: false);
        binaryWriter.Write(SetEff5, includeStringTerminator: false);
        binaryWriter.Write(SetEff6, includeStringTerminator: false);
        binaryWriter.Write(SetEff7, includeStringTerminator: false);
        binaryWriter.Write(SetEff8, includeStringTerminator: false);
        binaryWriter.Write(SetEff9, includeStringTerminator: false);
        binaryWriter.Write(SetEff10, includeStringTerminator: false);
        binaryWriter.Write(SetEff11, includeStringTerminator: false);
        binaryWriter.Write(SetEff12, includeStringTerminator: false);
        binaryWriter.Write(SetEff13, includeStringTerminator: false);
    }
}
