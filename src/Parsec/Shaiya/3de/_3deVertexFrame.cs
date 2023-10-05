using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3de;

public sealed class _3deVertexFrame : ISerializable
{
    /// <summary>
    /// The vertex coordinates
    /// </summary>
    public Vector3 Coordinates { get; set; }

    /// <summary>
    /// The vertex UV mapping
    /// </summary>
    public Vector2 UV { get; set; }


    public void Read(SBinaryReader binaryReader)
    {
        Coordinates = binaryReader.Read<Vector3>();
        UV = binaryReader.Read<Vector2>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Coordinates);
        binaryWriter.Write(UV);
    }
}
