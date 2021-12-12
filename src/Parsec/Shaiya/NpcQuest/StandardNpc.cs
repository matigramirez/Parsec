using Parsec.Readers;

namespace Parsec.Shaiya.NpcQuest
{
    public class StandardNpc : BaseNpc
    {
        public StandardNpc(ShaiyaBinaryReader binaryReader)
        {
            ReadNpcBaseComplete(binaryReader);
        }
    }
}
