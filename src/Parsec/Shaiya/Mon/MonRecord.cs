using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Mon;

public sealed class MonRecord : ISerializable
{
    public string Name { get; set; } = string.Empty;

    public byte Unknown { get; set; }

    public string WalkAnimation { get; set; } = string.Empty;

    public string RunAnimation { get; set; } = string.Empty;

    /// <summary>
    /// Jump or Attack1 animation. Jump for vehicles, Attack1 for mobs.
    /// </summary>
    public string JumpAttack1Animation { get; set; } = string.Empty;

    public string Attack2Animation { get; set; } = string.Empty;

    public string Attack3Animation { get; set; } = string.Empty;

    public string DeathAnimation { get; set; } = string.Empty;

    public string BreathAnimation { get; set; } = string.Empty;

    public string DamageAnimation { get; set; } = string.Empty;

    public string IdleAnimation { get; set; } = string.Empty;

    public string Attack1Wav { get; set; } = string.Empty;

    public string Attack2Wav { get; set; } = string.Empty;

    public string Attack3Wav { get; set; } = string.Empty;

    public string DeathWav { get; set; } = string.Empty;

    public string Attack1Effect { get; set; } = string.Empty;

    public string Attack2Effect { get; set; } = string.Empty;

    public string Attack3Effect { get; set; } = string.Empty;

    public string DieEffect { get; set; } = string.Empty;

    public string AttachEffect { get; set; } = string.Empty;

    public List<MonObject> Objects { get; set; } = new();

    public float Height { get; set; }

    public List<MonEffect> Effects { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        var format = MonFormat.MO2;

        if (binaryReader.SerializationOptions.ExtraOption is MonFormat optionFormat)
        {
            format = optionFormat;
        }

        Name = binaryReader.ReadString();
        Unknown = binaryReader.ReadByte();
        WalkAnimation = binaryReader.ReadString();
        RunAnimation = binaryReader.ReadString();
        JumpAttack1Animation = binaryReader.ReadString();
        Attack2Animation = binaryReader.ReadString();
        Attack3Animation = binaryReader.ReadString();
        DeathAnimation = binaryReader.ReadString();
        BreathAnimation = binaryReader.ReadString();
        DamageAnimation = binaryReader.ReadString();
        IdleAnimation = binaryReader.ReadString();

        Attack1Wav = binaryReader.ReadString();
        Attack2Wav = binaryReader.ReadString();
        Attack3Wav = binaryReader.ReadString();
        DeathWav = binaryReader.ReadString();

        Attack1Effect = binaryReader.ReadString();
        Attack2Effect = binaryReader.ReadString();
        Attack3Effect = binaryReader.ReadString();
        DieEffect = binaryReader.ReadString();

        if (format == MonFormat.MO4)
        {
            AttachEffect = binaryReader.ReadString();
        }

        Objects = binaryReader.ReadList<MonObject>().ToList();
        Height = binaryReader.ReadSingle();
        Effects = binaryReader.ReadList<MonEffect>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var format = MonFormat.MO2;

        if (binaryWriter.SerializationOptions.ExtraOption is MonFormat optionFormat)
        {
            format = optionFormat;
        }

        binaryWriter.Write(Name);
        binaryWriter.Write(Unknown);
        binaryWriter.Write(WalkAnimation);
        binaryWriter.Write(RunAnimation);
        binaryWriter.Write(JumpAttack1Animation);
        binaryWriter.Write(Attack2Animation);
        binaryWriter.Write(Attack3Animation);
        binaryWriter.Write(DeathAnimation);
        binaryWriter.Write(BreathAnimation);
        binaryWriter.Write(DamageAnimation);
        binaryWriter.Write(IdleAnimation);

        binaryWriter.Write(Attack1Wav);
        binaryWriter.Write(Attack2Wav);
        binaryWriter.Write(Attack3Wav);
        binaryWriter.Write(DeathWav);

        binaryWriter.Write(Attack1Effect);
        binaryWriter.Write(Attack2Effect);
        binaryWriter.Write(Attack3Effect);
        binaryWriter.Write(DieEffect);

        if (format == MonFormat.MO4)
        {
            binaryWriter.Write(AttachEffect);
        }

        binaryWriter.Write(Objects.ToSerializable());
        binaryWriter.Write(Height);
        binaryWriter.Write(Effects.ToSerializable());
    }
}
