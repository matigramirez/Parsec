using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MLT
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

        public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Signature.GetBytes());

            buffer.AddRange(Obj3DCNames.Count.GetBytes());

            foreach (var obj3dcName in Obj3DCNames)
                obj3dcName.GetLengthPrefixedBytes();

            buffer.AddRange(TextureNames.Count.GetBytes());

            foreach (var textureName in TextureNames)
                textureName.GetLengthPrefixedBytes();

            buffer.AddRange(Records.GetBytes());
            return buffer;
        }
    }
}
