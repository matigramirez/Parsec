using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class Ladder : IBinary
{
    [JsonConstructor]
    public Ladder()
    {
    }

    public Ladder(SBinaryReader binaryReader)
    {
        Position = new Vector3(binaryReader);
    }

    public Vector3 Position { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options) => Position.GetBytes();
}
