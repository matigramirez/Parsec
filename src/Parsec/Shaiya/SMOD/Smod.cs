using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Smod
{
    public class Smod : FileBase, IJsonReadable
    {
        public Vector3 Center { get; set; }
        public int Unknown { get; set; }
        public Vector3 MinCoordinates { get; set; }
        public Vector3 MaxCoordinates { get; set; }
        public List<TexturedObject> TexturedObjects { get; } = new();
        public Vector3 UnknownPoint1 { get; set; }
        public Vector3 UnknownPoint2 { get; set; }
        public List<Object> Objects { get; } = new();

        [JsonIgnore]
        public override string Extension => "SMOD";

        public override void Read(params object[] options)
        {
            Center = new Vector3(_binaryReader);
            Unknown = _binaryReader.Read<int>();
            MinCoordinates = new Vector3(_binaryReader);
            MaxCoordinates = new Vector3(_binaryReader);

            var texturedObjectCount = _binaryReader.Read<int>();

            for (int i = 0; i < texturedObjectCount; i++)
            {
                var texturedObject = new TexturedObject(_binaryReader);
                TexturedObjects.Add(texturedObject);
            }

            UnknownPoint1 = new Vector3(_binaryReader);
            UnknownPoint2 = new Vector3(_binaryReader);

            var objectCount = _binaryReader.Read<int>();

            for (int i = 0; i < objectCount; i++)
            {
                var obj = new Object(_binaryReader);
                Objects.Add(obj);
            }
        }

        public override void Write(string path, params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Center.GetBytes());
            buffer.AddRange(BitConverter.GetBytes(Unknown));
            buffer.AddRange(MinCoordinates.GetBytes());
            buffer.AddRange(MaxCoordinates.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(TexturedObjects.Count));

            foreach (var texturedObject in TexturedObjects)
                buffer.AddRange(texturedObject.GetBytes());

            buffer.AddRange(UnknownPoint1.GetBytes());
            buffer.AddRange(UnknownPoint2.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(Objects.Count));

            foreach (var obj in Objects)
                buffer.AddRange(obj.GetBytes());

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
