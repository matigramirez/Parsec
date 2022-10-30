using Parsec.Shaiya.Item;
using Xunit;

namespace Parsec.Tests.Shaiya.SData;

public class BinarySDataTests
{
    [Fact]
    public void BinarySDataCsvTest()
    {
        const string filePath = "Shaiya/SData/DBItemData.SData";
        const string decryptedOutputPath = "Shaiya/SData/output.dec.DBItemData.SData";
        const string encryptedOutputPath = "Shaiya/SData/output.enc.DBItemData.SData";
        const string csvPath = "Shaiya/SData/DBItemData.SData.csv";
        const string csvDecryptedOutputPath = "Shaiya/SData/DBItemData.csv.dec.SData";
        const string csvEncryptedOutputPath = "Shaiya/SData/DBItemData.csv.enc.SData";

        var itemData = Reader.ReadFromFile<DBItemData>(filePath);
        // Clear header so that only the field names and data are checked
        itemData.Header = new byte[128];
        itemData.ExportCsv(csvPath);
        itemData.WriteEncrypted(encryptedOutputPath);
        itemData.WriteDecrypted(decryptedOutputPath);

        var itemDataFromCsv = DBItemData.ReadFromCsv<DBItemData>(csvPath);
        itemDataFromCsv.WriteEncrypted(csvEncryptedOutputPath);
        itemDataFromCsv.WriteDecrypted(csvDecryptedOutputPath);

        Assert.Equal(itemData.GetBytes(), itemDataFromCsv.GetBytes());
        Assert.Equal(FileHash.Checksum(decryptedOutputPath), FileHash.Checksum(csvDecryptedOutputPath));
        Assert.Equal(FileHash.Checksum(encryptedOutputPath), FileHash.Checksum(csvEncryptedOutputPath));
    }
}
