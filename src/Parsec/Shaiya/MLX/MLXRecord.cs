using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MLX
{
    public class MLXRecord : IBinary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UpperTextureName { get; set; }
        public string Upper3DCName { get; set; }
        public string LowerTextureName { get; set; }
        public string Lower3DCName { get; set; }
        public string BootsTextureName { get; set; }
        public string Boots3DCName { get; set; }
        public string HandsTextureName { get; set; }
        public string Hands3DCName { get; set; }

        [JsonConstructor]
        public MLXRecord()
        {
        }

        public MLXRecord(SBinaryReader binaryReader)
        {
            Id = binaryReader.Read<int>();
            Name = binaryReader.ReadString();
            UpperTextureName = binaryReader.ReadString();
            Upper3DCName = binaryReader.ReadString();
            LowerTextureName = binaryReader.ReadString();
            Lower3DCName = binaryReader.ReadString();
            BootsTextureName = binaryReader.ReadString();
            Boots3DCName = binaryReader.ReadString();
            HandsTextureName = binaryReader.ReadString();
            Hands3DCName = binaryReader.ReadString();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Id.GetBytes());
            buffer.AddRange(Name.GetLengthPrefixedBytes());
            buffer.AddRange(UpperTextureName.GetLengthPrefixedBytes());
            buffer.AddRange(Upper3DCName.GetLengthPrefixedBytes());
            buffer.AddRange(LowerTextureName.GetLengthPrefixedBytes());
            buffer.AddRange(Lower3DCName.GetLengthPrefixedBytes());
            buffer.AddRange(BootsTextureName.GetLengthPrefixedBytes());
            buffer.AddRange(Boots3DCName.GetLengthPrefixedBytes());
            buffer.AddRange(HandsTextureName.GetLengthPrefixedBytes());
            buffer.AddRange(Hands3DCName.GetLengthPrefixedBytes());
            return buffer.ToArray();
        }
    }
}
