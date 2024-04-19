using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Zon;

public sealed class Zon : FileBase
{
    public int Format { get; set; }

    public List<ZonRecord> Records { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        Format = binaryReader.ReadInt32();

        // Format is used as the ExtraOption on ZonRecord serialization
        binaryReader.SerializationOptions.ExtraOption = Format;
        Records = binaryReader.ReadList<ZonRecord>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Format);

        // Format is used as the ExtraOption on ZonRecord serialization
        binaryWriter.SerializationOptions.ExtraOption = Format;
        binaryWriter.Write(Records.ToSerializable());
    }
}
