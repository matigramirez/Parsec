using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SMOD;

/// <summary>
/// Class that represents a .SMOD object which is used for buildings.
/// Buildings can be made up of multiple parts, each with its individual texture.
/// Collision objects are also included in this format in a separate list of texture-less objects.
/// </summary>
[DefaultVersion(Episode.EP5)]
public sealed class SMOD : FileBase
{
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
    public List<TexturedObject> TexturedObjects { get; set; } = new();

    /// <summary>
    /// Box that defines the area where collisions should take place. Collision objects that are outside this box are ignored.
    /// </summary>
    public BoundingBox CollisionBox { get; set; }

    /// <summary>
    /// List of texture-less objects used for collisions
    /// </summary>
    public List<CollisionObject> CollisionObjects { get; set; } = new();

    /// <inheritdoc />
    public override void Read(params object[] options)
    {
        Center = new Vector3(_binaryReader);
        DistanceToCenter = _binaryReader.Read<float>();
        ViewBox = new BoundingBox(_binaryReader);

        int texturedObjectCount = _binaryReader.Read<int>();
        for (int i = 0; i < texturedObjectCount; i++)
            TexturedObjects.Add(new TexturedObject(_binaryReader));

        CollisionBox = new BoundingBox(_binaryReader);

        int collisionObjectCount = _binaryReader.Read<int>();
        for (int i = 0; i < collisionObjectCount; i++)
            CollisionObjects.Add(new CollisionObject(_binaryReader));
    }

    /// <inheritdoc />
    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Center.GetBytes());
        buffer.AddRange(DistanceToCenter.GetBytes());
        buffer.AddRange(ViewBox.GetBytes());
        buffer.AddRange(TexturedObjects.GetBytes());
        buffer.AddRange(CollisionBox.GetBytes());
        buffer.AddRange(CollisionObjects.GetBytes());
        return buffer;
    }

    [JsonIgnore]
    public override string Extension => "SMOD";
}
