using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftEffectGroup : ISerializable
{
    public string Name { get; set; } = string.Empty;

    public List<EftEffectGroupRecord> Records { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString();
        Records = binaryReader.ReadList<EftEffectGroupRecord>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Name);
        binaryWriter.Write(Records.ToSerializable());
    }
}
