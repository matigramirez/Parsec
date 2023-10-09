using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.KillStatus;

/// <summary>
/// Class that represents the KillStatus.SData file format.
/// This file contains the bonuses each faction receives based on bless of the goddess values.
/// </summary>
public sealed class KillStatus : SData.SData
{
    public List<KillStatusRecord> Records { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        Records = binaryReader.ReadList<KillStatusRecord>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Records.ToSerializable());
    }
}
