using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SetItem;

public class SetItemSynergy : ISerializable
{
    public string Synergy { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Synergy = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Synergy);
    }
}
