using Parsec.Readers;
using Parsec.Common;

namespace Parsec.Shaiya.NpcQuest
{
    public class StandardNpc : BaseNpc
    {
        public StandardNpc(SBinaryReader binaryReader, Format format) : base(format)
        {
            ReadNpcBaseComplete(binaryReader);
        }
    }
}
