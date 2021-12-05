using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Zon
{
    public class ZonRecord
    {
        public byte Index { get; set; }
        public byte P1 { get; set; }

        /// <summary>
        /// Present only if Format > 2
        /// </summary>
        public byte P2 { get; set; }

        public Vector3 Coordinates1 { get; set; }
        public Vector3 Coordinates2 { get; set; }

        /// <summary>
        /// Present only if Format > 2
        /// </summary>
        public Vector3 Coordinates3 { get; set; }

        /// <summary>
        /// Present only if Format > 2
        /// </summary>
        public Vector3 Coordinates4 { get; set; }

        /// <summary>
        /// Present only if Format > 2
        /// </summary>
        public float Unknown1 { get; set; }

        /// <summary>
        /// Present only if Format > 2
        /// </summary>
        public float Unknown2 { get; set; }

        public short MapId { get; set; }
        public string Description { get; set; }

        public ZonRecord(int format ,ShaiyaBinaryReader binaryReader)
        {
            Index = binaryReader.Read<byte>();
            P1 = binaryReader.Read<byte>();

            if (format > 2)
            {
                P2 = binaryReader.Read<byte>();
            }

            Coordinates1 = new Vector3(binaryReader);
            Coordinates2 = new Vector3(binaryReader);

            if (format > 2)
            {
                Coordinates3 = new Vector3(binaryReader);
                Coordinates4 = new Vector3(binaryReader);
                Unknown1 = binaryReader.Read<float>();
                Unknown2 = binaryReader.Read<float>();
            }

            MapId = binaryReader.Read<short>();
            Description = binaryReader.ReadString(false);
        }

        [JsonConstructor]
        public ZonRecord()
        {
        }

        public byte[] GetBytes(int format)
        {
            var buffer = new List<byte>();

            buffer.Add(Index);
            buffer.Add(P1);

            if (format > 2)
            {
                buffer.Add(P2);
            }

            buffer.AddRange(Coordinates1.GetBytes());
            buffer.AddRange(Coordinates2.GetBytes());

            if (format > 2)
            {
                buffer.AddRange(Coordinates3.GetBytes());
                buffer.AddRange(Coordinates4.GetBytes());
                buffer.AddRange(Unknown1.GetBytes());
                buffer.AddRange(Unknown1.GetBytes());
            }

            buffer.AddRange(MapId.GetBytes());
            buffer.AddRange(Description.GetASCIILengthPrefixedBytes(false));

            return buffer.ToArray();
        }
    }
}
