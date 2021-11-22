using Parsec.Readers;

namespace Parsec.Shaiya.SVMAP
{
    public class Monster
    {
        public int MobId { get; set; }
        public int Count { get; set; }

        public Monster(ShaiyaBinaryReader binaryReader)
        {
            MobId = binaryReader.Read<int>();
            Count = binaryReader.Read<int>();
        }
    }
}
