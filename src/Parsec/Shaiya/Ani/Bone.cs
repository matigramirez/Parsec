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
        /// The bone's parent bone index
        /// </summary>
        public int ParentBoneIndex { get; set; }

        /// <summary>
        /// The transformation matrix for the initial position of the bone
        /// </summary>
        public Matrix4x4 Matrix { get; set; }

        /// <summary>
        /// List of rotations for each keyframe
        /// </summary>
        public List<RotationFrame> RotationFrames { get; set; } = new();

        /// <summary>
        /// List of translations for each keyframe
        /// </summary>
        public List<TranslationFrame> TranslationFrames { get; set; } = new();

        [JsonConstructor]
        public Bone()
        {
        }

        public Bone(SBinaryReader binaryReader, int index)
        {
            BoneIndex = index;

            ParentBoneIndex = binaryReader.Read<int>();

            Matrix = new Matrix4x4(binaryReader);

            var rotationCount = binaryReader.Read<int>();

            // Read rotations
            for (int i = 0; i < rotationCount; i++)
            {
                var rotationFrame = new RotationFrame(binaryReader);
                RotationFrames.Add(rotationFrame);
            }

            var translationCount = binaryReader.Read<int>();

            // Read translations
            for (int i = 0; i < translationCount; i++)
            {
                var translationFrame = new TranslationFrame(binaryReader);
                TranslationFrames.Add(translationFrame);
            }
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(ParentBoneIndex.GetBytes());
            buffer.AddRange(Matrix.GetBytes());
            buffer.AddRange(RotationFrames.GetBytes());
            buffer.AddRange(TranslationFrames.GetBytes());
            return buffer.ToArray();
        }
    }
}
