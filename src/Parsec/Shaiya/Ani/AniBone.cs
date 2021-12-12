using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Ani
{
    /// <summary>
    /// Class that represents the information for each bone present in the ani file
    /// </summary>
    public class AniBone
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
        public List<RotationKeyframe> Rotations { get; set; } = new();

        /// <summary>
        /// List of translations for each keyframe
        /// </summary>
        public List<TranslationKeyframe> Translations { get; set; } = new();

        public AniBone(int index, ShaiyaBinaryReader binaryReader)
        {
            BoneIndex = index;

            ParentBoneIndex = binaryReader.Read<int>();

            TransformationMatrix = new Matrix4(binaryReader);

            var rotationCount = binaryReader.Read<int>();

            // Read rotations
            for (int i = 0; i < rotationCount; i++)
            {
                var keyframeRotation = new RotationKeyframe(binaryReader);
                Rotations.Add(keyframeRotation);
            }

            var translationCount = binaryReader.Read<int>();

            // Read translations
            for (int i = 0; i < translationCount; i++)
            {
                var keyframeTranslation = new TranslationKeyframe(binaryReader);
                Translations.Add(keyframeTranslation);
            }
        }

        [JsonConstructor]
        public AniBone()
        {
        }
    }
}
