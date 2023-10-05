using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Skill;

public class SkillGroup : ISerializable
{
    /// <summary>
    /// SkillId is not part of the structure itself, instead, it's set based on the order of the skill groups.
    /// </summary>
    public int SkillId { get; set; }

    public List<SkillRecord> Records { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        if (binaryReader.SerializationOptions.ExtraOption is int skillId)
        {
            SkillId = skillId;
        }

        var recordCountPerGroup = GetRecordCountPerGroup(binaryReader.SerializationOptions.Episode);
        Records = binaryReader.ReadList<SkillRecord>(recordCountPerGroup).ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Records.ToSerializable());
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
