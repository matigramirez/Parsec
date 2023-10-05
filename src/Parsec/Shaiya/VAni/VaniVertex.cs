using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Vani;

public sealed class VaniVertex : ISerializable
{
    public List<VaniVertexFrame> Frames { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Frames = binaryReader.ReadList<VaniVertexFrame>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Frames.ToSerializable());
    }
}
