using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.TransformModel;

public sealed class DBTransformModelDataRecord : IBinarySDataRecord
{
    public long Id { get; set; }

    public long Top { get; set; }

    public long Hand { get; set; }

    public long Bottom { get; set; }

    public long Shoe { get; set; }

    public long Empty { get; set; }

    public long Helmet { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt64();
        Top = binaryReader.ReadInt64();
        Hand = binaryReader.ReadInt64();
        Bottom = binaryReader.ReadInt64();
        Shoe = binaryReader.ReadInt64();
        Empty = binaryReader.ReadInt64();
        Helmet = binaryReader.ReadInt64();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.Write(Top);
        binaryWriter.Write(Hand);
        binaryWriter.Write(Bottom);
        binaryWriter.Write(Shoe);
        binaryWriter.Write(Empty);
        binaryWriter.Write(Helmet);
    }
}
