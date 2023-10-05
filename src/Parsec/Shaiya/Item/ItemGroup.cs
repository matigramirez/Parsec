using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Item;

public sealed class ItemGroup : ISerializable
{
    public int MaxTypeId { get; set; }

    public List<ItemGroupRecord> ItemDefinitions { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        MaxTypeId = binaryReader.ReadInt32();
        ItemDefinitions = binaryReader.ReadList<ItemGroupRecord>(MaxTypeId).ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(MaxTypeId);
        binaryWriter.Write(ItemDefinitions.ToSerializable());
    }
}
