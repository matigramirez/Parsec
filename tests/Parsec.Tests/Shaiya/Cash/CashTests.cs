namespace Parsec.Tests.Shaiya.Cash;

public class CashTests
{
    [Fact]
    public void CashTest()
    {
        const string filePath = "Shaiya/Cash/Cash.SData";
        const string outputPath = "Shaiya/Cash/Cash_new.SData";

        var cash = Reader.ReadFromFile<Parsec.Shaiya.Cash.Cash>(filePath);
        cash.Write(outputPath);
        var newCash = Reader.ReadFromFile<Parsec.Shaiya.Cash.Cash>(outputPath);
        Assert.Equal(cash.GetBytes(), newCash.GetBytes());
        Assert.Equal(FileHash.Checksum(filePath), FileHash.Checksum(outputPath));
    }
}
