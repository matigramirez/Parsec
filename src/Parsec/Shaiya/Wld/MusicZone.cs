using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Wld
{
    /// <summary>
    /// A rectangular area of the world in which music is played
    /// </summary>
    public class MusicZone
    {
        /// <summary>
        /// The rectangular area of the music zone
        /// </summary>
        public CubicArea Area { get; set; }

        /// <summary>
        /// Usually 0.0f
        /// </summary>
        public float Unknown_1 { get; set; }

        /// <summary>
        /// Id of the wav file (from the linked name list of files)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Usually 0L
        /// </summary>
        public int Unknown_2 { get; set; }

        public MusicZone(ShaiyaBinaryReader binaryReader)
        {
            Area = new CubicArea(binaryReader);
            Unknown_1 = binaryReader.Read<float>();
            Id = binaryReader.Read<int>();
            Unknown_2 = binaryReader.Read<int>();
        }
    }
}
