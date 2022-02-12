using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SMOD
{
    public class SMOD : FileBase, IJsonReadable
    {
        public Vector3 Center { get; set; }

        /// <summary>
        /// Rotation on the Y-Axis in radians
        /// </summary>
        public float Orientation { get; set; }
        public BoundingBox BoundingBox1 { get; set; }
        public List<TexturedObject> TexturedObjects { get; } = new();
        public BoundingBox BoundingBox2 { get; set; }
        public List<SimpleObject> SimpleObjects { get; } = new();

        [JsonIgnore]
        public override string Extension => "SMOD";

        public override void Read(params object[] options)
        {
            Center = new Vector3(_binaryReader);
            Orientation = _binaryReader.Read<float>();
            BoundingBox1 = new BoundingBox(_binaryReader);

            var texturedObjectCount = _binaryReader.Read<int>();

            for (int i = 0; i < texturedObjectCount; i++)
            {
                var texturedObject = new TexturedObject(_binaryReader);
                TexturedObjects.Add(texturedObject);
            }

            BoundingBox2 = new BoundingBox(_binaryReader);

            var objectCount = _binaryReader.Read<int>();

            for (int i = 0; i < objectCount; i++)
            {
                var obj = new SimpleObject(_binaryReader);
                SimpleObjects.Add(obj);
            }
        }

        public override byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Center.GetBytes());
            buffer.AddRange(Orientation.GetBytes());
            buffer.AddRange(BoundingBox1.GetBytes());
            buffer.AddRange(TexturedObjects.GetBytes());
            buffer.AddRange(BoundingBox2.GetBytes());
            buffer.AddRange(SimpleObjects.GetBytes());
            return buffer.ToArray();
        }
    }
}
