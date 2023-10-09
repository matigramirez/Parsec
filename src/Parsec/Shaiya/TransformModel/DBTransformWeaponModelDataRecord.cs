using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.TransformModel;

public sealed class DBTransformWeaponModelDataRecord : IBinarySDataRecord
{
    public long Type { get; set; }

    public long Weapon { get; set; }

    public long Weapon1 { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Type = binaryReader.ReadInt64();
        Weapon = binaryReader.ReadInt64();
        Weapon1 = binaryReader.ReadInt64();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Type);
        binaryWriter.Write(Weapon);
        binaryWriter.Write(Weapon1);
    }
}
