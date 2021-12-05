using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parsec.Shaiya.Core;

namespace Parsec.Extensions
{
    public static class BinaryExtensions
    {
        public static byte[] GetBytes(this short value) => BitConverter.GetBytes(value);

        public static byte[] GetBytes(this ushort value) => BitConverter.GetBytes(value);

        public static byte[] GetBytes(this int value) => BitConverter.GetBytes(value);

        public static byte[] GetBytes(this uint value) => BitConverter.GetBytes(value);

        public static byte[] GetBytes(this float value) => BitConverter.GetBytes(value);

        public static byte[] GetASCIILengthPrefixedBytes(this string str, bool includeStringTerminator = true)
        {
            var buffer = new List<byte>();

            var finalStr = includeStringTerminator ? str + '\0' : str;

            buffer.AddRange(BitConverter.GetBytes(finalStr.Length));
            buffer.AddRange(Encoding.ASCII.GetBytes(finalStr));

            return buffer.ToArray();
        }

        public static byte[] GetBytes(this IEnumerable<IBinary> list, bool lengthPrefixed = true)
        {
            var buffer = new List<byte>();

            var enumerable = list as IBinary[] ?? list.ToArray();

            // Add length bytes
            if(lengthPrefixed)
                buffer.AddRange(enumerable.Length.GetBytes());

            // Add item bytes
            foreach (var item in enumerable)
                buffer.AddRange(item.GetBytes());

            return buffer.ToArray();
        }
    }
}
