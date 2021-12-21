using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani
{
    /// <summary>
    /// Class that represents an .ANI file
    /// </summary>
    public class Ani : FileBase, IJsonReadable
    {
        /// <summary>
        /// Starting keyframe. 0 for most animations
        /// </summary>
        public int StartKeyframe { get; set; }

        /// <summary>
        /// The ending animation keyframe
        /// </summary>
        public int EndKeyframe { get; set; }

        /// <summary>
        /// The list of bones with their translations and rotations for each keyframe
        /// </summary>
        public List<AniBone> Bones { get; } = new();

        [JsonIgnore]
        public override string Extension => "ANI";

        /// <inheritdoc />
        public override void Read(params object[] options)
        {
            StartKeyframe = _binaryReader.Read<int>();
            EndKeyframe = _binaryReader.Read<int>();

            var boneCount = _binaryReader.Read<short>();

            for (int i = 0; i < boneCount; i++)
            {
                var aniStep = new AniBone(i, _binaryReader);
                Bones.Add(aniStep);
            }
        }

        public override byte[] GetBytes(params object[] options)
        {
            // Create byte list which will contain the ani data
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(StartKeyframe));
            buffer.AddRange(BitConverter.GetBytes(EndKeyframe));
            buffer.AddRange(BitConverter.GetBytes((short)Bones.Count));

            foreach (var bone in Bones)
            {
                buffer.AddRange(BitConverter.GetBytes(bone.ParentBoneIndex));
                buffer.AddRange(bone.TransformationMatrix.GetBytes());
                buffer.AddRange(BitConverter.GetBytes(bone.Rotations.Count));

                foreach (var keyframeRotation in bone.Rotations)
                    buffer.AddRange(keyframeRotation.GetBytes());

                buffer.AddRange(BitConverter.GetBytes(bone.Translations.Count));

                foreach (var keyframeTranslation in bone.Translations)
                    buffer.AddRange(keyframeTranslation.GetBytes());
            }

            return buffer.ToArray();
        }
    }
}
