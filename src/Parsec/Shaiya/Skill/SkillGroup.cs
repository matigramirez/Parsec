using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Skill;

public class SkillGroup : ISerializable
{
    public List<SkillDefinition> SkillDefinitions { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        var recordCountPerGroup = GetRecordCountPerGroup(binaryReader.SerializationOptions.Episode);
        SkillDefinitions = binaryReader.ReadList<SkillDefinition>(recordCountPerGroup).ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var recordCount = GetRecordCountPerGroup(binaryWriter.SerializationOptions.Episode);
        binaryWriter.Write(SkillDefinitions.Take(recordCount).ToSerializable(), lengthPrefixed: false);
    }

    private int GetRecordCountPerGroup(Episode episode)
    {
        return episode switch
        {
            Episode.EP5 => 9,
            >= Episode.EP6 => 15,
            _ => 3
        };
    }
}
