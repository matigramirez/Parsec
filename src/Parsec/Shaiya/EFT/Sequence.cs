using System.Collections.Generic;
using Parsec.Readers;

namespace Parsec.Shaiya.EFT
{
    public class Sequence
    {
        public string Name { get; set; }
        public int SceneCount { get; set; }
        public List<SeqScene> SceneList { get; } = new();

        public Sequence()
        {
        }

        public Sequence(ShaiyaBinaryReader binaryReader)
        {
            Name = binaryReader.ReadString();
            SceneCount = binaryReader.Read<int>();

            for (int i = 0; i < SceneCount; i++)
            {
                var scene = new SeqScene(binaryReader);
                SceneList.Add(scene);
            }
        }
    }
}
