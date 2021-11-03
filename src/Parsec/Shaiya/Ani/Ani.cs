using System.Collections.Generic;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.ANI
{
    public class Ani : FileBase
    {
        /// <summary>
        /// Almost always 0
        /// </summary>
        public int Unknown1 { get; set; }

        /// <summary>
        /// Max value for Rotation::index and Translation::index
        /// </summary>
        public short MaxValue { get; set; }

        /// <summary>
        /// No info
        /// </summary>
        public int Unknown2 { get; set; }

        public List<AniStep> AniSteps { get; } = new();

        public Ani(string path) : base(path)
        {
        }

        public override void Read()
        {
            Unknown1 = _binaryReader.Read<int>();
            MaxValue = _binaryReader.Read<short>();
            Unknown2 = _binaryReader.Read<short>();

            var aniStepCount = _binaryReader.Read<short>();

            for (int i = 0; i < aniStepCount; i++)
            {
                var aniStep = new AniStep(_binaryReader);
                AniSteps.Add(aniStep);
            }
        }
    }
}
