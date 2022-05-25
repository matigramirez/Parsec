using Parsec.Readers;
using Parsec.Common;
using Newtonsoft.Json;

namespace Parsec.Shaiya.NpcQuest
{
    public class StandardNpc : BaseNpc
    {
        public StandardNpc(SBinaryReader binaryReader, Episode episode) : base(episode)
        {
            ReadNpcBaseComplete(binaryReader);
        }

        [JsonConstructor]
        public StandardNpc(Episode episode = Episode.EP5) : base(episode)
        {
        }
    }
}
