using System;
using Parsec.Readers;
using Parsec.Shaiya.ALT;
using Parsec.Shaiya.Ani;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ANI

            var filePath = "Mob_Fox_01_Run.ANI";

            var ani = Reader.ReadFromFile<Ani>(filePath);

            Console.WriteLine($"Ani file {filePath}:");
            Console.WriteLine("StartKeyframe  EndKeyframe  BoneStepsCount");
            Console.WriteLine($"{ani.StartKeyframe}   {ani.EndKeyframe}  {ani.Bones.Count}");

            Console.WriteLine("Steps:  {BoneIndex  RotationsCount  TranslationsCount}");

            foreach (var aniStep in ani.Bones)
                Console.WriteLine(
                    $"{{{aniStep.ParentBoneIndex}  {aniStep.Rotations.Count}  {aniStep.Translations.Count}}}");

            ani.ExportJson($"{ani.FileNameWithoutExtension}.json", "isIdentity");

            #endregion

            #region ALT

            var alt = Reader.ReadFromFile<ALT>("demf_action.alt");
            alt.ExportJson($"{alt.FileName}.json");

            #endregion
        }
    }
}
