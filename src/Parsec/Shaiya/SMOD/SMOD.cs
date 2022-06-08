using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SMOD
{
    /// <summary>
    /// Class that represents a .SMOD object which is used for buildings.
    /// Buildings can be made up of multiple parts, each with its individual texture.
    /// Collision objects are also included in this format in a separate list of texture-less objects.
    /// </summary>
    [DefaultVersion(Episode.EP5)]
    public class SMOD : FileBase, IJsonReadable
    {
        /// <summary>
        /// The center of the SMOD object as a whole (center of all objects)
        /// </summary>
        [ShaiyaProperty]
        public Vector3 Center { get; set; }

        /// <summary>
        /// Rotation on the Y-Axis in radians
        /// </summary>
        [ShaiyaProperty]
        public float Orientation { get; set; }

        /// <summary>
        /// Box that surrounds the textured objects? Seems to be way bigger than a wrapper box
        /// </summary>
        [ShaiyaProperty]
        public BoundingBox BoundingBox1 { get; set; }

        /// <summary>
        /// List of textured objects
        /// </summary>
        [ShaiyaProperty]
        [LengthPrefixedList(typeof(TexturedObject))]
        public List<TexturedObject> TexturedObjects { get; set; } = new();

        /// <summary>
        /// Box that surrounds the texture-less objects? Seems to be way bigger than a wrapper box
        /// </summary>
        [ShaiyaProperty]
        public BoundingBox BoundingBox2 { get; set; }

        /// <summary>
        /// List of texture-less objects used for collisions
        /// </summary>
        [ShaiyaProperty]
        [LengthPrefixedList(typeof(CollisionObject))]
        public List<CollisionObject> CollisionObjects { get; set; } = new();

        [JsonIgnore]
        public override string Extension => "SMOD";
    }
}
