using System.IO;

namespace Parsec.Helpers
{
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
        public static void WriteFile(string path, byte[] data)
        {
            if (FileExists(path))
            {
                DeleteFile($"{path}.bak");
                RenameFile(path, $"{path}.bak");
            }

            var directoryPath = Path.GetDirectoryName(path);

            if (!string.IsNullOrEmpty(directoryPath))
                CreateDirectory(directoryPath);

            // Create file and save data
            using var binaryWriter =
                new BinaryWriter(File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None));

            binaryWriter.Write(data);
            binaryWriter.Dispose();
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
        public static void CreateDirectory(string directoryPath)
        {
            if (DirectoryExists(directoryPath) || string.IsNullOrEmpty(directoryPath))
                return;

            Directory.CreateDirectory(directoryPath);
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
    }
}
