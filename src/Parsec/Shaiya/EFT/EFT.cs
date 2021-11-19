using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT
{
    public class EFT : FileBase
    {
        [JsonIgnore]
        public byte[] Header { get; set; }
        public int File3DECount { get; set; }
        public List<string> File3DEList { get; } = new();
        public int FileDDSCount { get; set; }
        public List<string> FileDDSList { get; } = new();
        public int SceneCount { get; set; }
        public List<Scene> Scenes { get; } = new();
        public int SequenceCount { get; set; }
        public List<Sequence> Sequences { get; } = new();

        public EFT(string path) : base(path)
        {
        }

        public override void Read()
        {
            Header = _binaryReader.ReadBytes(3);

            File3DECount = _binaryReader.Read<int>();

            for (int i = 0; i < File3DECount; i++)
            {
                var name = _binaryReader.ReadString();
                File3DEList.Add(name);
            }

            FileDDSCount = _binaryReader.Read<int>();

            for (int i = 0; i < FileDDSCount; i++)
            {
                var name = _binaryReader.ReadString();
                FileDDSList.Add(name);
            }

            SceneCount = _binaryReader.Read<int>();

            for (int i = 0; i < SceneCount; i++)
            {
                var scene = new Scene(_binaryReader);
                Scenes.Add(scene);
            }

            SequenceCount = _binaryReader.Read<int>();

            for (int i = 0; i < SequenceCount; i++)
            {
                var sequence = new Sequence(_binaryReader);
                Sequences.Add(sequence);
            }
        }
    }
}
