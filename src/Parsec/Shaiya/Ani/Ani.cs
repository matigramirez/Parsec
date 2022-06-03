using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani
{
    /// <summary>
    /// Class that represents an .ANI file
    /// </summary>
    [VersionPrefixed("ANI_V2", Episode.EP6, Episode.EP8)]
    public class Ani : FileBase, IJsonReadable
    {
        /// <summary>
        /// Starting keyframe. 0 for most animations
        /// </summary>
        [ShaiyaProperty]
        public int StartKeyframe { get; set; }

        /// <summary>
        /// The ending animation keyframe
        /// </summary>
        [ShaiyaProperty]
        public int EndKeyframe { get; set; }

        /// <summary>
        /// The list of bones with their translations and rotations for each keyframe
        /// </summary>
        [ShaiyaProperty]
        [LengthPrefixedList(typeof(Bone), typeof(short))]
        public List<Bone> Bones { get; } = new();

        [JsonIgnore]
        public override string Extension => "ANI";

        /// <inheritdoc />
        public override void Read(params object[] options)
        {
            // Check signature
            var signature = _binaryReader.ReadString(6);

            if (signature == "ANI_V2")
                Episode = Episode.EP6;
            else
                _binaryReader.ResetOffset();

            StartKeyframe = _binaryReader.Read<int>();
            EndKeyframe = _binaryReader.Read<int>();

            var boneCount = _binaryReader.Read<short>();

            for (int i = 0; i < boneCount; i++)
            {
                var aniStep = new Bone(_binaryReader, i);
                Bones.Add(aniStep);
            }
        }
    }
}
