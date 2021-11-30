using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT
{
    public class EFT : FileBase, IJsonReadable
    {
        public string Signature { get; set; }

        [JsonIgnore]
        public EFTFormat Format { get; set; }
        public int File3DECount { get; set; }
        public List<string> File3DENames { get; } = new();
        public int FileDDSCount { get; set; }
        public List<string> FileDDSNames { get; } = new();
        public int SceneCount { get; set; }
        public List<Scene> Scenes { get; } = new();
        public int SequenceCount { get; set; }
        public List<Sequence> Sequences { get; } = new();

        [JsonConstructor]
        public EFT()
        {
        }

        public EFT(string path) : base(path)
        {
        }

        [JsonIgnore]
        public override string Extension => "EFT";

        public override void Read()
        {
            Signature = _binaryReader.ReadString(3);

            Format = Signature switch
            {
                "EFT" => EFTFormat.EFT,
                "EF3" => EFTFormat.EF3,
                _ => EFTFormat.Unknown
            };

            File3DECount = _binaryReader.Read<int>();

            for (int i = 0; i < File3DECount; i++)
            {
                var name = _binaryReader.ReadString();
                File3DENames.Add(name);
            }

            FileDDSCount = _binaryReader.Read<int>();

            for (int i = 0; i < FileDDSCount; i++)
            {
                var name = _binaryReader.ReadString();
                FileDDSNames.Add(name);
            }

            SceneCount = _binaryReader.Read<int>();

            for (int i = 0; i < SceneCount; i++)
            {
                var scene = new Scene(Format, _binaryReader);
                Scenes.Add(scene);
            }

            SequenceCount = _binaryReader.Read<int>();

            for (int i = 0; i < SequenceCount; i++)
            {
                var sequence = new Sequence(_binaryReader);
                Sequences.Add(sequence);
            }
        }

        public override void Write(string path)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Encoding.ASCII.GetBytes(Signature));

            Format = Signature switch
            {
                "EFT" => EFTFormat.EFT,
                "EF3" => EFTFormat.EF3,
                _ => EFTFormat.Unknown
            };

            buffer.AddRange(BitConverter.GetBytes(File3DENames.Count));

            foreach (var file3DEName in File3DENames)
            {
                buffer.AddRange(BitConverter.GetBytes(file3DEName.Length + 1));
                buffer.AddRange(Encoding.ASCII.GetBytes(file3DEName + '\0'));
            }

            buffer.AddRange(BitConverter.GetBytes(FileDDSNames.Count));

            foreach (var fileDDSName in FileDDSNames)
            {
                buffer.AddRange(BitConverter.GetBytes(fileDDSName.Length + 1));
                buffer.AddRange(Encoding.ASCII.GetBytes(fileDDSName + '\0'));
            }

            buffer.AddRange(BitConverter.GetBytes(Scenes.Count));

            foreach (var scene in Scenes)
            {
                buffer.AddRange(scene.GetBytes(Format));
            }

            buffer.AddRange(BitConverter.GetBytes(Sequences.Count));

            foreach (var sequence in Sequences)
            {
                buffer.AddRange(sequence.GetBytes());
            }

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
