using System.ComponentModel;
using System.IO;
using Parsec.Common;

namespace Parsec.Tests.Shaiya.SData;

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
        var encryptedOutput = Parsec.Shaiya.SData.SData.Encrypt(decryptedFileBuffer);

        Assert.False(Parsec.Shaiya.SData.SData.IsEncrypted(decryptedFileBuffer));
        Assert.True(Parsec.Shaiya.SData.SData.IsEncrypted(encryptedOutput));

        // Decrypt file buffer
        var encryptedFileBuffer = File.ReadAllBytes(EncryptedSDataFilePath);
        var decryptedBuffer = Parsec.Shaiya.SData.SData.Decrypt(encryptedFileBuffer, true);

        Assert.True(Parsec.Shaiya.SData.SData.IsEncrypted(encryptedFileBuffer));
        Assert.False(Parsec.Shaiya.SData.SData.IsEncrypted(decryptedBuffer));

        Assert.Equal(FileHash.Checksum(decryptedBuffer), FileHash.Checksum(decryptedFileBuffer));
        Assert.Equal(FileHash.Checksum(encryptedFileBuffer), FileHash.Checksum(encryptedFileBuffer));
    }

    [Fact]
    [Description("Tests the file encryption and decryption")]
    public void SDataFileEncryptionTest()
    {
        // Encrypt file
        const string outputEncryptedFilePath = "Shaiya/SData/ItemEp6.encrypted.SData";
        Parsec.Shaiya.SData.SData.EncryptFile(DecryptedSDataFilePath, outputEncryptedFilePath);

        var encryptedBuffer = File.ReadAllBytes(outputEncryptedFilePath);
        Assert.True(Parsec.Shaiya.SData.SData.IsEncrypted(encryptedBuffer));

        // Decrypt file
        const string outputDecryptedFilePath = "Shaiya/SData/ItemEp6.decrypted.SData";
        Parsec.Shaiya.SData.SData.DecryptFile(EncryptedSDataFilePath, outputDecryptedFilePath);

        var decryptedBuffer = File.ReadAllBytes(outputDecryptedFilePath);
        Assert.False(Parsec.Shaiya.SData.SData.IsEncrypted(decryptedBuffer));

        Assert.Equal(FileHash.Checksum(DecryptedSDataFilePath), FileHash.Checksum(outputDecryptedFilePath));
        Assert.Equal(FileHash.Checksum(EncryptedSDataFilePath), FileHash.Checksum(outputEncryptedFilePath));
    }

    [Fact]
    [Description("Tests writing an encrypted and decrypted SData child instance")]
    public void SDataDecryptionTest()
    {
        const string encryptedOutputPath = "Shaiya/SData/ItemEp6.encrypted.SData";
        const string decryptedOutputPath = "Shaiya/SData/ItemEp6.decrypted.SData";

        var item = ParsecReader.ReadFromFile<Parsec.Shaiya.Item.Item>(EncryptedSDataFilePath, Episode.EP6);
        item.WriteEncrypted(encryptedOutputPath);
        item.WriteDecrypted(decryptedOutputPath);

        var encryptedBuffer = File.ReadAllBytes(encryptedOutputPath);
        var decryptedBuffer = File.ReadAllBytes(decryptedOutputPath);

        Assert.True(Parsec.Shaiya.SData.SData.IsEncrypted(encryptedBuffer));
        Assert.False(Parsec.Shaiya.SData.SData.IsEncrypted(decryptedBuffer));
    }
}
