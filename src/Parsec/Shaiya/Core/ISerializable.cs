using Parsec.Serialization;

namespace Parsec.Shaiya.Core;

public interface ISerializable
{
    void Read(SBinaryReader binaryReader);

    void Write(SBinaryWriter binaryWriter);
}
