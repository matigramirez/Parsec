using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani;

public sealed class AniRotationFrame : ISerializable
{
    public uint Frame { get; set; }

    public Quaternion Quaternion { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Frame = binaryReader.ReadUInt32();
        Quaternion = binaryReader.Read<Quaternion>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Frame);
        binaryWriter.Write(Quaternion);
    }
}
