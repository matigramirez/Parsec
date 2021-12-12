using System.IO;
using Parsec.Helpers;

namespace Parsec.Shaiya.DATA
{
    public class Saf
    {
        /// <summary>
        /// The sah file that corresponds to this saf
        /// </summary>
        private Sah _sah;

        public Saf(Sah sah)
        {
            _sah = sah;
        }

        /// <summary>
        /// Extracts all the content of the saf file into a directory
        /// </summary>
        /// <param name="extractionPath">Path where files should be saved</param>
        public void ExtractAll(string extractionPath)
        {
            Directory.CreateDirectory(extractionPath);
            Extract(_sah.RootFolder, extractionPath);
        }

        /// <summary>
        /// Extracts a shaiya folder from the saf file
        /// </summary>
        /// <param name="folder">Folder to extract</param>
        /// <param name="extractionDirectory">Directory where folder should be extracted</param>
        public void Extract(SahFolder folder, string extractionDirectory)
        {
            var extractionPath = Path.Combine(extractionDirectory, folder.Name);
            Directory.CreateDirectory(extractionPath);

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
        /// <param name="file">The <see cref="SahFile" /> instance to extract</param>
        /// <param name="extractionDirectory">The directory where the file should be saved</param>
        public void Extract(SahFile file, string extractionDirectory)
        {
            var fileBytes = ReadSafBytes(file.Offset, file.Length);
            FileHelper.WriteFile(Path.Combine(extractionDirectory, file.Name), fileBytes);
        }

        /// <summary>
        /// Reads an array of bytes from the saf file
        /// </summary>
        /// <param name="offset">Offset where to start reading</param>
        /// <param name="length">Amount of bytes to read</param>
        private byte[] ReadSafBytes(long offset, int length)
        {
            // Create binary reader
            using var safReader = new BinaryReader(File.OpenRead(_sah.SafPath));
            safReader.BaseStream.Seek(offset, SeekOrigin.Begin);

            // Read bytes
            byte[] bytes = safReader.ReadBytes(length);
            return bytes;
        }
    }
}
