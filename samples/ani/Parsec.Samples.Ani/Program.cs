using System;
using Parsec.Shaiya.ANI;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "demf_002_run.ANI";

            var ani = new Ani(filePath);
            ani.Read();
            ani.Export($"{ani.FileNameWithoutExtension}.json");

            Console.WriteLine($"shStudio ani fields for file {filePath}:");
            Console.WriteLine("Unknown1  MaxValue  Unknown2  StepsCount");
            Console.WriteLine($"{ani.Unknown1}   {ani.MaxValue}   {ani.Unknown2}   {ani.AniSteps.Count}");

            Console.WriteLine("Steps:  {BoneIndex  RotationsCount  TranslationsCount}");
            foreach (var aniStep in ani.AniSteps)
            {
                Console.WriteLine($"{{{aniStep.BoneIndex}  {aniStep.Rotations.Count}  {aniStep.Translations.Count}}}");
            }
        }
    }
}
