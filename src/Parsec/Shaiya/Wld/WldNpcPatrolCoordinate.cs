using Newtonsoft.Json;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

public sealed class WldNpcPatrolCoordinate : IBinary
{
    public Vector3 Position { get; set; }

    [JsonConstructor]
    public WldNpcPatrolCoordinate()
    {
    }

    public WldNpcPatrolCoordinate(SBinaryReader binaryReader)
    {
        Position = new Vector3(binaryReader);
    }

    public IEnumerable<byte> GetBytes(params object[] options) => Position.GetBytes();
}
