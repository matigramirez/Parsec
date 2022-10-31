namespace Parsec.Tests.Shaiya.Ani;

public class AniTests
{
    [Theory]
    [InlineData("Cloud_att1.ANI")]
    [InlineData("Ctl_Cow_01_Idle.ANI")]
    [InlineData("ctl_pig_01_die.ANI")]
    [InlineData("demf_005_rstep.ANI")]
    [InlineData("demf_104_skill005.ANI")]
    [InlineData("elephant_Bwa.ANI")]
    [InlineData("EV_Santa_br.ANI")]
    [InlineData("M_A8B8_02_a01_wa.ANI")]
    [InlineData("m_dab7_06_a01_att3.ANI")]
    [InlineData("Mob_Apis_Knight_Idle.ANI")]
    [InlineData("mob_bawii_walk.ANI")]
    [InlineData("Mob_Ifrit_die.ANI")]
    [InlineData("Mob_Succubus_01_Walk.ANI")]
    [InlineData("Unicorn_run.ANI")]
    [InlineData("vehicle_De_06_br.ANI")]
    [InlineData("WhiteWing_bas.ANI")]
    [InlineData("Wing_01.ANI")]
    public void AniMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/ANI/{fileName}";
        string jsonPath = $"Shaiya/ANI/{fileName}.json";
        string newObjPath = $"Shaiya/ANI/new_{fileName}";

        var ani = Reader.ReadFromFile<Parsec.Shaiya.Ani.Ani>(filePath);
        ani.ExportJson(jsonPath);
        var aniFromJson = Reader.ReadFromJson<Parsec.Shaiya.Ani.Ani>(jsonPath);

        // Check bytes
        Assert.Equal(ani.GetBytes(), aniFromJson.GetBytes());

        aniFromJson.Write(newObjPath);
        var newANi = Reader.ReadFromFile<Parsec.Shaiya.Ani.Ani>(newObjPath);

        // Check bytes
        Assert.Equal(ani.GetBytes(), newANi.GetBytes());
    }
}
