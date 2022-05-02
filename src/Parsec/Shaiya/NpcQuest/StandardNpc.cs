using Parsec.Readers;
using Parsec.Common;
using Newtonsoft.Json;

namespace Parsec.Shaiya.NpcQuest
{
    public class StandardNpc : BaseNpc
    {
        public StandardNpc(SBinaryReader binaryReader, Format format) : base(format)
        {
            ReadNpcBaseComplete(binaryReader);
        }

        [JsonConstructor]
        public StandardNpc(Format format = Format.EP5) : base(format)
        {
        }
    }
}
