using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Wld
{
    /// <summary>
    /// Represents an effect in the world
    /// </summary>
    public class Effect
    {
        /// <summary>
        /// Effect's position
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Effect's rotation
        /// </summary>
        public Vector3 Rotation { get; set; }

        /// <summary>
        /// Effect's scaling
        /// </summary>
        public Vector3 Scaling { get; set; }

        /// <summary>
        /// Identifier of the effect from the linked .eft file
        /// </summary>
        public int Id { get; set; }

        public Effect(SBinaryReader binaryReader)
        {
            Position = new Vector3(binaryReader);
            Rotation = new Vector3(binaryReader);
            Scaling = new Vector3(binaryReader);
            Id = binaryReader.Read<int>();
        }
    }
}
