using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.Core
{
    public class Binary
    {
        public static IEnumerable<byte> GetPropertyBytes(
            object obj,
            PropertyInfo propertyInfo,
            Episode episode = Episode.Unknown
        )
        {
            var attributes = propertyInfo.GetCustomAttributes().ToList();

            // If property isn't marked as a ShaiyaAttribute, it must be skipped
            if (!attributes.Exists(a => a.GetType() == typeof(ShaiyaPropertyAttribute)))
                return Array.Empty<byte>();

            var propertyValue = propertyInfo.GetValue(obj);

            foreach (var attribute in attributes)
            {
                switch (attribute)
                {
                    case ShaiyaPropertyAttribute shaiyaProperty:
                        var ep = Episode.Unknown;

                        // FileBase instances include the Episode property
                        if (obj is FileBase fileBase)
                        {
                            if (episode == Episode.Unknown)
                                ep = fileBase.Episode;
                        }

                        // if format can't be determined, nothing else should be done here
                        if (ep == Episode.Unknown)
                            break;

                        // single episode check
                        if (shaiyaProperty.MaxEpisode == Episode.Unknown && ep != shaiyaProperty.MinEpisode)
                            return Array.Empty<byte>();

                        // multiple episode check
                        if (ep <= shaiyaProperty.MinEpisode && ep >= shaiyaProperty.MaxEpisode)
                            return Array.Empty<byte>();

                        break;

                    case LengthPrefixedListAttribute lengthPrefixedListAttribute:
                        var lengthType = lengthPrefixedListAttribute.LengthType;

                        var items = propertyValue as IEnumerable;
                        var itemCount = items.Cast<object>().Count();

                        var buffer = new List<byte>();

                        if (lengthType == typeof(int))
                        {
                            buffer.AddRange(itemCount.GetBytes());
                        }
                        else if (lengthType == typeof(short))
                        {
                            buffer.AddRange(((short)itemCount).GetBytes());
                        }
                        else if (lengthType == typeof(byte))
                        {
                            buffer.Add((byte)itemCount);
                        }
                        else
                        {
                            // only int, short and byte lengths are expected
                            throw new NotImplementedException();
                        }

                        foreach (var item in items)
                            foreach (var property in lengthPrefixedListAttribute.ItemType.GetProperties())
                                buffer.AddRange(GetPropertyBytes(item, property, episode));

                        return buffer.ToArray();

                    case LengthPrefixedStringAttribute lengthPrefixedStringAttribute:
                        return ((string)propertyValue).GetLengthPrefixedBytes(
                            lengthPrefixedStringAttribute.IncludeStringTerminator);

                    case FixedLengthStringAttribute:
                        return ((string)propertyValue).GetBytes();
                }
            }

            var type = propertyInfo.PropertyType;

            // If property implements IBinary, bytes can be retrieved by calling GetBytes()
            // this is the case for types Vector, Quaternion, Matrix, BoundingBox, etc.
            if (type.GetInterfaces().Contains(typeof(IBinary)))
                return ((IBinary)propertyValue).GetBytes();

            return GetPrimitiveBytes(type, propertyValue);
        }

        public static IEnumerable<byte> GetPrimitiveBytes(Type type, object value)
        {
            if (type == typeof(byte))
                return new[] { (byte)value };

            if (type == typeof(bool))
                return new[] { (byte)value };

            if (type == typeof(int))
                return ((int)value).GetBytes();

            if (type == typeof(uint))
                return ((uint)value).GetBytes();

            if (type == typeof(short))
                return ((short)value).GetBytes();

            if (type == typeof(ushort))
                return ((ushort)value).GetBytes();

            if (type == typeof(long))
                return ((long)value).GetBytes();

            if (type == typeof(ulong))
                return ((ulong)value).GetBytes();

            if (type == typeof(float))
                return ((float)value).GetBytes();

            throw new ArgumentException();
        }
    }
}
