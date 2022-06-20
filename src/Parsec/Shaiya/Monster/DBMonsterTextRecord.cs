using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Monster
{
    public class DBMonsterTextRecord : IBinarySDataRecord
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public void Read(SBinaryReader binaryReader, params object[] options)
        {
            Id = binaryReader.Read<long>();
            Name = binaryReader.ReadString();
        }

        public IEnumerable<byte> GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Id.GetBytes());
            buffer.AddRange(Name.GetBytes());
            return buffer;
        }
    }
}
