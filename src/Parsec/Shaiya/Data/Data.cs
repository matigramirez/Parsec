using System;
using System.Collections.Generic;
using System.IO;
using Parsec.Extensions;
using Parsec.Helpers;
using Parsec.Readers;

namespace Parsec.Shaiya.Data
{
    public class Data
    {
        public Sah Sah { get; set; }
        public Saf Saf { get; set; }

        public int FileCount
        {
            get => Sah.FileCount;
            set => Sah.FileCount = value;
        }

        /// <summary>
        /// Dictionary of folders that can be accessed by path
        /// </summary>
        public Dictionary<string, SFolder> FolderIndex => Sah.FolderIndex;

        /// <summary>
        /// Dictionary of files that can be accessed by path
        /// </summary>
        public Dictionary<string, SFile> FileIndex => Sah.FileIndex;

        public Data(Sah sah, Saf saf)
        {
            Sah = sah;
            Saf = saf;
        }

        public Data(string path)
        {
            if (!FileHelper.FileExists(path))
                throw new FileNotFoundException($"Data file not found at {path}");

            switch (Path.GetExtension(path))
            {
                case ".sah":
                {
                    var safPath = path.Substring(0, path.Length - 3) + "saf";

                    if (!FileHelper.FileExists(safPath))
                        throw new FileNotFoundException(
                            "A valid saf file must be placed in the same directory as the sah file.");

                    Sah = Reader.ReadFromFile<Sah>(path);
                    Saf = new Saf(safPath);
                    break;
                }
                case ".saf":
                {
                    var sahPath = path.Substring(0, path.Length - 3) + "sah";

                    if (!FileHelper.FileExists(sahPath))
                        throw new FileNotFoundException(
                            "A valid sah file must be placed in the same directory as the saf file.");

                    Sah = Reader.ReadFromFile<Sah>(sahPath);
                    Saf = new Saf(path);
                    break;
                }
                default:
                    throw new ArgumentException("The provided path must belong to either a .sah or a .saf file");
            }
        }

        /// <summary>
        /// Extracts the whole data file
        /// </summary>
        /// <param name="extractionDirectory">Extraction directory path</param>
        public void ExtractAll(string extractionDirectory) => Extract(Sah.RootFolder, extractionDirectory);

        /// <summary>
        /// Extracts a shaiya folder from the saf file. If the folder to be extracted is the root folder,
        /// then the folder's content gets extracted in the provided extraction directory and if it's not,
        /// a child directory will be created inside the provided extraction directory
        /// </summary>
        /// <param name="folder">The <see cref="SFolder"/> instance to extract</param>
        /// <param name="extractionDirectory">Extraction directory path</param>
        public void Extract(SFolder folder, string extractionDirectory)
        {
            // Create extraction path
            string extractionPath = extractionDirectory;

            if (folder != Sah.RootFolder)
                extractionPath = Path.Combine(extractionDirectory, folder.Name);

            FileHelper.CreateDirectory(extractionPath);

            // Extract files
            foreach (var file in folder.Files)
                Extract(file, extractionPath);

            // Extract subfolders
            foreach (var subfolder in folder.Subfolders)
                Extract(subfolder, extractionPath);
        }

        /// <summary>
        /// Extracts a single file into a directory
        /// </summary>
        /// <param name="file">The <see cref="SFile" /> instance to extract</param>
        /// <param name="extractionDirectory">Extraction directory path</param>
        public void Extract(SFile file, string extractionDirectory)
        {
            // TODO: Find a better solution for files with korean characters
            // Skip files with invalid characters
            if (file.Name.HasInvalidCharacters())
                return;

            var fileBytes = Saf.ReadBytes(file.Offset, file.Length);
            FileHelper.WriteFile(Path.Combine(extractionDirectory, file.Name), fileBytes);
        }

        /// <summary>
        /// Reads a file buffer from the saf file
        /// </summary>
        /// <param name="file"><see cref="SFile"/> instance</param>
        /// <returns>The file buffer</returns>
        public byte[] GetFileBuffer(SFile file) => Saf.ReadBytes(file.Offset, file.Length);

        /// <summary>
        /// Removes a file from both the sah and saf files
        /// </summary>
        /// <param name="path"></param>
        public void RemoveFile(string path)
        {
            if (!FileIndex.TryGetValue(path, out var file))
                return;

            // Remove file from sah
            Sah.FileCount--;
            file.ParentFolder.Files.Remove(file);
            FileIndex.Remove(path);

            // Clear bytes on saf
            Saf.ClearBytes(file.Offset, file.Length);
        }

        /// <summary>
        /// Removes
        /// </summary>
        /// <param name="lstPath">Path to delete.lst file</param>
        public void RemoveFilesFromLst(string lstPath)
        {
            var filePaths = File.ReadAllLines(lstPath);

            foreach (var file in filePaths)
                RemoveFile(file);
        }
    }
}
