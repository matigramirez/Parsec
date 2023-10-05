using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Seff;

public sealed class SeffRecord : ISerializable
{
    public int Id { get; set; }

    public List<SeffEffect> Effects { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt32();
        Effects = binaryReader.ReadList<SeffEffect>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.Write(Effects.ToSerializable());
    }
}
