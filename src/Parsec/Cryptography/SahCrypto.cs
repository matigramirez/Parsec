namespace Parsec.Cryptography;

public sealed class SahCrypto
{
    public Func<int, int> DecryptFileCount { get; set; }
    public Func<int, int> EncryptFileCount { get; set; }

    public Func<string, string> DecryptFileName { get; set; }
    public Func<string, string> EncryptFileName { get; set; }

    public Func<int, int> DecryptFolderCount { get; set; }
    public Func<int, int> EncryptFolderCount { get; set; }

    public Func<string, string> DecryptFolderName { get; set; }
    public Func<string, string> EncryptFolderName { get; set; }

    public static SahCrypto Default { get; } = new()
    {
        DecryptFileCount = x => x,
        EncryptFileCount = x => x,
        DecryptFileName = x => x,
        EncryptFileName = x => x,
        DecryptFolderCount = x => x,
        EncryptFolderCount = x => x,
        DecryptFolderName = x => x,
        EncryptFolderName = x => x
    };

    public static SahCrypto WithFileCountXorKey(int fileCountKey)
    {
        var crypto = Default;
        crypto.DecryptFileCount = x => x ^ fileCountKey;
        crypto.EncryptFileCount = x => x ^ fileCountKey;
        return crypto;
    }

    public static SahCrypto WithFolderCountXorKey(int folderCountKey)
    {
        var crypto = Default;
        crypto.DecryptFolderCount = x => x ^ folderCountKey;
        crypto.EncryptFolderCount = x => x ^ folderCountKey;
        return crypto;
    }

    public static SahCrypto WithXorKeys(int fileCountKey, int folderCountKey)
    {
        var crypto = Default;
        crypto.DecryptFileCount = x => x ^ fileCountKey;
        crypto.EncryptFileCount = x => x ^ fileCountKey;
        crypto.DecryptFolderCount = x => x ^ folderCountKey;
        crypto.EncryptFolderCount = x => x ^ folderCountKey;
        return crypto;
    }
}
