using System;
using System.Collections.Generic;
using System.IO;
using Parsec.Helpers;
using Parsec.Readers;

namespace Parsec.Shaiya.Data
{
    public class Data
    {
        public Sah Sah { get; set; }
        public Saf Saf { get; set; }

        public int FileCount => Sah.FileCount;

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

            if (Path.GetExtension(path) == ".sah")
            {
                var safPath = path[..^3] + "saf";

                if (!FileHelper.FileExists(safPath))
                    throw new FileNotFoundException("A valid saf file must be placed in the same directory as the sah file.");

                Sah = Reader.ReadFromFile<Sah>(path);
                Saf = new Saf(safPath);
            }
            else if (Path.GetExtension(path) == ".saf")
            {
                var sahPath = path[..^3] + "sah";

                if (!FileHelper.FileExists(sahPath))
                    throw new FileNotFoundException("A valid sah file must be placed in the same directory as the saf file.");

                Sah = Reader.ReadFromFile<Sah>(sahPath);
                Saf = new Saf(path);
            }
            else
            {
                throw new ArgumentException("The provided path must belong to either a .sah or a .saf file");
            }
        }

        /// <summary>
        /// Extracts the whole data file
        /// </summary>
        /// <param name="extractionDirectory">Extraction directory path</param>
        public void ExtractAll(string extractionDirectory) => Extract(Sah.RootFolder, extractionDirectory);

        /// <summary>
        /// Extracts a shaiya folder from the saf file
        /// </summary>
        /// <param name="folder">The <see cref="SFolder"/> instance to extract</param>
        /// <param name="extractionDirectory">Extraction directory path</param>
        public void Extract(SFolder folder, string extractionDirectory)
        {
            var extractionPath = Path.Combine(extractionDirectory, folder.Name);
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
            var fileBytes = Saf.ReadBytes(file.Offset, file.Length);
            FileHelper.WriteFile(Path.Combine(extractionDirectory, file.Name), fileBytes);
        }

        /// <summary>
        /// Reads a file buffer from the saf file
        /// </summary>
        /// <param name="file"><see cref="SFile"/> instance</param>
        /// <returns>The file buffer</returns>
        public byte[] GetFileBuffer(SFile file) => Saf.ReadBytes(file.Offset, file.Length);
    }
}
