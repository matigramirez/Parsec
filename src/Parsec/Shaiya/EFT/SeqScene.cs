using Parsec.Readers;

namespace Parsec.Shaiya.EFT
{
    public class SeqScene
    {
        public int SceneIndex { get; set; }
        public float Delay { get; set; }

        public SeqScene()
        {
        }

        public SeqScene(ShaiyaBinaryReader binaryReader)
        {
            SceneIndex = binaryReader.Read<int>();
            Delay = binaryReader.Read<float>();
        }
    }
}
