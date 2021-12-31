using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani
{
    /// <summary>
    /// Class that represents the information for each bone present in the ani file
    /// </summary>
    public class Bone : IBinary
    {
        /// <summary>
        /// The index of the bone which matches the .3DC bone
        /// </summary>
        public int BoneIndex { get; set; }

        /// <summary>
        /// The bone's parent bone index. For bone 0 its value is -1, meaning it doesn't have a parent.
        /// </summary>
        public int ParentBoneIndex { get; set; }

        /// <summary>
        /// The transformation matrix for the initial position of the bone
        /// </summary>
        public Matrix4 TransformationMatrix { get; set; }

        /// <summary>
        /// List of rotations for each keyframe
        /// </summary>
        public List<Rotation> Rotations { get; set; } = new();

        /// <summary>
        /// List of translations for each keyframe
        /// </summary>
        public List<Translation> Translations { get; set; } = new();

        [JsonConstructor]
        public Bone()
        {
        }

        public Bone(int index, SBinaryReader binaryReader)
        {
            BoneIndex = index;

            ParentBoneIndex = binaryReader.Read<int>();

            TransformationMatrix = new Matrix4(binaryReader);

            var rotationCount = binaryReader.Read<int>();

            // Read rotations
            for (int i = 0; i < rotationCount; i++)
            {
                var keyframeRotation = new Rotation(binaryReader);
                Rotations.Add(keyframeRotation);
            }

            var translationCount = binaryReader.Read<int>();

            // Read translations
            for (int i = 0; i < translationCount; i++)
            {
                var keyframeTranslation = new Translation(binaryReader);
                Translations.Add(keyframeTranslation);
            }
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(ParentBoneIndex));
            buffer.AddRange(TransformationMatrix.GetBytes());
            buffer.AddRange(Rotations.GetBytes());
            buffer.AddRange(Translations.GetBytes());

            return buffer.ToArray();
        }
    }
}
