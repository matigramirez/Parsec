using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

public sealed class PatrolCoordinate : IBinary
{
    public Vector3 Position { get; set; }

    [JsonConstructor]
    public PatrolCoordinate()
    {
    }

    public PatrolCoordinate(SBinaryReader binaryReader)
    {
        Position = new Vector3(binaryReader);
    }

    public IEnumerable<byte> GetBytes(params object[] options) => Position.GetBytes();
}
