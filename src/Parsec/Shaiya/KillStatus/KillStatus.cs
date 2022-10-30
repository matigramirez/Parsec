using Parsec.Attributes;
using Parsec.Common;

namespace Parsec.Shaiya.KillStatus;

/// <summary>
/// Class that represents the KillStatus.SData file format.
/// This file contains the bonuses each faction receives based on bless of the goddess values.
/// </summary>
[DefaultVersion(Episode.EP5)]
public sealed class KillStatus : SData.SData
{
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(KillStatusRecord))]
    public List<KillStatusRecord> Records { get; set; } = new();
}
