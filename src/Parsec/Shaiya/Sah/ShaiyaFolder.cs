using System.Collections.Generic;
using System.Linq;

namespace Parsec.Shaiya
{
    public class ShaiyaFolder
    {
        /// <summary>
        /// The folder's name
        /// </summary>
        public string Name;

        /// <summary>
        /// The relative path to the folder
        /// </summary>
        public string RelativePath;

        /// <summary>
        /// List of files the folder has
        /// </summary>
        public List<ShaiyaFile> Files = new();

        /// <summary>
        /// List of subfolders the file has
        /// </summary>
        public List<ShaiyaFolder> Subfolders = new();

        /// <summary>
        /// The folder's parent directory
        /// </summary>
        public ShaiyaFolder ParentFolder;

        public ShaiyaFolder(ShaiyaFolder parentFolder)
        {
            ParentFolder = parentFolder;
        }

        public ShaiyaFolder(string name, ShaiyaFolder parentFolder) : this(parentFolder)
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
        public ShaiyaFile GetFile(string name) => Files.FirstOrDefault(f => f.Name == name);

        /// <summary>
        /// Gets a folder's subfolder
        /// </summary>
        /// <param name="name">Subfolder name</param>
        public ShaiyaFolder GetSubfolder(string name) => Subfolders.FirstOrDefault(sf => sf.Name == name);
    }
}
