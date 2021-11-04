using System;
using System.Collections.Generic;
using Parsec.Helpers;
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
        /// The maximum keyframe value used by translations and rotations
        /// </summary>
        public short MaxKeyframe { get; set; }

        /// <summary>
        /// No info
        /// </summary>
        public short Unknown2 { get; set; }

        public List<BoneStep> BoneSteps { get; } = new();

        public Ani(string path) : base(path)
        {
        }

        public override void Read()
        {
            Unknown1 = _binaryReader.Read<int>();
            MaxKeyframe = _binaryReader.Read<short>();
            Unknown2 = _binaryReader.Read<short>();

            var aniStepCount = _binaryReader.Read<short>();

            for (int i = 0; i < aniStepCount; i++)
            {
                var aniStep = new BoneStep(_binaryReader);
                BoneSteps.Add(aniStep);
            }
        }

        public override void Write(string path)
        {
            // Create byte list which will contain the ani data
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Unknown1));
            buffer.AddRange(BitConverter.GetBytes(MaxKeyframe));
            buffer.AddRange(BitConverter.GetBytes(Unknown2));
            buffer.AddRange(BitConverter.GetBytes((short)BoneSteps.Count));

            foreach (var bone in BoneSteps)
            {
                buffer.AddRange(BitConverter.GetBytes(bone.BoneIndex));
                buffer.AddRange(bone.OriginalMatrix.GetBytes());
                buffer.AddRange(BitConverter.GetBytes(bone.KeyframeRotations.Count));

                foreach (var keyframeRotation in bone.KeyframeRotations)
                {
                    buffer.AddRange(keyframeRotation.GetBytes());
                }

                buffer.AddRange(BitConverter.GetBytes(bone.KeyframeTranslations.Count));

                foreach (var keyframeTranslation in bone.KeyframeTranslations)
                {
                    buffer.AddRange(keyframeTranslation.GetBytes());
                }
            }

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
