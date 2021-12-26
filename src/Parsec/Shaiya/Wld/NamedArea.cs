using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Wld
{
    /// <summary>
    /// Represents a NamedArea in the world
    /// </summary>
    public class NamedArea
    {
        /// <summary>
        /// The Area where this Named Area applies
        /// </summary>
        public CubicArea Area { get; set; }

        /// <summary>
        /// Almost always
        /// </summary>
        public int Unknown_1 { get; set; }

        /// <summary>
        /// Multipurpose, its value depends on <see cref="Mode"/>
        /// If Mode is 0, it reads the caption from world_index.txt
        /// If Mode is 2, this field defines the bmp file for the area's name
        /// </summary>
        public string Text1 { get; set; }

        /// <summary>
        /// Comment or file name (unlocalized - Korean)
        /// </summary>
        public string Text2 { get; set; }

        /// <summary>
        /// Defines the mode for <see cref="Text1"/>
        /// </summary>
        public NamedAreaMode Mode { get; set; }

        /// <summary>
        /// Almost always 0
        /// </summary>
        public int Unknown_2 { get; set; }
    }

    public enum NamedAreaMode
    {
        WorldIndexTxt = 0,
        BmpFile = 2
    }
}
