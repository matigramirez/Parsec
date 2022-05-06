using System.Linq;
using Parsec.Shaiya.Data;
using Xunit;

namespace Parsec.Tests.Shaiya;

public class SafTests
{
    [Theory]
    [InlineData(0, 100)]
    [InlineData(200, 500)]
    [InlineData(1000, 3000)]
    public void SafClearingTest(long offset, int length)
    {
        var data = new Data("Shaiya/Data/clearme.sah");

        var nullData = new byte[length];
        data.Saf.ClearBytes(offset, length);

        var newData = data.Saf.ReadBytes(offset, length);
        Assert.True(newData.SequenceEqual(nullData));
    }
}
