using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MON
{
    public class MONObject : IBinary
    {
        public string Object3DCName { get; set; }
        public string TextureName { get; set; }

        [JsonConstructor]
        public MONObject()
        {
        }

        public MONObject(SBinaryReader binaryReader)
        {
            Object3DCName = binaryReader.ReadString();
            TextureName = binaryReader.ReadString();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Object3DCName.GetLengthPrefixedBytes(false));
            buffer.AddRange(TextureName.GetLengthPrefixedBytes(false));
            return buffer.ToArray();
        }
    }
}
