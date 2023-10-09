using Parsec.Shaiya.Core;

namespace Parsec.Extensions;

public static class ListExtensions
{
    public static List<ISerializable> ToSerializable<T>(this IEnumerable<T> list) where T : ISerializable
    {
        return list.Cast<ISerializable>().ToList();
    }
}
