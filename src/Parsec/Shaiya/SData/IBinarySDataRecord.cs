using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SData;

public interface IBinarySDataRecord : IBinary
{
    void Read(SBinaryReader binaryReader, params object[] options);
}
