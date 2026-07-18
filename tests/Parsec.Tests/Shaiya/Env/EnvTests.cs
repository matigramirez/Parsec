using System.IO;
using System.Linq;
using Parsec.Shaiya.Env;

using EnvFile = Parsec.Shaiya.Env.Env;

namespace Parsec.Tests.Shaiya.Environment;

public class EnvTests
{
    [Fact]
    public void EnvParsesTeststuffV2LayoutAndRoundTrips()
    {
        var bytes = CreateEnvironment();

        var env = ParsecReader.FromBuffer<EnvFile>("sample.env", bytes);

        Assert.Equal("V2", env.Header);
        Assert.Single(env.Records);

        var record = env.Records[0];
        Assert.Equal((ushort)600, record.StartMinute);
        Assert.Equal((ushort)1439, record.EndMinute);
        Assert.Equal(EnvRecord.ColorCount, record.Colors.Length);
        Assert.Equal(128f / 255f, record.Colors[0].Red);
        Assert.Equal(64f / 255f, record.Colors[0].Green);
        Assert.Equal(32f / 255f, record.Colors[0].Blue);
        Assert.Equal(new[] { "sky.bmp", "cloud.tga", "empty.tga", "empty.tga" }, record.SkyNames);
        Assert.Equal(new[] { 0.5f, 0.8f, 2.15f, 1.1f, 1.3f, 1.4f }, record.Lighting);
        Assert.False(record.Weather);
        Assert.Equal((uint)60_000, record.TransitionMilliseconds);
        Assert.Equal(bytes, env.GetBytes());

        var fromJson = ParsecReader.FromJson<EnvFile>("sample.env", env.JsonSerialize());
        Assert.Equal(bytes, fromJson.GetBytes());
    }

    [Fact]
    public void EnvTreatsEveryNonZeroWeatherFlagAsTrue()
    {
        var env = ParsecReader.FromBuffer<EnvFile>("weather.env", CreateEnvironment(weather: 2));

        Assert.True(env.Records[0].Weather);
    }

    [Fact]
    public void EnvRejectsInvalidHeaderAndRecordCounts()
    {
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<EnvFile>("short.env", new byte[5]));
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<EnvFile>("header.env", CreateHeaderAndCount("V1", 1)));
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<EnvFile>("empty.env", CreateHeaderAndCount("V2", 0)));
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<EnvFile>("large.env", CreateHeaderAndCount("V2", EnvFile.MaximumRecordCount + 1)));
    }

    [Fact]
    public void EnvRejectsInvalidRecordValues()
    {
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<EnvFile>("time.env", CreateEnvironment(startTime: 2400)));
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<EnvFile>("color.env", CreateEnvironment(red: 256)));
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<EnvFile>("lighting.env", CreateEnvironment(firstLighting: float.NaN)));
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<EnvFile>("transition.env", CreateEnvironment(transitionMilliseconds: -1)));
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<EnvFile>("name.env", CreateEnvironment(firstSkyName: new string('x', EnvRecord.MaximumSkyNameByteLength + 1))));
    }

    [Fact]
    public void EnvRejectsTruncationAndTrailingData()
    {
        var valid = CreateEnvironment();
        var truncated = valid.Take(valid.Length - 1).ToArray();
        var trailing = valid.Concat(new byte[] { 0xcd }).ToArray();

        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<EnvFile>("truncated.env", truncated));
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<EnvFile>("trailing.env", trailing));
    }

    [Fact]
    public void EnvWriterOnlyProducesValidV2Files()
    {
        Assert.Throws<InvalidDataException>(() => new EnvFile().GetBytes());

        var env = ParsecReader.FromBuffer<EnvFile>("sample.env", CreateEnvironment());
        env.Header = "V1";
        Assert.Throws<InvalidDataException>(() => env.GetBytes());

        env.Header = "V2";
        env.Records[0].Colors[0] = new EnvColor { Red = 2, Green = 0, Blue = 0 };
        Assert.Throws<InvalidDataException>(() => env.GetBytes());
    }

    private static byte[] CreateHeaderAndCount(string header, int count)
    {
        using var stream = new MemoryStream();
        using var writer = new BinaryWriter(stream);
        writer.Write(System.Text.Encoding.ASCII.GetBytes(header));
        writer.Write(count);
        return stream.ToArray();
    }

    private static byte[] CreateEnvironment(
        int startTime = 1000,
        int red = 128,
        float firstLighting = 0.5f,
        byte weather = 0,
        int transitionMilliseconds = 60_000,
        string firstSkyName = "sky.bmp")
    {
        using var stream = new MemoryStream();
        using var writer = new BinaryWriter(stream);

        writer.Write(new[] { (byte)'V', (byte)'2' });
        writer.Write(1);
        writer.Write(startTime);
        writer.Write(2359);

        WriteColor(writer, red, 64, 32);
        WriteColor(writer, 10, 20, 30);
        WriteColor(writer, 200, 210, 220);

        WriteString(writer, firstSkyName);
        WriteString(writer, "cloud.tga");
        WriteString(writer, "empty.tga");
        WriteString(writer, "empty.tga");

        writer.Write(firstLighting);
        writer.Write(0.8f);
        writer.Write(2.15f);
        writer.Write(1.1f);
        writer.Write(1.3f);
        writer.Write(1.4f);
        writer.Write(weather);
        writer.Write(transitionMilliseconds);

        return stream.ToArray();
    }

    private static void WriteColor(BinaryWriter writer, int red, int green, int blue)
    {
        writer.Write(red);
        writer.Write(green);
        writer.Write(blue);
    }

    private static void WriteString(BinaryWriter writer, string value)
    {
        var bytes = System.Text.Encoding.ASCII.GetBytes(value);
        writer.Write(bytes.Length);
        writer.Write(bytes);
    }
}
