using System.IO;
using System.Linq;
using Parsec.Readers;

namespace Parsec.Helpers;

public static class FileHelper
{
    /// <summary>
    /// Check if a file exists.
    /// </summary>
    /// <param name="path">Path to the file to check</param>
    public static bool FileExists(string path) => File.Exists(path);

    /// <summary>
    /// Writes a file to the file system.
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="data">The data byte array</param>
    /// <param name="backupIfExists">Makes a backup of the file if it already existed</param>
    public static bool WriteFile(string path, IEnumerable<byte> data, bool backupIfExists = false)
    {
        if (backupIfExists && FileExists(path))
        {
            DeleteFile($"{path}.bak");
            RenameFile(path, $"{path}.bak");
        }

        string directoryPath = Path.GetDirectoryName(path);

        // Check that directory isn't an empty string
        if (!string.IsNullOrEmpty(directoryPath))
        {
            // Create directory. If it fails to create it because of invalid characters, execution is stopped.
            if (!CreateDirectory(directoryPath))
                return false;
        }

        // Try to write file, it can fail if invalid characters are used in the path.
        try
        {
            // Create file and save data
            using var binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None));

            binaryWriter.Write(data.ToArray());
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Deletes a file making sure it exists.
    /// </summary>
    /// <param name="path">Path of the file to delete</param>
    public static void DeleteFile(string path)
    {
        if (FileExists(path))
        {
            File.Delete(path);
        }
    }

    /// <summary>
    /// Renames a file making sure it exists.
    /// </summary>
    /// <param name="originalPath">Original file's path</param>
    /// <param name="newPath">New file path</param>
    public static void RenameFile(string originalPath, string newPath)
    {
        if (FileExists(originalPath))
        {
            File.Move(originalPath, newPath);
        }
    }

    /// <summary>
    /// Checks if a directory exists.
    /// </summary>
    /// <param name="directoryPath">Path to directory</param>
    public static bool DirectoryExists(string directoryPath) => Directory.Exists(directoryPath);

    /// <summary>
    /// Creates a directory at the specified path.
    /// </summary>
    /// <param name="directoryPath">Directory path</param>
    public static bool CreateDirectory(string directoryPath)
    {
        if (DirectoryExists(directoryPath))
            return true;

        if (string.IsNullOrEmpty(directoryPath))
            return false;

        // Try to create the directory, it will fail and throw an exception if characters are invalid.
        try
        {
            Directory.CreateDirectory(directoryPath);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Deletes the directory at the specified path.
    /// </summary>
    /// <param name="directoryPath">Path to directory</param>
    /// <param name="recursive">Indicates whether the deletion should be recursive or not.</param>
    public static void DeleteDirectory(string directoryPath, bool recursive)
    {
        if (!DirectoryExists(directoryPath))
            return;

        Directory.Delete(directoryPath, recursive);
    }

    /// <summary>
    /// Reads a file's content as a byte array
    /// </summary>
    /// <param name="filePath">Path to file</param>
    public static byte[] ReadBytes(string filePath)
    {
        if (!FileExists(filePath))
            throw new FileNotFoundException($"File {filePath} not found.");

        var binaryReader = new SBinaryReader(filePath);
        return binaryReader.Buffer;
    }
}
