using System.IO;
using System.Linq;

namespace Parsec.Shaiya
{
    public static class DataMaker
    {
        /// <summary>
        /// The path to the data directory (both data.sah and data.saf)
        /// </summary>
        private static string _path;

        /// <summary>
        /// The binary write instance for the saf file
        /// </summary>
        private static BinaryWriter _safWriter;

        /// <summary>
        /// The total file count
        /// </summary>
        private static int _fileCount = 0;

        /// <summary>
        /// Creates both sah and saf files based on the data inside a directory
        /// </summary>
        /// <param name="dataPath">Path to the base directory that holds the data to be read</param>
        /// <param name="fileCreationPath">Path of the file to be created</param>
        public static Sah CreateFromDirectory(string dataPath, string fileCreationPath)
        {
            _path = dataPath;

            _safWriter = new BinaryWriter(File.OpenWrite(fileCreationPath));

            var rootFolder = new ShaiyaFolder(null)
            {
                RelativePath = string.Empty
            };

            ReadDirectoryFolder(rootFolder, dataPath);

            // Create sah instance
            var sah = new Sah(dataPath, rootFolder, _fileCount);

            _safWriter.Dispose();

            return sah;
        }

        public static void ReadDirectoryFolder(ShaiyaFolder folder, string path)
        {
            ReadDirectoryFiles(folder, path);

            var subfolders = Directory.GetDirectories(path).Select(sf => new DirectoryInfo(sf).Name);

            foreach (var subfolder in subfolders)
            {
                var shaiyaFolder = new ShaiyaFolder(folder)
                {
                    Name = subfolder,
                    RelativePath = Path.Combine(folder.RelativePath, subfolder)
                };

                folder.Subfolders?.Add(shaiyaFolder);

                ReadDirectoryFolder(shaiyaFolder, Path.Combine(path, subfolder));
            }
        }

        /// <summary>
        /// Reads the files inside a directory and adds them to a ShaiyaFolder instance
        /// </summary>
        /// <param name="folder">The shaiya folder instance</param>
        /// <param name="path">Directory path</param>
        public static void ReadDirectoryFiles(ShaiyaFolder folder, string path)
        {
            // Read all files in directory
            var files = Directory.GetFiles(path).Select(Path.GetFileName);

            foreach (var file in files)
            {
                var filePath = Path.Combine(path, file);

                var fileStream = File.OpenRead(filePath);

                var shaiyaFile = new ShaiyaFile(folder)
                {
                    Name = file,
                    Length = (int)fileStream.Length,
                    RelativePath = Path.Combine(folder.RelativePath, file)
                };

                // Write file in saf file
                AppendFile(shaiyaFile);

                folder.Files?.Add(shaiyaFile);

                // Increase file count
                _fileCount++;
            }
        }

        public static void AppendFile(ShaiyaFile file)
        {
            // Write file offset
            file.Offset = _safWriter.BaseStream.Position;

            // Read file bytes
            var fileBytes = File.ReadAllBytes(Path.Combine(_path, file.RelativePath));

            // Store file bytes in saf
            _safWriter.Write(fileBytes);
        }
    }
}
