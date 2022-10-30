using System.IO;
using Parsec.Extensions;
using Xunit;

namespace Parsec.Tests.Extensions;

public class StringExtensionsTests
{
    [Fact]
    public void StringSeparationTest()
    {
        const string text = @"C:/Users/Parsec/filename.ext";

        var expected = new[] { "C:", "Users", "Parsec", "filename.ext" };

        string[] actual = text.Separate('/');

        Assert.Equal(expected.Length, actual.Length);

        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void InvalidCharactersTest()
    {
        var validCharacters = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789-_.#@";

        var invalidCharacters = new string(Path.GetInvalidPathChars()) + new string(Path.GetInvalidFileNameChars());

        Assert.False(validCharacters.HasInvalidCharacters());
        Assert.True(invalidCharacters.HasInvalidCharacters());
    }

    [Theory]
    [InlineData("HelloWorld", "helloWorld")]
    [InlineData("CamelCase", "camelCase")]
    [InlineData("Csharp", "csharp")]
    public void CamelCaseTest(string str, string camelCaseText)
    {
        Assert.Equal(str.ToCamelCase(), camelCaseText);
    }
}
