using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap
{
    public class Ladder : IBinary
    {
        public Vector3 Position { get; set; }

        [JsonConstructor]
        public Ladder()
        {
        }
        
        public Ladder(SBinaryReader binaryReader)
        {
            Position = new Vector3(binaryReader);
        }

        public byte[] GetBytes(params object[] options) => Position.GetBytes();
    }
}
