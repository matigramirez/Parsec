using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani;

public sealed class AniTranslationFrame : ISerializable
{
    public uint Frame { get; set; }

    public Vector3 Translation { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Frame = binaryReader.ReadUInt32();
        Translation = binaryReader.Read<Vector3>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Frame);
        binaryWriter.Write(Translation);
    }
}
