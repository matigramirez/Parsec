using Parsec.Common;
using Parsec.Shaiya.Item;

namespace Sample.SData;

internal class Program
{
    private static void Main(string[] args)
    {
        // Decrypt any SData file
        Parsec.Shaiya.SData.SData.DecryptFile("ItemEP6.SData", "ItemEP6.Decrypted.SData");

        // Read SData from file
        Item item = Parsec.ParsecReader.FromFile<Item>("ItemEP6.SData", Episode.EP6);

        // or.. export it as csv
        item.WriteCsv("Item.csv");

        // Modify the csv file

        // Load the modified csv
        Item itemFromCsv = Item.FromCsv("Item.csv", Episode.EP6);

        // Save the modified file encrypted
        itemFromCsv.WriteEncrypted("Item.Encrypted.SData");
    }
}
