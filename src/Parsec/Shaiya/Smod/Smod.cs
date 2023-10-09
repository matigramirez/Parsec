using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Smod;

/// <summary>
/// Class that represents a .SMOD object which is used for buildings.
/// Buildings can be made up of multiple parts, each with its individual texture.
/// Collision objects are also included in this format in a separate list of texture-less objects.
/// </summary>
public sealed class Smod : FileBase
{
    [JsonIgnore]
    public override string Extension => "SMOD";

    /// <summary>
    /// The center of the SMOD object as a whole (center of all objects)
    /// </summary>
    public Vector3 Center { get; set; }

    /// <summary>
    /// The distance between the vertices of the <see cref="BoundingBox"/> and the <see cref="Center"/> of the SMOD object. Used for game calculations.
    /// </summary>
    public float DistanceToCenter { get; set; }

    /// <summary>
    /// Box that surrounds the textured objects. Used for game calculations.
    /// It's used by the game to easily determine where there are objects present, so that the player view doesn't get obstructed
    /// (when the camera is placed in the position of an object, the view is zoomed to avoid having the object in the viewport).
    /// </summary>
    public BoundingBox ViewBox { get; set; }

    /// <summary>
    /// List of textured objects
    /// </summary>
    public List<SmodMesh> TexturedObjects { get; set; } = new();

    /// <summary>
    /// Box that defines the area where collisions should take place. Collision objects that are outside this box are ignored.
    /// </summary>
    public BoundingBox CollisionBox { get; set; }

    /// <summary>
    /// List of texture-less objects used for collisions
    /// </summary>
    public List<SmodCollisionMesh> CollisionObjects { get; set; } = new();

    /// <inheritdoc />
    protected override void Read(SBinaryReader binaryReader)
    {
        Center = binaryReader.Read<Vector3>();
        DistanceToCenter = binaryReader.ReadSingle();
        ViewBox = binaryReader.Read<BoundingBox>();
        TexturedObjects = binaryReader.ReadList<SmodMesh>().ToList();
        CollisionBox = binaryReader.Read<BoundingBox>();
        CollisionObjects = binaryReader.ReadList<SmodCollisionMesh>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Center);
        binaryWriter.Write(DistanceToCenter);
        binaryWriter.Write(ViewBox);
        binaryWriter.Write(TexturedObjects.ToSerializable());
        binaryWriter.Write(CollisionBox);
        binaryWriter.Write(CollisionObjects.ToSerializable());
    }
}
