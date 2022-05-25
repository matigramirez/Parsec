using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.Core
{
    public class Binary : IBinary
    {
        public byte[] GetBytes(params object[] options)
        {
            throw new NotImplementedException();
        }
        
        public static IEnumerable<byte> GetPropertyBytes(object obj, PropertyInfo propertyInfo, Episode episode = Episode.Unknown)
        {
            var attributes = propertyInfo.GetCustomAttributes().ToList();

            // If property isn't marked as a ShaiyaAttribute, it must be skipped
            if (!attributes.Exists(a => a.GetType() == typeof(ShaiyaPropertyAttribute)))
                return Array.Empty<byte>();

            foreach (var attribute in attributes)
            {
                switch (attribute)
                {
                    case ShaiyaPropertyAttribute shaiyaProperty:
                        var ep = Episode.Unknown;

                        // FileBase instances include the Episode property
                        if (obj is FileBase fileBase)
                        {
                            if(episode == Episode.Unknown)
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

                    case LengthPrefixedListAttribute<IBinary>:
                        return ((List<IBinary>)propertyInfo.GetValue(obj)).GetBytes(options: new object[] { episode });

                    case LengthPrefixedStringAttribute:
                        return ((string)propertyInfo.GetValue(obj)).GetLengthPrefixedBytes();

                    case FixedLengthStringAttribute:
                        return ((string)propertyInfo.GetValue(obj)).GetBytes();
                }
            }

            var type = propertyInfo.PropertyType;
            return GetPrimitiveBytes(type, obj);
        }

        public static IEnumerable<byte> GetPrimitiveBytes(Type type, object obj)
        {
            if (type == typeof(byte))
                return new[] { (byte)obj };

            if (type == typeof(bool))
                return new[] { (byte)obj };

            if (type == typeof(int))
                return ((int)obj).GetBytes();

            if (type == typeof(uint))
                return ((uint)obj).GetBytes();

            if (type == typeof(short))
                return ((short)obj).GetBytes();

            if (type == typeof(ushort))
                return ((short)obj).GetBytes();

            if (type == typeof(long))
                return ((long)obj).GetBytes();

            if (type == typeof(ulong))
                return ((ulong)obj).GetBytes();

            if (type == typeof(float))
                return ((float)obj).GetBytes();
            
            return new byte[] {};
        }
    }
}
