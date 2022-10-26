using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MON;

public sealed class MONRecord : IBinary
{
    [JsonConstructor]
    public MONRecord()
    {
    }

    public MONRecord(SBinaryReader binaryReader, MONFormat format)
    {
        Name = binaryReader.ReadString();
        Unknown = binaryReader.Read<byte>();
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

        if (format == MONFormat.MO4)
            AttachEffect = binaryReader.ReadString();

        var objectCount = binaryReader.Read<int>();

        for (int i = 0; i < objectCount; i++)
        {
            var obj = new MONObject(binaryReader);
            Objects.Add(obj);
        }

        Height = binaryReader.Read<float>();

        var effectCount = binaryReader.Read<int>();

        for (int i = 0; i < effectCount; i++)
        {
            var effect = new MONEffect(binaryReader);
            Effects.Add(effect);
        }
    }

    public string Name { get; set; }
    public byte Unknown { get; set; }
    public string WalkAnimation { get; set; }
    public string RunAnimation { get; set; }

    /// <summary>
    /// Jump or Attack1 animation. Jump for vehicles, Attack1 for mobs.
    /// </summary>
    public string JumpAttack1Animation { get; set; }

    public string Attack2Animation { get; set; }
    public string Attack3Animation { get; set; }
    public string DeathAnimation { get; set; }
    public string BreathAnimation { get; set; }
    public string DamageAnimation { get; set; }
    public string IdleAnimation { get; set; }

    public string Attack1Wav { get; set; }
    public string Attack2Wav { get; set; }
    public string Attack3Wav { get; set; }
    public string DeathWav { get; set; }

    public string Attack1Effect { get; set; }
    public string Attack2Effect { get; set; }
    public string Attack3Effect { get; set; }
    public string DieEffect { get; set; }
    public string AttachEffect { get; set; }

    public List<MONObject> Objects { get; } = new();

    public float Height { get; set; }

    public List<MONEffect> Effects { get; } = new();

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var outputFormat = MONFormat.MO2;

        if (options.Length > 0)
            outputFormat = (MONFormat)options[0];

        var buffer = new List<byte>();
        buffer.AddRange(Name.GetLengthPrefixedBytes(false));
        buffer.Add(Unknown);
        buffer.AddRange(WalkAnimation.GetLengthPrefixedBytes(false));
        buffer.AddRange(RunAnimation.GetLengthPrefixedBytes(false));
        buffer.AddRange(JumpAttack1Animation.GetLengthPrefixedBytes(false));

        buffer.AddRange(Attack2Animation.GetLengthPrefixedBytes(false));
        buffer.AddRange(Attack3Animation.GetLengthPrefixedBytes(false));
        buffer.AddRange(DeathAnimation.GetLengthPrefixedBytes(false));
        buffer.AddRange(BreathAnimation.GetLengthPrefixedBytes(false));
        buffer.AddRange(DamageAnimation.GetLengthPrefixedBytes(false));
        buffer.AddRange(IdleAnimation.GetLengthPrefixedBytes(false));

        buffer.AddRange(Attack1Wav.GetLengthPrefixedBytes(false));
        buffer.AddRange(Attack2Wav.GetLengthPrefixedBytes(false));
        buffer.AddRange(Attack3Wav.GetLengthPrefixedBytes(false));
        buffer.AddRange(DeathWav.GetLengthPrefixedBytes(false));

        buffer.AddRange(Attack1Effect.GetLengthPrefixedBytes(false));
        buffer.AddRange(Attack2Effect.GetLengthPrefixedBytes(false));
        buffer.AddRange(Attack3Effect.GetLengthPrefixedBytes(false));
        buffer.AddRange(DieEffect.GetLengthPrefixedBytes(false));

        if (outputFormat == MONFormat.MO4)
            buffer.AddRange(AttachEffect.GetLengthPrefixedBytes(false));

        buffer.AddRange(Objects.GetBytes());
        buffer.AddRange(Height.GetBytes());
        buffer.AddRange(Effects.GetBytes());

        return buffer;
    }
}
