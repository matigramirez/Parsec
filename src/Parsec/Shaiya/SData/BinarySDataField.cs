using System.Text;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SData;

public sealed class BinarySDataField : IBinary
{
    public BinarySDataField(string name)
    {
        Name = name;
    }

    [JsonConstructor]
    public BinarySDataField()
    {
    }

    public BinarySDataField(SBinaryReader binaryReader)
    {
        int length = binaryReader.Read<byte>();
        Name = binaryReader.ReadString(Encoding.Unicode, length);
    }

    public string Name { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.Add((byte)Name.Length);
        buffer.AddRange(Name.GetBytes(Encoding.Unicode));
        return buffer;
    }
}
