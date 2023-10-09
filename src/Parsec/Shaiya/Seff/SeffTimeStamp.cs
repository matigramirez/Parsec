using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Seff;

public struct SeffTimeStamp : ISerializable
{
    public short Year;

    public short Month;

    public short Day;

    public short Hour;

    public short Minute;

    public short Second;

    public void Read(SBinaryReader binaryReader)
    {
        Year = binaryReader.ReadInt16();
        Month = binaryReader.ReadInt16();
        Day = binaryReader.ReadInt16();
        Hour = binaryReader.ReadInt16();
        Minute = binaryReader.ReadInt16();
        Second = binaryReader.ReadInt16();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Year);
        binaryWriter.Write(Month);
        binaryWriter.Write(Day);
        binaryWriter.Write(Hour);
        binaryWriter.Write(Minute);
        binaryWriter.Write(Second);
    }
}
