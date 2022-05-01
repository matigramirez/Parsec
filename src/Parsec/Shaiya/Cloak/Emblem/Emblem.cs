using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Emblem
{
    public class Emblem : FileBase, IJsonReadable
    {
        public int Count { get; set; }

        public List<Texture> Textures { get; } = new();

        [JsonIgnore]
        public override string Extension => "dat";

        [JsonConstructor]
        public Emblem()
        {
        }

        public override void Read(params object[] options)
        {
            Count = _binaryReader.Read<int>();

            for (int i = 0; i < Count; i++)
            {
                var texture = new Texture(_binaryReader);
                Textures.Add(texture);
            }
        }

        public override byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Textures.GetBytes());
            return buffer.ToArray();
        }
    }
}
