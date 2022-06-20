using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.DualLayerClothes
{
    public class DualLayerClothes : SData.SData, IJsonReadable
    {
        public List<Costume> Costumes { get; } = new();

        public override void Read(params object[] options)
        {
            var total = _binaryReader.Read<int>();

            for (int i = 0; i < total; i++)
            {
                var costume = new Costume(_binaryReader);
                Costumes.Add(costume);
            }
        }

        public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Costumes.Count.GetBytes());

            foreach (var costume in Costumes)
                buffer.AddRange(costume.GetBytes());

            return buffer;
        }
    }
}
