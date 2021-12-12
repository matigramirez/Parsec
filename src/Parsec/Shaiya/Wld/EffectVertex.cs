using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Wld
{
    /// <summary>
    /// Class that represents a Vertex used by effects. It is used to know where to render the effect.
    /// </summary>
    public class EffectVertex
    {
        /// <summary>
        /// Position to draw the effect
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Effect's rotation
        /// </summary>
        public Vector3 Rotation { get; set; }

        /// <summary>
        /// Effect's scaling
        /// </summary>
        public Vector3 Scale { get; set; }

        /// <summary>
        /// Identifier of the effect in the linked .EFT file
        /// </summary>
        public int Identifier { get; set; }
    }
}
