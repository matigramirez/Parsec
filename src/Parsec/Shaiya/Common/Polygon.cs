using Parsec.Readers;

namespace Parsec.Shaiya.Common
{
    public class Polygon
    {
        public ushort VertexIndex1 { get; set; }
        public ushort VertexIndex2 { get; set; }
        public ushort VertexIndex3 { get; set; }

        public Polygon(ShaiyaBinaryReader binaryReader)
        {
            VertexIndex1 = binaryReader.Read<ushort>();
            VertexIndex2 = binaryReader.Read<ushort>();
            VertexIndex3 = binaryReader.Read<ushort>();
        }
    }
}
