using Parsec.Readers;

namespace Parsec.Shaiya.EFT
{
    public class Sequence
    {
        public string Name { get; set; }
        public int SceneCount { get; set; }
        public int SceneIndex { get; set; }
        public int Delay { get; set; }

        public Sequence()
        {
        }

        public Sequence(ShaiyaBinaryReader binaryReader)
        {
            Name = binaryReader.ReadString();
            SceneCount = binaryReader.Read<int>();

            for (int i = 0; i < SceneCount; i++)
            {
                SceneIndex = binaryReader.Read<int>();
                Delay = binaryReader.Read<int>();
            }
        }
    }
}
