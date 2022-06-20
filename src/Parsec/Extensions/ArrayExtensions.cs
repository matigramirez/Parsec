namespace Parsec.Extensions;

public static class ArrayExtensions
{
    /// <summary>
    /// Array extension method to take a subarray from an array
    /// </summary>
    /// <param name="array">The original array</param>
    /// <param name="offset">Offset from the array where to start the subarray</param>
    /// <param name="length">Length of the subarray</param>
    public static T[] SubArray<T>(this T[] array, long offset, int length)
    {
        if (offset < 0 || offset + length > array.Length)
        {
            throw new ArgumentException("Array index out of array bounds.");
        }

        var result = new T[length];
        Array.Copy(array, offset, result, 0, length);
        return result;
    }
}
