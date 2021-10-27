using Parsec.Readers;

namespace Parsec.Shaiya.NPCQUEST
{
    public class StandardNpc : BaseNpc
    {
        public StandardNpc(ShaiyaBinaryReader binaryReader)
        {
            ReadNpcBaseComplete(binaryReader);
        }
    }
}
