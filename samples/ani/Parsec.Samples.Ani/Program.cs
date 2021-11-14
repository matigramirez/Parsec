using System;
using System.Collections.Generic;
using Parsec.Shaiya.ANI;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "Mob_Fox_01_Run.ANI";

            var ani = new Ani(filePath);
            ani.Read();

            Console.WriteLine($"shStudio ani fields for file {filePath}:");
            Console.WriteLine("StartKeyframe  EndKeyframe  BoneStepsCount");
            Console.WriteLine($"{ani.StartKeyframe}   {ani.EndKeyframe}  {ani.Bones.Count}");

            Console.WriteLine("Steps:  {BoneIndex  RotationsCount  TranslationsCount}");
            foreach (var aniStep in ani.Bones)
            {
                Console.WriteLine($"{{{aniStep.ParentBoneIndex}  {aniStep.KeyframeRotations.Count}  {aniStep.KeyframeTranslations.Count}}}");
            }

            ani.ExportJson($"{ani.FileNameWithoutExtension}.json", new List<string>{ "isIdentity" });
        }
    }
}
