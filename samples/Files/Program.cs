using Parsec;
using Parsec.Shaiya.SData;
using Parsec.Shaiya.Skill;

namespace Sample.Files;

internal static class Program
{
    private static void Main(string[] args)
    {
        SData.DecryptFile("/home/matias/Desktop/DBSkillData.SData", "/home/matias/Desktop/DBSkillData.dec.SData");

        var skillData = ParsecReader.FromFile<DBSkillData>("/home/matias/Desktop/DBSkillData.dec.SData");

        skillData.Write("/home/matias/Desktop/DBSkillData.dec.new.SData");

        var newSkillData = ParsecReader.FromFile<DBSkillData>("/home/matias/Desktop/DBSkillData.dec.new.SData");
    }
}
