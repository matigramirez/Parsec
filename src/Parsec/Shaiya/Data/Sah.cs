using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Helpers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Data
{
    [DataContract]
    public class Sah : FileBase, IJsonReadable
    {
        /// <summary>
        /// Path to the saf file
        /// </summary>
        public string SafPath => string.Concat(Path.Substring(0, Path.Length - 3), "saf");

        /// <summary>
        /// Total amount of files that are present in the data; does not include directories.
        /// </summary>
        [DataMember]
        public int FileCount { get; private set; }

        /// <summary>
        /// The data's root directory.
        /// </summary>
        [DataMember]
        public SFolder RootFolder { get; private set; }

        /// <summary>
        /// Dictionary of folders that can be accessed by path
        /// </summary>
        public Dictionary<string, SFolder> FolderIndex = new();

        /// <summary>
        /// Dictionary of files that can be accessed by path
        /// </summary>
        public Dictionary<string, SFile> FileIndex = new();

        public Sah()
        {
        }

        /// <summary>
        /// Constructor used when creating a sah file from a directory
        /// </summary>
        /// <param name="path">Path where sah file will be saved</param>
        /// <param name="rootFolder">Shaiya main Folder containing all the sah's data</param>
        /// <param name="fileCount"></param>
        public Sah(string path, SFolder rootFolder, int fileCount)
        {
            Path = path;
            RootFolder = rootFolder;
            FileCount = fileCount;
        }

        [JsonIgnore]
        public override string Extension => "sah";

        public override void Read(params object[] options)
        {
            // Skip signature (3) and unknown bytes (4)
            _binaryReader.Skip(7);

            // Read total file count
            FileCount = _binaryReader.Read<int>();

            // Index where data starts (after header - skip padding bytes)
            _binaryReader.SetOffset(51);

            // Read root folder and all of its subfolders
            RootFolder = new SFolder(_binaryReader, null, FolderIndex, FileIndex);
        }

        /// <summary>
        /// Adds a folder to the sah file
        /// </summary>
        /// <param name="path">Folder's path</param>
        public SFolder AddFolder(string path) => EnsureFolderExists(path);

        /// <summary>
        /// Adds a file to the sah file
        /// </summary>
        /// <param name="directoryPath">Directory where file must be added. MUST NOT INCLUDE FILE NAME.</param>
        /// <param name="file">File to add</param>
        public void AddFile(string directoryPath, SFile file)
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
        public SFolder EnsureFolderExists(string path)
        {
            // Check if folder is part of the folder index
            if (FolderIndex.TryGetValue(path, out var matchingFolder))
                return matchingFolder;

            // Split path with the '/' separator
            var pathFolders = path.Separate().ToList();

            // Set current folder to root folder
            var currentFolder = RootFolder;

            //  Iterate recursively through subfolders creating the missing one/
            foreach (string folderName in pathFolders)
                if (!currentFolder.HasSubfolder(folderName))
                {
                    // Create new folder if it doesn't exist
                    var newFolder = new SFolder(folderName, currentFolder);

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

            return currentFolder;
        }

        public override void Write(string path, params object[] options)
        {
            // Create byte list which will have the sah's data
            var buffer = new List<byte>();

            // Write sah signature
            buffer.AddRange(Encoding.ASCII.GetBytes("SAH"));

            // Write 4 unknown 0x00 bytes
            buffer.AddRange(new byte[4]);

            // Write total file count
            buffer.AddRange(BitConverter.GetBytes(FileCount));

            // Write padding
            buffer.AddRange(new byte[40]);

            // Write root folder and all subfolders with files
            buffer.AddRange(RootFolder.GetBytes());

            // Write last 8 empty bytes
            buffer.AddRange(new byte[8]);

            // Create new file and write buffer
            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
