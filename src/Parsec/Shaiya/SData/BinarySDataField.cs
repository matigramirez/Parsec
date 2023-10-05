using System.Text;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SData;

public sealed class BinarySDataField : ISerializable
{
    public string Name { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString(Encoding.Unicode);
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Name, Encoding.Unicode);
    }

    public static implicit operator string(BinarySDataField field) => field.Name;

    public static implicit operator BinarySDataField(string fieldName) => new BinarySDataField { Name = fieldName };

    public override string ToString() => Name;
}
