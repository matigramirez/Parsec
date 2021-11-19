using Parsec.Readers;

namespace Parsec.Shaiya.SETITEM
{
    public class Synergy
    {
        public string Description { get; set; }

        public Synergy()
        {
        }

        public Synergy(ShaiyaBinaryReader binaryReader)
        {
            Description = binaryReader.ReadString();
        }
    }
}
