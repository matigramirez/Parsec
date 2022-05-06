using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Data
{
    [DataContract]
    public class SFolder : IBinary
    {
        /// <summary>
        /// The folder's name
        /// </summary>
        [DataMember]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The relative path to the folder
        /// </summary>
        public string RelativePath => ParentFolder == null || string.IsNullOrEmpty(ParentFolder.Name)
            ? Name
            : string.Join("/", ParentFolder.RelativePath, Name);

        /// <summary>
        /// List of files the folder has
        /// </summary>
        [DataMember]
        public List<SFile> Files { get; } = new();

        /// <summary>
        /// List of subfolders the file has
        /// </summary>
        [DataMember]
        public List<SFolder> Subfolders { get; } = new();

        /// <summary>
        /// The folder's parent directory
        /// </summary>
        public SFolder ParentFolder { get; set; }

        [JsonConstructor]
        public SFolder()
        {
        }

        public SFolder(SFolder parentFolder)
        {
            ParentFolder = parentFolder;
        }

        public SFolder(
            SBinaryReader binaryReader,
            SFolder parentFolder,
            Dictionary<string, SFolder> folderIndex,
            Dictionary<string, SFile> fileIndex
        )
        {
            ParentFolder = parentFolder;
            
            Name = binaryReader.ReadString();

            folderIndex.Add(RelativePath, this);

            var fileCount = binaryReader.Read<int>();

            // Read all files in this folder
            for (int i = 0; i < fileCount; i++)
            {
                var file = new SFile(binaryReader, this, fileIndex);
                AddFile(file);
            }

            var subfolderCount = binaryReader.Read<int>();

            // Recursively read subfolders data
            for (int i = 0; i < subfolderCount; i++)
            {
                var subfolder = new SFolder(binaryReader, this, folderIndex, fileIndex);
                AddSubfolder(subfolder);
            }
        }

        public SFolder(string name, SFolder parentFolder) : this(parentFolder)
        {
            Name = name;
        }

        /// <summary>
        /// Adds a <see cref="SFile"/> child to this folder
        /// </summary>
        /// <param name="file">The file instance</param>
        /// <exception cref="Exception">When file with the same name already existed</exception>
        public void AddFile(SFile file)
        {
            if (HasFile(file.Name))
                throw new Exception($"File {file.Name} already exists in folder {Name}");

            Files.Add(file);
        }

        /// <summary>
        /// Adds a <see cref="SFolder"/> child to this folder
        /// </summary>
        /// <param name="subfolder">The subfolder instance</param>
        /// <exception cref="Exception">When subfolder with the same name already existed</exception>
        public void AddSubfolder(SFolder subfolder)
        {
            if (HasSubfolder(subfolder.Name))
                throw new Exception($"Folder {subfolder.Name} already exists in {Name}");

            Subfolders.Add(subfolder);
        }

        /// <summary>
        /// Checks if a folder contains a file with a specified name
        /// </summary>
        /// <param name="name">File name to check</param>
        public bool HasFile(string name) => Files.Any(f => f.Name == name);

        /// <summary>
        /// Checks if a folder contains a subfolder with a specified name
        /// </summary>
        /// <param name="name">Subfolder name to check</param>
        public bool HasSubfolder(string name) => Subfolders.Any(sf => sf.Name == name);

        /// <summary>
        /// Gets a folder's file
        /// </summary>
        /// <param name="name">File name</param>
        public SFile GetFile(string name) => Files.FirstOrDefault(f => f.Name == name);

        /// <summary>
        /// Gets a folder's subfolder
        /// </summary>
        /// <param name="name">Subfolder name</param>
        public SFolder GetSubfolder(string name) => Subfolders.FirstOrDefault(sf => sf.Name == name);

        /// <inheritdoc />
        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Name.GetLengthPrefixedBytes());
            buffer.AddRange(Files.GetBytes());
            buffer.AddRange(Subfolders.GetBytes());
            return buffer.ToArray();
        }
    }
}
