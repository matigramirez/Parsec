using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Emblem
{
    public class Texture : IBinary
    {
        public string Name { get; set; } = "";

        [JsonIgnore]
        public byte[] Buffer { get; set; }

        [JsonIgnore]
        private const int LENGTH = 260;

        [JsonConstructor]
        public Texture()
        {
        }

        public Texture(SBinaryReader binaryReader)
        {
            Buffer = binaryReader.ReadBytes(LENGTH);

            for (int i = 0; i < LENGTH; i++)
            {
                if ((char)Buffer[i] == '\0')
                {
                    break;
                }

                Name += (char)Buffer[i];
            }
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Encoding.ASCII.GetBytes(Name + '\0'));

            for (int i = 0; i < LENGTH - Name.Length - 1; i++)
            {
                // pad with 0xCC
                buffer.Add(0xCC);
            }

            return buffer.ToArray();
        }
    }
}
