using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Env;

/// <summary>
/// Represents a V2 environment timeline.
/// </summary>
public sealed class Env : FileBase
{
    public const int MaximumRecordCount = 64;

    private const string ExpectedHeader = "V2";

    public string Header { get; set; } = ExpectedHeader;

    public List<EnvRecord> Records { get; set; } = new();

    public override string Extension => "env";

    protected override void Read(SBinaryReader binaryReader)
    {
        if (binaryReader.StreamLength < 6)
        {
            throw new InvalidDataException("The .ENV file does not contain a valid V2 header.");
        }

        try
        {
            var header = binaryReader.ReadBytes(ExpectedHeader.Length);
            if (header.Length != ExpectedHeader.Length || header[0] != (byte)'V' || header[1] != (byte)'2')
            {
                throw new InvalidDataException("The .ENV file does not contain a valid V2 header.");
            }

            Header = ExpectedHeader;

            var recordCount = binaryReader.ReadUInt32();
            if (recordCount == 0 || recordCount > MaximumRecordCount)
            {
                throw new InvalidDataException($"The .ENV file has an invalid record count of {recordCount}.");
            }

            Records = new List<EnvRecord>((int)recordCount);
            for (var i = 0; i < recordCount; i++)
            {
                Records.Add(binaryReader.Read<EnvRecord>());
            }

            if (binaryReader.Position != binaryReader.StreamLength)
            {
                throw new InvalidDataException($"The .ENV file has {binaryReader.StreamLength - binaryReader.Position} trailing bytes.");
            }
        }
        catch (EndOfStreamException exception)
        {
            throw new InvalidDataException("The .ENV file is truncated.", exception);
        }
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        if (Header != ExpectedHeader)
        {
            throw new InvalidDataException("An .ENV file must use the V2 header.");
        }

        if (Records == null || Records.Count == 0 || Records.Count > MaximumRecordCount)
        {
            throw new InvalidDataException($"An .ENV file must contain between 1 and {MaximumRecordCount} records.");
        }

        binaryWriter.Write(new[] { (byte)'V', (byte)'2' });
        binaryWriter.Write((uint)Records.Count);
        binaryWriter.Write(Records, lengthPrefixed: false);
    }
}
