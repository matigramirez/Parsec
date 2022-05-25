using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.ALT
{
    /// <summary>
    /// Class that represents the ALT file format
    /// </summary>
    public class ALT : FileBase, IJsonReadable
    {
        public string Signature { get; set; }
        public List<Animation> Animations { get; } = new();

        public override string Extension => ".ALT";

        [JsonConstructor]
        public ALT()
        {
        }

        public override void Read(params object[] options)
        {
            Signature = _binaryReader.ReadString(3);

            var animationCount = _binaryReader.Read<int>();

            for (var i = 0; i < animationCount; i++)
            {
                var animation = new Animation(_binaryReader);
                Animations.Add(animation);
            }
        }

        public override IEnumerable<byte> GetBytes(Episode? episode = null)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Signature.GetBytes());
            buffer.AddRange(Animations.Count.GetBytes());

            foreach (var animation in Animations)
                buffer.AddRange(animation.GetBytes());

            return buffer.ToArray();
        }
    }
}
