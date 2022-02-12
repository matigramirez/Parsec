using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SMOD
{
    public class SimpleVertex : IBinary
    {
        public Vector3 Coordinates { get; set; }

        [JsonConstructor]
        public SimpleVertex()
        {
        }

        public SimpleVertex(SBinaryReader binaryReader)
        {
            Coordinates = new Vector3(binaryReader);
        }

        public byte[] GetBytes(params object[] options) => Coordinates.GetBytes();
    }
}
