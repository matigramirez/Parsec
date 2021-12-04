using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NPCQUEST
{
    public class QuestItem : IBinary
    {
        public byte Type { get; set; }
        public byte TypeId { get; set; }
        public byte Count { get; set; }

        public QuestItem(ShaiyaBinaryReader binaryReader)
        {
            Type = binaryReader.Read<byte>();
            TypeId = binaryReader.Read<byte>();
            Count = binaryReader.Read<byte>();
        }

        public byte[] GetBytes() => new[]
        {
            Type, TypeId, Count
        };
    }
}
