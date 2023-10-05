using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.NpcSkill;

public sealed class DBNpcSkillTextRecord : IBinarySDataRecord
{
    public long Id { get; set; }

    public long SkillLevel { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt64();
        SkillLevel = binaryReader.ReadInt64();
        Name = binaryReader.ReadString();
        Text = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.Write(SkillLevel);
        binaryWriter.Write(Name, false);
        binaryWriter.Write(Text, false);
    }
}
