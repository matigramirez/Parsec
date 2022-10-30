using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.ALT;

/// <summary>
/// Class that represents the ALT format which is used to define the available animations for characters.
/// This class has custom implementations of the <see cref="Read"/> and <see cref="GetBytes"/> methods because its subclass <see cref="Animation"/>
/// has a serialization anti-pattern.
/// </summary>
public sealed class ALT : FileBase
{
    public string Signature { get; set; }
    public List<Animation> Animations { get; } = new();

    public override string Extension => ".ALT";

    public override void Read(params object[] options)
    {
        Signature = _binaryReader.ReadString(3);

        int animationCount = _binaryReader.Read<int>();
        for (int i = 0; i < animationCount; i++)
        {
            var animation = new Animation(_binaryReader);
            Animations.Add(animation);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Signature.GetBytes());
        buffer.AddRange(Animations.GetBytes());
        return buffer;
    }
}
