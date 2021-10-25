using System;

namespace Parsec.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] SubArray<T>(this T[] array, long offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }
    }
}
