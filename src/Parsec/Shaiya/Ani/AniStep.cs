using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.ANI
{
    public class AniStep
    {
        public int BoneIndex { get; set; }
        public Matrix4 Matrix { get; set; }
        public List<Rotation> Rotations { get; } = new();
        public List<Translation> Translations { get; } = new();

        public AniStep(ShaiyaBinaryReader binaryReader)
        {
            BoneIndex = binaryReader.Read<int>();
            Matrix = new Matrix4(binaryReader);

            var rotationCount = binaryReader.Read<int>();

            for (int i = 0; i < rotationCount; i ++)
            {
                var rotation = new Rotation(binaryReader);
                Rotations.Add(rotation);
            }

            var translationCount = binaryReader.Read<int>();

            for (int i = 0; i < translationCount; i++)
            {
                var translation = new Translation(binaryReader);
                Translations.Add(translation);
            }
        }
    }
}
