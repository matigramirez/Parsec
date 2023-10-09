using System.Linq;
using Parsec.Shaiya.Cash;

namespace Parsec.Tests.Shaiya.Cash;

public class CashTests
{
    [Fact]
    public void CashTest()
    {
        const string filePath = "Shaiya/Cash/Cash.SData";
        const string outputPath = "Shaiya/Cash/Cash_new.SData";

        var cash = ParsecReader.FromFile<Parsec.Shaiya.Cash.Cash>(filePath);
        cash.Write(outputPath);
        var newCash = ParsecReader.FromFile<Parsec.Shaiya.Cash.Cash>(outputPath);
        Assert.Equal(cash.GetBytes(), newCash.GetBytes());
        Assert.Equal(FileHash.Checksum(filePath), FileHash.Checksum(outputPath));
    }

    [Fact]
    public void DbItemSellTest()
    {
        const string filePath = "Shaiya/Cash/DBItemSellData.SData";
        const string outputPath = "Shaiya/Cash/output_DBItemSellData.SData";
        const string jsonPath = "Shaiya/Cash/DBItemSellData.SData.json";
        const string csvPath = "Shaiya/Cash/DBItemSellData.SData.csv";

        var dbItemSell = ParsecReader.FromFile<DBItemSellData>(filePath);
        dbItemSell.Write(outputPath);
        dbItemSell.WriteJson(jsonPath);
        dbItemSell.WriteCsv(csvPath);

        var outputDbItemSell = ParsecReader.FromFile<DBItemSellData>(outputPath);
        var jsonDbItemSell = ParsecReader.FromJsonFile<DBItemSellData>(jsonPath);
        var csvItemSell = DBItemSellData.FromCsv<DBItemSellData>(csvPath);

        var expected = dbItemSell.GetBytes().ToList();
        Assert.Equal(expected, outputDbItemSell.GetBytes());
        Assert.Equal(expected, jsonDbItemSell.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvItemSell.GetBytes().Skip(128));
    }
}
