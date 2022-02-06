using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani
{
    /// <summary>
    /// Class that represents an .ANI file
    /// </summary>
    public class Ani : FileBase, IJsonReadable
    {
        /// <summary>
        /// Indicates whether this ANI instance is of type ANI_V2 or not
        /// </summary>
        [JsonIgnore]
        public bool IsAniV2 { get; set; }

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
        public List<Bone> Bones { get; } = new();

        [JsonIgnore]
        public override string Extension => "ANI";

        /// <inheritdoc />
        public override void Read(params object[] options)
        {
            // Check signature
            var signature = _binaryReader.ReadString(6);

            if (signature == "ANI_V2")
                IsAniV2 = true;
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

        public override byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            if (IsAniV2)
                buffer.AddRange("ANI_V2".GetBytes());

            buffer.AddRange(StartKeyframe.GetBytes());
            buffer.AddRange(EndKeyframe.GetBytes());

            buffer.AddRange(((short)Bones.Count).GetBytes());

            foreach (var bone in Bones)
                buffer.AddRange(bone.GetBytes());

            return buffer.ToArray();
        }
    }
}
