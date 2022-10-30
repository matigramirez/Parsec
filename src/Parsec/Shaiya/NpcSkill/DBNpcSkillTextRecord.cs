using Parsec.Attributes;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.NpcSkill;

public sealed class DBNpcSkillTextRecord : IBinarySDataRecord
{
    [ShaiyaProperty]
    public long Id { get; set; }

    [ShaiyaProperty]
    public long SkillLevel { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedString(false)]
    public string Name { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedString(false)]
    public string Text { get; set; }
}
