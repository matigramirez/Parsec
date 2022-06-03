using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Obj3DO
{
    public class Vertex
    {
        [ShaiyaProperty]
        public Vector3 Coordinates { get; set; }

        [ShaiyaProperty]
        public Vector3 Normal { get; set; }

        [ShaiyaProperty]
        public Vector2 UV { get; set; }

        [JsonConstructor]
        public Vertex()
        {
        }

        public Vertex(SBinaryReader binaryReader)
        {
            Coordinates = new Vector3(binaryReader);
            Normal = new Vector3(binaryReader);
            UV = new Vector2(binaryReader);
        }
    }
}
