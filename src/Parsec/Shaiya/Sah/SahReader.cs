using Parsec.Readers;

namespace Parsec.Shaiya
{
    public partial class Sah
    {
        private ShaiyaBinaryReader _binaryReader;

        /// <summary>
        /// Checks if the first 3 bytes in the file match the "SAH" magic number or the provided one
        /// </summary>
        /// <param name="magicNumber">Magic number to check. See <see cref="https://en.wikipedia.org/wiki/Magic_number_(programming)"/></param>
        public bool CheckMagicNumber(string magicNumber = "SAH")
        {
            var sahMagicNumber = _binaryReader.ReadString(3);
            return sahMagicNumber == magicNumber;
        }

        /// <summary>
        /// Loads the sah file and reads all its folders and subfolders
        /// </summary>
        public void Load()
        {
            _binaryReader = new ShaiyaBinaryReader(Path);

            // Skip signature (3) and unknown bytes (4)
            _binaryReader.SetPosition(7);

            // Read total file count
            TotalFileCount = _binaryReader.Read<int>();

            // Index where data starts (after header - skip padding bytes)
            _binaryReader.SetPosition(51);

            // Read root folder and all of its subfolders
            RootFolder = ReadFolder(null);

            IsLoaded = true;
        }

        /// <summary>
        /// Reads a sah folder definition including its files and subfolders
        /// </summary>
        /// <param name="parentFolder">Parent folder</param>
        private ShaiyaFolder ReadFolder(ShaiyaFolder parentFolder)
        {
            var currentFolder = new ShaiyaFolder(parentFolder);

            #region Read Folder's information

            currentFolder.Name = _binaryReader.ReadString();

            // Write folder's relative path based on parent folder
            currentFolder.RelativePath = parentFolder == null ? currentFolder.Name : System.IO.Path.Combine(parentFolder.RelativePath, currentFolder.Name);

            #endregion

            #region Read files

            int fileCount = _binaryReader.Read<int>();

            // NOTE: An if statement checking if folderFileCount > 0 is not necessary but it wouldn't be wrong to add it either
            // Read all files in this folder
            for (int i = 0; i < fileCount; i++)
            {
                ReadFile(currentFolder);
            }

            #endregion

            #region Read subfolders

            int subfolderCount = _binaryReader.Read<int>();

            // NOTE: An if statement checking if subfolderCount > 0 is not necessary but it wouldn't be wrong to add it either
            // Recursively read subfolders data
            for (int i = 0; i < subfolderCount; i++)
                currentFolder.Subfolders.Add(ReadFolder(currentFolder));

            #endregion

            // Add folder to the sah's folder dictionary
            FolderIndex.Add(currentFolder.RelativePath, currentFolder);

            return currentFolder;
        }

        /// <summary>
        /// Reads a sah file definition
        /// </summary>
        /// <param name="folder">Folder in which the file is</param>
        private ShaiyaFile ReadFile(ShaiyaFolder folder)
        {
            var file = new ShaiyaFile(folder);

            // Read file name
            file.Name = _binaryReader.ReadString();

            // Read file offset
            file.Offset = _binaryReader.Read<long>();

            // Read file length
            file.Length = _binaryReader.Read<int>();

            // Read file version
            file.Version = _binaryReader.Read<int>();

            // Write folder's relative path based on parent folder
            file.RelativePath = file.ParentFolder == null ? file.Name : System.IO.Path.Combine(file.ParentFolder.RelativePath, file.Name);

            // Add file to folder's file list
            folder?.Files.Add(file);

            // Add file to the sah's file dictionary
            if (!FileIndex.ContainsKey(file.RelativePath))
            {
                FileIndex.Add(file.RelativePath, file);
            }
            else
            {
                // Follow castor's _pv file name ending for duplicate files
                FileIndex.Add(file.RelativePath + "_pv", file);
            }

            return file;
        }
    }
}
