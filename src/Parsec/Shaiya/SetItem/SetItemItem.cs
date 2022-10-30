using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SetItem;

public sealed class SetItemItem : IBinary
{
    [JsonConstructor]
    public SetItemItem()
    {
    }

    public SetItemItem(SBinaryReader binaryReader)
    {
        Type = binaryReader.Read<short>();
        TypeId = binaryReader.Read<short>();
    }

    public short Type { get; set; }
    public short TypeId { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Type.GetBytes());
        buffer.AddRange(TypeId.GetBytes());
        return buffer;
    }
}
