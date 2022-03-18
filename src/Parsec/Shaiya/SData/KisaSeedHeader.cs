using System;
using System.Text;
using Parsec.Extensions;

namespace Parsec.Shaiya.SData
{
    public class KisaSeedHeader
    {
        /// <summary>
        /// Encryption signature. Read as char[40]
        /// </summary>
        public string Signature { get; set; }

        public uint Checksum { get; set; }

        public uint RealSize { get; set; }

        /// <summary>
        /// Read as char[16]
        /// </summary>
        public byte[] Padding { get; set; }

        public KisaSeedHeader(string signature, uint checksum, uint realSize, byte[] padding)
        {
            Signature = signature;
            Checksum = checksum;
            RealSize = realSize;
            Padding = padding;
        }

        public KisaSeedHeader(byte[] data)
        {
            Signature = Encoding.ASCII.GetString(data.SubArray(0, 40));

            var currentOffset = 40;
            Checksum = BitConverter.ToUInt32(data, currentOffset);
            currentOffset += 4;

            if (Checksum == 0)
            {
                Checksum = BitConverter.ToUInt32(data, currentOffset);
                currentOffset += 4;
            }

            RealSize = BitConverter.ToUInt32(data, currentOffset);
            currentOffset += 4;

            Padding = data.SubArray(currentOffset, 16);
        }
    }
}
