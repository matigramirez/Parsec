namespace Parsec.Shaiya.Data;

public sealed class Saf
{
    public Saf(string path)
    {
        Path = path;
    }

    /// <summary>
    /// Absolute path to the saf file
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Reads an array of bytes from the saf file
    /// </summary>
    /// <param name="offset">Offset where to start reading</param>
    /// <param name="length">Amount of bytes to read</param>
    public byte[] ReadBytes(long offset, int length)
    {
        using var safReader = new BinaryReader(File.OpenRead(Path));
        safReader.BaseStream.Seek(offset, SeekOrigin.Begin);

        var bytes = safReader.ReadBytes(length);
        return bytes;
    }

    /// <summary>
    /// Clears a section of the saf file. The section will be set to `0`, since it can't be removed directly
    /// </summary>
    /// <param name="offset">Offset where to start clearing</param>
    /// <param name="length">Amount of bytes to clear</param>
    public void ClearBytes(long offset, int length)
    {
        using var safWriter = new BinaryWriter(File.OpenWrite(Path));
        safWriter.BaseStream.Seek(offset, SeekOrigin.Begin);

        var emptyBytes = new byte[length];
        safWriter.Write(emptyBytes);
    }
}
