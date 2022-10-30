using System.IO;
using System.Security.Cryptography;

namespace Parsec.Tests;

public static class FileHash
{
    public static byte[] Checksum(string filePath)
    {
        using var md5 = MD5.Create();
        using var stream = File.OpenRead(filePath);
        return md5.ComputeHash(stream);
    }
}
