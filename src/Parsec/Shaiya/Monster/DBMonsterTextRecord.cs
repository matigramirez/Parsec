using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Monster;

public sealed class DBMonsterTextRecord : IBinarySDataRecord
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt64();
        Name = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.Write(Name, includeStringTerminator: false);
    }
}
