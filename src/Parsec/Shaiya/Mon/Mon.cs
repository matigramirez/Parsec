using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Mon;

public sealed class Mon : FileBase
{
    /// <summary>
    /// File signature. "MO2", "MO4". Read as char[3]
    /// </summary>
    public string Signature { get; set; } = string.Empty;

    public MonFormat Format { get; set; } = MonFormat.MO2;

    public List<MonRecord> Records { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        Signature = binaryReader.ReadString(3);

        switch (Signature)
        {
            case "MO2":
            default:
                Format = MonFormat.MO2;
                break;
            case "MO4":
                Format = MonFormat.MO4;
                break;
        }

        // Record instances expect the Format to be set as the ExtraOption on the serialization options
        binaryReader.SerializationOptions.ExtraOption = Format;
        Records = binaryReader.ReadList<MonRecord>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        // Record instances expect the Format to be set as the ExtraOption on the serialization options
        binaryWriter.SerializationOptions.ExtraOption = Format;

        binaryWriter.Write(Signature, isLengthPrefixed: false, includeStringTerminator: false);
        binaryWriter.Write(Records.ToSerializable());
    }
}
