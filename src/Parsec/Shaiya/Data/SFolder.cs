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
        public string Name;

        /// <summary>
        /// The relative path to the folder
        /// </summary>
        public string RelativePath;

        /// <summary>
        /// List of files the folder has
        /// </summary>
        [DataMember]
        public List<SFile> Files = new();

        /// <summary>
        /// List of subfolders the file has
        /// </summary>
        [DataMember]
        public List<SFolder> Subfolders = new();

        /// <summary>
        /// The folder's parent directory
        /// </summary>
        public SFolder ParentFolder;

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
            Name = binaryReader.ReadString();

            // Write folder's relative path based on parent folder
            RelativePath = parentFolder == null || parentFolder.Name == ""
                ? Name
                : string.Join("/", parentFolder.RelativePath, Name);

            folderIndex.Add(RelativePath, this);

            var fileCount = binaryReader.Read<int>();

            // Read all files in this folder
            for (int i = 0; i < fileCount; i++)
            {
                var file = new SFile(binaryReader, this, fileIndex);
                Files.Add(file);
            }

            var subfolderCount = binaryReader.Read<int>();

            // Recursively read subfolders data
            for (int i = 0; i < subfolderCount; i++)
            {
                var subfolder = new SFolder(binaryReader, this, folderIndex, fileIndex);
                Subfolders.Add(subfolder);
            }
        }

        public SFolder(string name, SFolder parentFolder) : this(parentFolder)
        {
            Name = name;
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
