using System;
using Parsec.Extensions;
using Xunit;

namespace Parsec.Tests.Extensions;

public class ArrayExtensionsTests
{
    [Fact]
    public void SubArrayTest()
    {
        var originalArray = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        Assert.Equal(new[] { 0, 1, 2 }, originalArray.SubArray(0, 3));
        Assert.Equal(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, originalArray.SubArray(0, 10));
        Assert.Equal(new int[] {}, originalArray.SubArray(0, 0));
        Assert.Equal(new int[] {}, originalArray.SubArray(10, 0));
        Assert.Equal(new[] { 4, 5, 6, 7 }, originalArray.SubArray(4, 4));

        Assert.Throws<ArgumentException>(() => originalArray.SubArray(10, 10));
        Assert.Throws<ArgumentException>(() => originalArray.SubArray(-1, 5));
    }
}
