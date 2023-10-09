using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SetItem;

public sealed class SetItemRecord : ISerializable
{
    public ushort Index { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<SetItemRecordItem> Items { get; set; } = new();

    public List<SetItemSynergy> Synergies { get; set; } = new();


    public void Read(SBinaryReader binaryReader)
    {
        Index = binaryReader.ReadUInt16();
        Name = binaryReader.ReadString();
        Items = binaryReader.ReadList<SetItemRecordItem>(13).ToList();
        Synergies = binaryReader.ReadList<SetItemSynergy>(13).ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Index);
        binaryWriter.Write(Name);
        binaryWriter.Write(Items.Take(13).ToSerializable(), lengthPrefixed: false);
        binaryWriter.Write(Synergies.Take(13).ToSerializable(), lengthPrefixed: false);
    }
}
