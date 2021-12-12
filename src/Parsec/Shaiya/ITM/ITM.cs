using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Itm
{
    public class ITM : FileBase, IJsonReadable
    {
        /// <summary>
        /// File Signature. Read as char[3]. "ITM" or "IT2"
        /// </summary>
        public string Signature { get; set; }

        [JsonIgnore]
        public ITMFormat Format { get; set; }

        /// <summary>
        /// List of .3DO object names
        /// </summary>
        public List<string> Obj3DONames { get; } = new();

        /// <summary>
        ///  List of .dds texture names
        /// </summary>
        public List<string> TextureNames { get; } = new();

        /// <summary>
        /// List of ITM records
        /// </summary>
        public List<Record> Records { get; } = new();

        [JsonIgnore]
        public override string Extension => "ITM";

        public override void Read(params object[] options)
        {
            Signature = _binaryReader.ReadString(3);

            Format = Signature switch
            {
                "ITM" => ITMFormat.ITM,
                "IT2" => ITMFormat.IT2,
                _ => ITMFormat.Unknown
            };

            var obj3doCount = _binaryReader.Read<int>();

            for (int i = 0; i < obj3doCount; i++)
            {
                var obj3oName = _binaryReader.ReadString();
                Obj3DONames.Add(obj3oName);
            }

            var textureNameCount = _binaryReader.Read<int>();

            for (int i = 0; i < textureNameCount; i++)
            {
                var textureName = _binaryReader.ReadString();
                TextureNames.Add(textureName);
            }

            var recordCount = _binaryReader.Read<int>();

            for (int i = 0; i < recordCount; i++)
            {
                var record = new Record(Format, _binaryReader);
                Records.Add(record);
            }
        }

        public override void Write(string path, params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Encoding.ASCII.GetBytes(Signature));

            buffer.AddRange(BitConverter.GetBytes(Obj3DONames.Count));

            foreach (var obj3doName in Obj3DONames)
            {
                buffer.AddRange(BitConverter.GetBytes(obj3doName.Length + 1));
                buffer.AddRange(Encoding.ASCII.GetBytes(obj3doName + '\0'));
            }

            buffer.AddRange(BitConverter.GetBytes(TextureNames.Count));

            foreach (var textureName in TextureNames)
            {
                buffer.AddRange(BitConverter.GetBytes(textureName.Length + 1));
                buffer.AddRange(Encoding.ASCII.GetBytes(textureName + '\0'));
            }

            buffer.AddRange(BitConverter.GetBytes(Records.Count));

            foreach (var record in Records)
                buffer.AddRange(record.GetBytes(Format));

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
