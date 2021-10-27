using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.WLD
{
    /// <summary>
    /// A circular area of the world in which music is played
    /// </summary>
    public class MusicSpot
    {
        /// <summary>
        /// Id of the wav file (from the linked name list of files)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The center point of the circle
        /// </summary>
        public Vector3 Center { get; set; }

        /// <summary>
        /// The radius of the circle
        /// </summary>
        public float Radius { get; set; }

        public MusicSpot(ShaiyaBinaryReader binaryReader)
        {
            Id = binaryReader.Read<int>();
            Center = new Vector3(binaryReader);
            Radius = binaryReader.Read<float>();
        }
    }
}
