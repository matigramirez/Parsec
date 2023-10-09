using System.Text;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SData;

public sealed class BinarySDataField : ISerializable
{
    public string Name { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        var length = binaryReader.ReadByte();
        Name = binaryReader.ReadString(Encoding.Unicode, length);
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var length = (byte)Name.Length;
        binaryWriter.Write(length);
        binaryWriter.Write(Name, Encoding.Unicode, isLengthPrefixed: false, includeStringTerminator: false);
    }

    public static implicit operator string(BinarySDataField field) => field.Name;

    public static implicit operator BinarySDataField(string fieldName) => new BinarySDataField { Name = fieldName };

    public override string ToString() => Name;
}
