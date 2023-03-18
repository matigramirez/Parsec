using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SMOD;

/// <summary>
/// Represents a vertex used in SMOD collision objects
/// </summary>
public sealed class SimpleVertex : IBinary
{
    /// <summary>
    /// Coordinates of the vertex in the 3D space.
    /// </summary>
    public Vector3 Coordinates { get; set; }

    [JsonConstructor]
    public SimpleVertex()
    {
    }

    public SimpleVertex(SBinaryReader binaryReader)
    {
        Coordinates = new Vector3(binaryReader);
    }

    /// <inheritdoc />
    public IEnumerable<byte> GetBytes(params object[] options) => Coordinates.GetBytes();
}
