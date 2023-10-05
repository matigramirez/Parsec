using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.Skill;

public sealed class Skill : SData.SData
{
    public List<SkillGroup> SkillGroups { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        var skillGroupCount = binaryReader.ReadInt32();

        for (var skillGroupId = 0; skillGroupId < skillGroupCount; skillGroupId++)
        {
            binaryReader.SerializationOptions.ExtraOption = skillGroupId;
            var skillGroup = binaryReader.Read<SkillGroup>();
            SkillGroups.Add(skillGroup);
        }
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(SkillGroups.ToSerializable());
    }

    // TODO: Add support for CSV serialization
}
