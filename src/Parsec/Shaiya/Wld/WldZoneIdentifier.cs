using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public class WldZoneIdentifier : ISerializable
{
    public int Idenfitier { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Idenfitier = binaryReader.ReadInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Idenfitier);
    }
}
