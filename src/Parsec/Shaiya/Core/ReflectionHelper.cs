using System.Reflection;
using System.Text;
using Parsec.Attributes;
using Parsec.Attributes.Wld;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Core;

internal static class ReflectionHelper
{
    public static object ReadProperty(
        SBinaryReader binaryReader,
        Type parentType,
        object parentInstance,
        PropertyInfo propertyInfo,
        Episode episode = Episode.Unknown
    )
    {
        var type = propertyInfo.PropertyType;

        var attributes = propertyInfo.GetCustomAttributes().ToList();

        // If property isn't marked as a ShaiyaProperty, it must be skipped
        if (!attributes.Exists(a => a.GetType() == typeof(ShaiyaPropertyAttribute)))
            return null;

        foreach (var attribute in attributes)
        {
            switch (attribute)
            {
                case ShaiyaPropertyAttribute shaiyaPropertyAttribute:
                    // If episode limits weren't specified, then property must be read
                    if (shaiyaPropertyAttribute.MinEpisode == Episode.Unknown && shaiyaPropertyAttribute.MaxEpisode == Episode.Unknown)
                        break;

                    if (shaiyaPropertyAttribute.MaxEpisode == Episode.Unknown && episode != shaiyaPropertyAttribute.MinEpisode)
                        return null;

                    if (episode < shaiyaPropertyAttribute.MinEpisode || episode > shaiyaPropertyAttribute.MaxEpisode)
                        return null;

                    break;

                case ConditionalPropertyAttribute conditionalPropertyAttribute:
                    var conditioningPropertyType = parentType.GetProperty(conditionalPropertyAttribute.ConditioningPropertyName);
                    object conditioningPropertyValue = conditioningPropertyType?.GetValue(parentInstance);

                    if (!conditionalPropertyAttribute.ConditioningPropertyValue.Equals(conditioningPropertyValue))
                        return GetDefault(type);
                    break;

                case FixedLengthListAttribute fixedLengthListAttribute:
                    // Create generic list
                    var fixedLengthListType = typeof(List<>);
                    var constructedFixedListType = fixedLengthListType.MakeGenericType(fixedLengthListAttribute.ItemType);
                    var itemList = (IList)Activator.CreateInstance(constructedFixedListType);

                    var typeProperties = fixedLengthListAttribute.ItemType.GetProperties();
                    var genericArgumentType = type.GetGenericArguments().First();

                    for (int i = 0; i < fixedLengthListAttribute.Length; i++)
                    {
                        object item = Activator.CreateInstance(fixedLengthListAttribute.ItemType);

                        if (genericArgumentType.IsPrimitive)
                        {
                            item = ReadPrimitive(binaryReader, genericArgumentType);
                        }
                        else
                        {
                            foreach (var property in typeProperties)
                            {
                                // skip non ShaiyaProperty properties
                                if (!property.IsDefined(typeof(ShaiyaPropertyAttribute)))
                                    continue;

                                object propertyValue = ReadProperty(binaryReader, genericArgumentType, item, property, episode);
                                property.SetValue(item, propertyValue);
                            }
                        }

                        itemList.Add(item);
                    }

                    return itemList;

                case LengthPrefixedListAttribute lengthPrefixedListAttribute:
                    int length = 0;

                    var lengthType = lengthPrefixedListAttribute.LengthType;

                    if (lengthType == typeof(int))
                    {
                        length = binaryReader.Read<int>();
                    }
                    else if (lengthType == typeof(uint))
                    {
                        length = (int)binaryReader.Read<uint>();
                    }
                    else if (lengthType == typeof(short))
                    {
                        length = binaryReader.Read<short>();
                    }
                    else if (lengthType == typeof(ushort))
                    {
                        length = binaryReader.Read<ushort>();
                    }
                    else if (lengthType == typeof(byte))
                    {
                        length = binaryReader.Read<byte>();
                    }
                    else if (lengthType == typeof(sbyte))
                    {
                        length = binaryReader.Read<sbyte>();
                    }
                    else
                    {
                        throw new NotSupportedException();
                    }

                    // Create generic list
                    var listType = typeof(List<>);
                    var constructedListType = listType.MakeGenericType(lengthPrefixedListAttribute.ItemType);
                    var list = (IList)Activator.CreateInstance(constructedListType);

                    var genericItemType = lengthPrefixedListAttribute.ItemType;
                    var properties = genericItemType.GetProperties();

                    for (int i = 0; i < length; i++)
                    {
                        object item = Activator.CreateInstance(lengthPrefixedListAttribute.ItemType);

                        if (genericItemType.IsPrimitive)
                        {
                            item = ReadPrimitive(binaryReader, genericItemType);
                        }
                        else
                        {
                            foreach (var property in properties)
                            {
                                // skip non ShaiyaProperty properties
                                if (!property.IsDefined(typeof(ShaiyaPropertyAttribute)))
                                    continue;

                                object propertyValue = ReadProperty(binaryReader, genericItemType, item, property, episode);
                                property.SetValue(item, propertyValue);
                            }
                        }

                        list.Add(item);
                    }

                    return list;

                case LengthPrefixedStringAttribute lengthPrefixedStringAttribute:
                    string lengthPrefixedStr = binaryReader.ReadString(lengthPrefixedStringAttribute.Encoding,
                        !lengthPrefixedStringAttribute.IncludeStringTerminator);

                    return lengthPrefixedStr;

                case FixedLengthStringAttribute fixedLengthStringAttribute:
                    if (fixedLengthStringAttribute.IsString256)
                        return new String256(binaryReader).Value;

                    string fixedLengthStr = binaryReader.ReadString(fixedLengthStringAttribute.Encoding, fixedLengthStringAttribute.Length,
                        !fixedLengthStringAttribute.IncludeStringTerminator);

                    return fixedLengthStr;

                case HeightmapAttribute heightMapAttribute:
                    var mapSizeProperty = parentType.GetProperty(heightMapAttribute.PropertyName);
                    int mapSize = (int)mapSizeProperty.GetValue(parentInstance);
                    int heightMapSize = heightMapAttribute.CalculateLengthFromMapSize(mapSize);
                    return binaryReader.ReadBytes(heightMapSize);

                case TextureMapAttribute textureMapAttribute:
                    var mapSizePropertyInfo = parentType.GetProperty(textureMapAttribute.PropertyName);
                    int currentMapSize = (int)mapSizePropertyInfo.GetValue(parentInstance);
                    int textureMapSize = textureMapAttribute.CalculateLengthFromMapSize(currentMapSize);
                    return binaryReader.ReadBytes(textureMapSize);
            }
        }

        // If property implements IBinary, the IBinary must be instantiated through its single parameter constructor with takes the SBinaryReader instance
        // this is the case for types Vector, Quaternion, Matrix, BoundingBox, etc.
        if (type.GetInterfaces().Contains(typeof(IBinary)))
        {
            var binary = (IBinary)Activator.CreateInstance(type, binaryReader);
            return binary;
        }

        if (type.IsEnum)
        {
            var underlyingEnumType = Enum.GetUnderlyingType(type);
            return ReadPrimitive(binaryReader, underlyingEnumType);
        }

        return ReadPrimitive(binaryReader, type);
    }

