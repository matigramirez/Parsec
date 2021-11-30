using System;
using System.Collections.Generic;
using System.Text;

namespace Parsec.Extensions
{
    public static class BinaryExtensions
    {
        public static byte[] GetBytes(this short value) => BitConverter.GetBytes(value);

        public static byte[] GetBytes(this ushort value) => BitConverter.GetBytes(value);

        public static byte[] GetBytes(this int value) => BitConverter.GetBytes(value);

        public static byte[] GetBytes(this uint value) => BitConverter.GetBytes(value);

        public static byte[] GetASCIILengthPrefixedBytes(this string str, bool includeStringTerminator = true)
        {
            var buffer = new List<byte>();

            var finalLength = includeStringTerminator ? str.Length + 1 : str.Length;
            var finalStr = includeStringTerminator ? str + '\0' : str;

            buffer.AddRange(BitConverter.GetBytes(finalLength));
            buffer.AddRange(Encoding.ASCII.GetBytes(finalStr));

            return buffer.ToArray();
        }
    }
}
