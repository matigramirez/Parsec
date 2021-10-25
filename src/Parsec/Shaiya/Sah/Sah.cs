using System.Collections.Generic;
using Parsec.Extensions;

namespace Parsec.Shaiya
{
    public partial class Sah
    {
        /// <summary>
        /// Path to the sah file.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Path to the saf file
        /// </summary>
        public string SafPath => string.Concat(Path.Substring(0, Path.Length - 3), "saf");

        /// <summary>
        /// Total amount of files that are present in the data; does not include directories.
        /// </summary>
        public int TotalFileCount { get; private set; }

        /// <summary>
        /// The data's root directory.
        /// </summary>
        public ShaiyaFolder RootFolder { get; private set; }

        /// <summary>
        /// Indicates whether the sah's content has been loaded or not
        /// </summary>
        public bool IsLoaded { get; private set; }

        /// <summary>
        /// Dictionary of folders that can be accessed by path
        /// </summary>
        public Dictionary<string, ShaiyaFolder> FolderIndex = new();

        /// <summary>
        /// Dictionary of files that can be accessed by path
        /// </summary>
        public Dictionary<string, ShaiyaFile> FileIndex = new();

        public Sah(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Constructor used when creating a sah file from a directory
        /// </summary>
        /// <param name="path">Path where sah file will be saved</param>
        /// <param name="rootFolder">Shaiya main Folder containing all the sah's data</param>
        /// <param name="fileCount"></param>
        public Sah(string path, ShaiyaFolder rootFolder, int fileCount) : this(path)
        {
            RootFolder = rootFolder;
            IsLoaded = true;
            TotalFileCount = fileCount;
        }

        /// <summary>
        /// Adds a folder to the sah file
        /// </summary>
        /// <param name="path">Folder's path</param>
        public ShaiyaFolder AddFolder(string path) => EnsureFolderExists(path);

        /// <summary>
        /// Adds a file to the sah file
        /// </summary>
        /// <param name="directoryPath">Directory where file must be added. MUST NOT INCLUDE FILE NAME.</param>
        /// <param name="file">File to add</param>
        public void AddFile(string directoryPath, ShaiyaFile file)
        {
            // Ensure directory exists
            var parentFolder = EnsureFolderExists(directoryPath);

            // Assign parent folder to file
            file.ParentFolder = parentFolder;

            // Add file to file list
            parentFolder.Files.Add(file);
        }

        /// <summary>
        /// Checks if a folder exists based on its path. If it doesn't exist, it will be created
        /// </summary>
        /// <param name="path">Folder path</param>
        public ShaiyaFolder EnsureFolderExists(string path)
        {
            // Check if folder is part of the folder index
            if (FolderIndex.TryGetValue(path, out var matchingFolder))
                return matchingFolder;

            // Split path with the '/' separator
            var pathFolders = path.Separate();

            // Set current folder to root folder
            var currentFolder = RootFolder;

            //  Iterate recursively through subfolders creating the missing one/
            foreach (string folderName in pathFolders)
            {
                if (!currentFolder.HasSubfolder(folderName))
                {
                    // Create new folder if it doesn't exist
                    var newFolder = new ShaiyaFolder(folderName, currentFolder);

                    // Create relative path
                    newFolder.RelativePath = System.IO.Path.Combine(currentFolder.RelativePath, newFolder.Name);

                    // Add new folder to current folder's subfolders
                    currentFolder.Subfolders.Add(newFolder);

                    // Add folder to folder index
                    FolderIndex.Add(newFolder.RelativePath, newFolder);

                    currentFolder = newFolder;
                }
                else
                {
                    // Get subfolder with path name
                    currentFolder = currentFolder.GetSubfolder(folderName);
                }
            }

            return currentFolder;
        }
    }
}
