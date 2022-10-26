using Parsec.Attributes;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.TransformModel;

public sealed class DBTransformWeaponModelDataRecord : IBinarySDataRecord
{
    [ShaiyaProperty]
    public long Type { get; set; }

    [ShaiyaProperty]
    public long Weapon { get; set; }

    [ShaiyaProperty]
    public long Weapon1 { get; set; }
}
