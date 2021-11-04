using System;
using System.Collections.Generic;
using Parsec.Shaiya.ANI;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "demf_001_walk.ANI";

            var ani = new Ani(filePath);
            ani.Read();
            ani.Export($"{ani.FileNameWithoutExtension}.json", new List<string>{ "isIdentity" });

            Console.WriteLine($"shStudio ani fields for file {filePath}:");
            Console.WriteLine("Unknown1  MaxBoneIndex  Unknown2  BoneStepsCount");
            Console.WriteLine($"{ani.Unknown1}   {ani.MaxKeyframe}   {ani.Unknown2}   {ani.BoneSteps.Count}");

            Console.WriteLine("Steps:  {BoneIndex  RotationsCount  TranslationsCount}");
            foreach (var aniStep in ani.BoneSteps)
            {
                Console.WriteLine($"{{{aniStep.BoneIndex}  {aniStep.KeyframeRotations.Count}  {aniStep.KeyframeTranslations.Count}}}");
            }

            Faster(ani);

            ani.Write("demf_001_walk.created.ANI");
        }

        public static void Faster(Ani ani)
        {
            foreach (var boneStep in ani.BoneSteps)
            {
                foreach (var translation in boneStep.KeyframeTranslations)
                {
                    translation.Keyframe /= 2;
                }

                foreach (var rotations in boneStep.KeyframeRotations)
                {
                    rotations.Keyframe /= 2;
                }
            }

            ani.MaxKeyframe /= 2;
        }
    }
}
