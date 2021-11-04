using Parsec.Common;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.OBJ3DC
{
    public class Vertex3DC
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Z coordinate
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// W coordinate
        /// </summary>
        public float W { get; set; }

        /// <summary>
        /// E coordinate. Present in EP6+ format
        /// </summary>
        public float E { get; set; }

        /// <summary>
        /// F Coordinate. Present in EP6+ format
        /// </summary>
        public float F { get; set; }

        public byte Bone1 { get; set; }
        public byte Bone2 { get; set; }

        /// <summary>
        /// Always 0
        /// </summary>
        public short Alignment { get; set; }

        /// <summary>
        /// Normal of this point, used for lighting computation.
        /// </summary>
        public Vector3 Normal { get; set; }

        /// <summary>
        /// Mapping of this point on the 2D texture
        /// </summary>
        public float U { get; set; }

        /// <summary>
        /// Mapping of this point on the 2D texture
        /// </summary>
        public float V { get; set; }

        public Vertex3DC(Format format, ShaiyaBinaryReader binaryReader)
        {
            X = binaryReader.Read<float>();
            Y = binaryReader.Read<float>();
            Z = binaryReader.Read<float>();
            W = binaryReader.Read<float>();

            if (format >= Format.EP6)
            {
                E = binaryReader.Read<float>();
                F = binaryReader.Read<float>();
            }

            Bone1 = binaryReader.Read<byte>();
            Bone2 = binaryReader.Read<byte>();

            Alignment = binaryReader.Read<short>();

            Normal = new Vector3(binaryReader);
            U = binaryReader.Read<float>();
            V = binaryReader.Read<float>();
        }
    }
}
