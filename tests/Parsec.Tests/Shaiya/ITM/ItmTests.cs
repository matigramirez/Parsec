using System.IO;
using System.Text;
using Parsec.Shaiya.Itm;

namespace Parsec.Tests.Shaiya.ITM;

public class ItmTests
{
    [Theory]
    [InlineData("01.ITM")]
    [InlineData("04.ITM")]
    [InlineData("05.ITM")]
    [InlineData("08.ITM")]
    [InlineData("10.ITM")]
    [InlineData("13.ITM")]
    [InlineData("19.ITM")]
    public void ItmMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/ITM/{fileName}";
        string jsonPath = $"Shaiya/ITM/{fileName}.json";
        string newObjPath = $"Shaiya/ITM/new_{fileName}";

        var itm = ParsecReader.FromFile<Parsec.Shaiya.Itm.Itm>(filePath);
        itm.WriteJson(jsonPath);
        var itmFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya.Itm.Itm>(jsonPath);

        // Check bytes
        Assert.Equal(itm.GetBytes(), itmFromJson.GetBytes());

        itmFromJson.Write(newObjPath);
        var newItm = ParsecReader.FromFile<Parsec.Shaiya.Itm.Itm>(newObjPath);

        // Check bytes
        Assert.Equal(itm.GetBytes(), newItm.GetBytes());
    }

    [Fact]
    public void It2DecodesCharacterBoneTransforms()
    {
        var bytes = CreateIt2Fixture();
        var itm = ParsecReader.FromBuffer<Itm>("fixture.ITM", bytes);

        Assert.Equal(ItmFormat.IT2, itm.Format);
        var record = Assert.Single(itm.Records);
        Assert.Equal(16, record.CharacterTransforms.Count);

        var dewf = Assert.Single(
            record.CharacterTransforms,
            transforms => transforms.CharacterCode == ItmCharacterCode.DEWF);
        Assert.Equal(25, dewf.Primary.Bone);
        Assert.Equal(0.095f, dewf.Primary.Position.X);
        Assert.Equal(0.085f, dewf.Primary.Position.Y);
        Assert.Equal(0f, dewf.Primary.Position.Z);
        Assert.Equal(-0.043364f, dewf.Primary.Rotation.X);
        Assert.Equal(-0.735978f, dewf.Primary.Rotation.Y);
        Assert.Equal(0.021144f, dewf.Primary.Rotation.Z);
        Assert.Equal(0.675285f, dewf.Primary.Rotation.W);

        Assert.Equal(bytes, itm.GetBytes());

        var fromJson = ParsecReader.FromJson<Itm>(
            "fixture.ITM",
            itm.JsonSerialize());
        Assert.Equal(bytes, fromJson.GetBytes());
    }

    private static byte[] CreateIt2Fixture()
    {
        using var stream = new MemoryStream();
        using var writer = new BinaryWriter(stream, Encoding.ASCII, leaveOpen: true);

        writer.Write(Encoding.ASCII.GetBytes("IT2"));
        writer.Write(1);
        WriteString(writer, "06001.3DO");
        writer.Write(1);
        WriteString(writer, "06001.dds");
        writer.Write(1);

        writer.Write(0);
        writer.Write(0);
        writer.Write(-1);
        writer.Write(0);
        writer.Write((int)ItmRecordFormat.Simple);
        writer.Write(0);

        for (var characterIndex = 0; characterIndex < 16; characterIndex++)
        {
            for (var transformIndex = 0; transformIndex < 2; transformIndex++)
            {
                var isDewfPrimary =
                    characterIndex == (int)ItmCharacterCode.DEWF &&
                    transformIndex == 0;
                writer.Write(isDewfPrimary ? 25 : 0);
                writer.Write(isDewfPrimary ? 0.095f : 0f);
                writer.Write(isDewfPrimary ? 0.085f : 0f);
                writer.Write(0f);
                writer.Write(isDewfPrimary ? -0.043364f : 0f);
                writer.Write(isDewfPrimary ? -0.735978f : 0f);
                writer.Write(isDewfPrimary ? 0.021144f : 0f);
                writer.Write(isDewfPrimary ? 0.675285f : 1f);
            }
        }

        writer.Flush();
        return stream.ToArray();
    }

    private static void WriteString(BinaryWriter writer, string value)
    {
        var bytes = Encoding.ASCII.GetBytes(value + '\0');
        writer.Write(bytes.Length);
        writer.Write(bytes);
    }
}
