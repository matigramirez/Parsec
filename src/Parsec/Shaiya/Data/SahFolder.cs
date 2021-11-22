using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.DATA
{
    [DataContract]
    public class SahFolder : IBinary
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
        public List<SahFile> Files = new();

        /// <summary>
        /// List of subfolders the file has
        /// </summary>
        [DataMember]
        public List<SahFolder> Subfolders = new();

        /// <summary>
        /// The folder's parent directory
        /// </summary>
        public SahFolder ParentFolder;

        [JsonConstructor]
        public SahFolder()
        {
        }

        public SahFolder(SahFolder parentFolder)
        {
            ParentFolder = parentFolder;
        }

        public SahFolder(ShaiyaBinaryReader binaryReader, SahFolder parentFolder, Dictionary<string, SahFolder> folderIndex, Dictionary<string, SahFile> fileIndex)
        {
            Name = binaryReader.ReadString();

            // Write folder's relative path based on parent folder
            RelativePath = parentFolder == null ? Name : System.IO.Path.Combine(parentFolder.RelativePath, Name);

            folderIndex.Add(RelativePath, this);

            int fileCount = binaryReader.Read<int>();

            // Read all files in this folder
            for (int i = 0; i < fileCount; i++)
            {
                var file = new SahFile(binaryReader, this, fileIndex);
                Files.Add(file);
            }

            int subfolderCount = binaryReader.Read<int>();

            // Recursively read subfolders data
            for (int i = 0; i < subfolderCount; i++)
            {
                var subfolder = new SahFolder(binaryReader, this, folderIndex, fileIndex);
                Subfolders.Add(subfolder);
            }
        }

        public SahFolder(string name, SahFolder parentFolder) : this(parentFolder)
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
        public SahFile GetFile(string name) => Files.FirstOrDefault(f => f.Name == name);

        /// <summary>
        /// Gets a folder's subfolder
        /// </summary>
        /// <param name="name">Subfolder name</param>
        public SahFolder GetSubfolder(string name) => Subfolders.FirstOrDefault(sf => sf.Name == name);

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();

            // Write folder name length + 1 for string null terminator
            int folderNameLength = string.IsNullOrEmpty(Name) ? 1 : Name.Length + 1;
            buffer.AddRange(BitConverter.GetBytes(folderNameLength));

            // Write folder name including string null terminator
            buffer.AddRange(Encoding.ASCII.GetBytes(Name + '\0'));

            // Write file count
            buffer.AddRange(BitConverter.GetBytes(Files.Count));

            // Write files
            foreach (var file in Files)
            {
                buffer.AddRange(file.GetBytes());
            }

            // Write subfolder count
            buffer.AddRange(BitConverter.GetBytes(Subfolders.Count));

            // Recursively write subfolders
            foreach (var subfolder in Subfolders)
            {
                buffer.AddRange(subfolder.GetBytes());
            }

            return buffer.ToArray();
        }
    }
}