    public static object ReadPrimitive(SBinaryReader binaryReader, Type type) => binaryReader.Read(type);

    public static IEnumerable<byte> GetPropertyBytes(Type parentType, object obj, PropertyInfo propertyInfo, Encoding encoding,
        Episode episode = Episode.Unknown)
    {
        var type = propertyInfo.PropertyType;
        var attributes = propertyInfo.GetCustomAttributes().ToList();

        // If property isn't marked as a ShaiyaAttribute, it must be skipped
        if (!attributes.Exists(a => a.GetType() == typeof(ShaiyaPropertyAttribute)))
            return Array.Empty<byte>();

        object propertyValue = propertyInfo.GetValue(obj);

        foreach (var attribute in attributes)
        {
            switch (attribute)
            {
                case ShaiyaPropertyAttribute shaiyaProperty:
                    var ep = episode;

                    // FileBase instances include the Episode property
                    if (obj is FileBase fileBase)
                    {
                        if (episode == Episode.Unknown)
                            ep = fileBase.Episode;
                    }

                    // if format can't be determined, nothing else should be done here
                    if (ep == Episode.Unknown)
                        break;

                    // if the ShaiyaProperty didn't specify an episode, then it's present in all of them
                    if (shaiyaProperty.MinEpisode == Episode.Unknown && shaiyaProperty.MaxEpisode == Episode.Unknown)
                        break;

                    // single episode check
                    if (shaiyaProperty.MaxEpisode == Episode.Unknown && ep != shaiyaProperty.MinEpisode)
                        return Array.Empty<byte>();

                    // multiple episode check
                    if (ep < shaiyaProperty.MinEpisode || ep > shaiyaProperty.MaxEpisode)
                        return Array.Empty<byte>();

                    break;

                case ConditionalPropertyAttribute conditionalPropertyAttribute:
                    var conditioningPropertyType = parentType.GetProperty(conditionalPropertyAttribute.ConditioningPropertyName);
                    object conditioningPropertyValue = conditioningPropertyType?.GetValue(obj);

                    if (conditionalPropertyAttribute.ConditioningPropertyValue != conditioningPropertyValue)
                        return Array.Empty<byte>();

                    break;

                case FixedLengthListAttribute fixedLengthListAttribute:
                    var listItems = (propertyValue as IEnumerable).Cast<object>().Take(fixedLengthListAttribute.Length);

                    var buf = new List<byte>();

                    var genericArgumentType = type.GetGenericArguments().First();

                    foreach (object item in listItems)
                    {
                        if (genericArgumentType.IsPrimitive)
                        {
                            buf.AddRange(GetPrimitiveBytes(genericArgumentType, item));
                        }
                        else
                        {
                            foreach (var property in fixedLengthListAttribute.ItemType.GetProperties())
                            {
                                if (!property.IsDefined(typeof(ShaiyaPropertyAttribute)) && !fixedLengthListAttribute.ItemType.IsPrimitive)
                                    continue;

                                buf.AddRange(GetPropertyBytes(genericArgumentType, item, property, encoding, episode));
                            }
                        }
                    }

                    return buf.ToArray();

                case LengthPrefixedListAttribute lengthPrefixedListAttribute:
                    var lengthType = lengthPrefixedListAttribute.LengthType;

                    var items = propertyValue as IEnumerable;
                    int itemCount = items.Cast<object>().Count();

                    var genericItemType = type.GetGenericArguments().First();

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
                        throw new NotSupportedException();
                    }

                    foreach (object item in items)
                    {
                        if (genericItemType.IsPrimitive)
                        {
                            buffer.AddRange(GetPrimitiveBytes(genericItemType, item));
                        }
                        else
                        {
                            foreach (var property in lengthPrefixedListAttribute.ItemType.GetProperties())
                            {
                                if (!property.IsDefined(typeof(ShaiyaPropertyAttribute)) &&
                                    !lengthPrefixedListAttribute.ItemType.IsPrimitive)
                                    continue;

                                buffer.AddRange(GetPropertyBytes(genericItemType, item, property, encoding, episode));
                            }
                        }
                    }

                    return buffer;

                case LengthPrefixedStringAttribute lengthPrefixedStringAttribute:
                    return ((string)propertyValue + lengthPrefixedStringAttribute.Suffix).GetLengthPrefixedBytes(encoding,
                        lengthPrefixedStringAttribute.IncludeStringTerminator);

                case FixedLengthStringAttribute fixedLengthStringAttribute:
                    if (fixedLengthStringAttribute.IsString256)
                        return ((string)propertyValue).PadRight(256, '\0').GetBytes(fixedLengthStringAttribute.Encoding);
                    return ((string)propertyValue + fixedLengthStringAttribute.Suffix).GetBytes(fixedLengthStringAttribute.Encoding);
            }
        }

        // If property implements IBinary, bytes can be retrieved by calling GetBytes()
        // this is the case for types Vector, Quaternion, Matrix, BoundingBox, etc.
        if (type.GetInterfaces().Contains(typeof(IBinary)))
            return ((IBinary)propertyValue).GetBytes();

        if (type.IsEnum)
        {
            var underlyingEnumType = Enum.GetUnderlyingType(type);
            return GetPrimitiveBytes(underlyingEnumType, propertyValue);
        }

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

    private static object GetDefault(Type type)
    {
        if (type.IsValueType)
        {
            return Activator.CreateInstance(type);
        }

        return null;
    }
}
