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
        public int UpperNumber { get; set; } = 1;
        public string LowerTextureName { get; set; }
        public string Lower3DCName { get; set; }
        public int LowerNumber { get; set; } = 1;
        public string BootsTextureName { get; set; }
        public string Boots3DCName { get; set; }
        public int BootsNumber { get; set; } = 1;
        public string HandsTextureName { get; set; }
        public string Hands3DCName { get; set; }
        public int HandsNumber { get; set; } = 1;

        [JsonConstructor]
        public MLXRecord()
        {
        }

        public MLXRecord(SBinaryReader binaryReader, MLXFormat format)
        {
            Id = binaryReader.Read<int>();
            Name = binaryReader.ReadString();

            UpperTextureName = binaryReader.ReadString();
            Upper3DCName = binaryReader.ReadString();
            
            if(format == MLXFormat.MLX2)
                UpperNumber = binaryReader.Read<int>();
            
            LowerTextureName = binaryReader.ReadString();
            Lower3DCName = binaryReader.ReadString();
            
            if(format == MLXFormat.MLX2)
                LowerNumber = binaryReader.Read<int>();
            
            BootsTextureName = binaryReader.ReadString();
            Boots3DCName = binaryReader.ReadString();
            
            if(format == MLXFormat.MLX2)
                BootsNumber = binaryReader.Read<int>();
            
            HandsTextureName = binaryReader.ReadString();
            Hands3DCName = binaryReader.ReadString();
            
            if(format == MLXFormat.MLX2)
                HandsNumber = binaryReader.Read<int>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var version = MLXFormat.MLX1;
            
            if(options.Length > 0)
                version = (MLXFormat)options[0];
            
            
            var buffer = new List<byte>();
            buffer.AddRange(Id.GetBytes());
            buffer.AddRange(Name.GetLengthPrefixedBytes());
            buffer.AddRange(UpperTextureName.GetLengthPrefixedBytes());
            buffer.AddRange(Upper3DCName.GetLengthPrefixedBytes());
            
            if(version == MLXFormat.MLX2)
                buffer.AddRange(UpperNumber.GetBytes());
            
            buffer.AddRange(LowerTextureName.GetLengthPrefixedBytes());
            buffer.AddRange(Lower3DCName.GetLengthPrefixedBytes());
            
            if(version == MLXFormat.MLX2)
                buffer.AddRange(LowerNumber.GetBytes());
            
            buffer.AddRange(BootsTextureName.GetLengthPrefixedBytes());
            buffer.AddRange(Boots3DCName.GetLengthPrefixedBytes());
            
            if(version == MLXFormat.MLX2)
                buffer.AddRange(BootsNumber.GetBytes());
            
            buffer.AddRange(HandsTextureName.GetLengthPrefixedBytes());
            buffer.AddRange(Hands3DCName.GetLengthPrefixedBytes());
            
            if(version == MLXFormat.MLX2)
                buffer.AddRange(HandsNumber.GetBytes());
            
            return buffer.ToArray();
        }
    }
}
