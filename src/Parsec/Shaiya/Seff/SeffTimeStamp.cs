using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Seff;

public class SeffTimeStamp : ISerializable
{
    public short Year { get; set; }

    public short Month { get; set; }

    public short Day { get; set; }

    public short Hour { get; set; }

    public short Minute { get; set; }

    public short Second { get; set; }

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
