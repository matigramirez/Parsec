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
        /// Unknown float value. It's clearly of type float after looking at multiple SMOD files but changing its value doesn't seem to have any effect.
        /// I've tried 0.0, very high values, negative values.. nothing seems to change when setting this value.
        /// </summary>
        [ShaiyaProperty]
        public float Unknown { get; set; }

        /// <summary>
        /// Box that surrounds the textured objects. It's used by the game to easily determine where there are objects present, so that the player view
        /// doesn't get obstructed (when the camera is placed in the position of an object, the view is zoomed to avoid having the object in the viewport).
        /// </summary>
        [ShaiyaProperty]
        public BoundingBox ViewBox { get; set; }

        /// <summary>
        /// List of textured objects
        /// </summary>
        [ShaiyaProperty]
        [LengthPrefixedList(typeof(TexturedObject))]
        public List<TexturedObject> TexturedObjects { get; set; } = new();

        /// <summary>
        /// Box that defines the area where collisions should take place. Collision objects that are outside this box are ignored.
        /// </summary>
        [ShaiyaProperty]
        public BoundingBox CollisionBox { get; set; }

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
