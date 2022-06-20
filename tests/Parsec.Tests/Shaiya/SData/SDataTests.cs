using System.ComponentModel;
using System.IO;
using Parsec.Common;
using Parsec.Shaiya.Item;
using Parsec.Shaiya.SData;
using Xunit;

namespace Parsec.Tests.Shaiya;

public class SDataTests
{
    private const string EncryptedSDataFilePath = "Shaiya/SData/ItemEp6.enc.SData";
    private const string DecryptedSDataFilePath = "Shaiya/SData/ItemEp6.dec.SData";

    [Fact]
    [Description("Tests the byte buffer encryption and decryption")]
    public void SDataBufferEncryptionTest()
    {
        // Encrypt file buffer
        var decryptedFileBuffer = File.ReadAllBytes(DecryptedSDataFilePath);
        var encryptedOutput = SData.Encrypt(decryptedFileBuffer);

        Assert.False(SData.IsEncrypted(decryptedFileBuffer));
        Assert.True(SData.IsEncrypted(encryptedOutput));

        // Decrypt file buffer
        var encryptedFileBuffer = File.ReadAllBytes(EncryptedSDataFilePath);
        var decryptedBuffer = SData.Decrypt(encryptedFileBuffer, true);

        Assert.True(SData.IsEncrypted(encryptedFileBuffer));
        Assert.False(SData.IsEncrypted(decryptedBuffer));
    }

    [Fact]
    [Description("Tests the file encryption and decryption")]
    public void SDataFileEncryptionTest()
    {
        // Encrypt file
        const string encryptedOutputPath = "Shaiya/SData/ItemEp6.encrypted.SData";
        SData.EncryptFile(DecryptedSDataFilePath, encryptedOutputPath);

        var encryptedBuffer = File.ReadAllBytes(encryptedOutputPath);
        Assert.True(SData.IsEncrypted(encryptedBuffer));

        // Decrypt file
        const string decryptedOutputPath = "Shaiya/SData/ItemEp6.decrypted.SData";
        SData.DecryptFile(EncryptedSDataFilePath, decryptedOutputPath);

        var decryptedBuffer = File.ReadAllBytes(decryptedOutputPath);
        Assert.False(SData.IsEncrypted(decryptedBuffer));
    }

    [Fact]
    [Description("Tests writing an encrypted and decrypted SData child instance")]
    public void SDataDecryptionTest()
    {
        const string encryptedOutputPath = "Shaiya/SData/ItemEp6.encrypted.SData";
        const string decryptedOutputPath = "Shaiya/SData/ItemEp6.decrypted.SData";

        var item = Reader.ReadFromFile<Item>(EncryptedSDataFilePath, Episode.EP6);
        item.WriteEncrypted(encryptedOutputPath, Episode.EP6);
        item.WriteDecrypted(decryptedOutputPath, Episode.EP6);

        var encryptedBuffer = File.ReadAllBytes(encryptedOutputPath);
        var decryptedBuffer = File.ReadAllBytes(decryptedOutputPath);

        Assert.True(SData.IsEncrypted(encryptedBuffer));
        Assert.False(SData.IsEncrypted(decryptedBuffer));
    }
}
