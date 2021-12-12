using System;
using System.Collections.Generic;
using System.Text;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Mlt
{
    public class MLT : FileBase, IJsonReadable
    {
        /// <summary>
        /// File Signature. Read as char[3]
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// List of .3DC object names
        /// </summary>
        public List<string> Obj3DCNames { get; } = new();

        /// <summary>
        ///  List of .dds texture names
        /// </summary>
        public List<string> TextureNames { get; } = new();

        /// <summary>
        /// List of MLT records
        /// </summary>
        public List<Record> Records { get; } = new();

        public override string Extension => "MLT";

        public override void Read(params object[] options)
        {
            Signature = _binaryReader.ReadString(3);

            var obj3dcCount = _binaryReader.Read<int>();

            for (int i = 0; i < obj3dcCount; i++)
            {
                var obj3dcName = _binaryReader.ReadString();
                Obj3DCNames.Add(obj3dcName);
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
                var record = new Record(_binaryReader);
                Records.Add(record);
            }
        }

        public override void Write(string path, params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Encoding.ASCII.GetBytes(Signature));

            buffer.AddRange(BitConverter.GetBytes(Obj3DCNames.Count));

            foreach (var obj3dcName in Obj3DCNames)
            {
                buffer.AddRange(BitConverter.GetBytes(obj3dcName.Length + 1));
                buffer.AddRange(Encoding.ASCII.GetBytes(obj3dcName + '\0'));
            }

            buffer.AddRange(BitConverter.GetBytes(TextureNames.Count));

            foreach (var textureName in TextureNames)
            {
                buffer.AddRange(BitConverter.GetBytes(textureName.Length + 1));
                buffer.AddRange(Encoding.ASCII.GetBytes(textureName + '\0'));
            }

            buffer.AddRange(BitConverter.GetBytes(Records.Count));

            foreach (var record in Records)
                buffer.AddRange(record.GetBytes());

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
