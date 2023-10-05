using System.Runtime.Serialization;
using Newtonsoft.Json;
using Parsec.Serialization;

namespace Parsec.Shaiya.Data;

[DataContract]
public sealed class SDirectory
{
    [JsonConstructor]
    public SDirectory()
    {
    }

    public SDirectory(SDirectory parentDirectory)
    {
        ParentDirectory = parentDirectory;
    }

    public SDirectory(
        SBinaryReader binaryReader,
        SDirectory? parentDirectory,
        Dictionary<string, SDirectory> directoryIndex,
        Dictionary<string, SFile> fileIndex
    )
    {
        ParentDirectory = parentDirectory;
        Name = binaryReader.ReadString();

        // Make root folder's name empty and store its real name, this is done to avoid confusion when retrieving files and folders
        // from episodes where the root folder's name isn't empty ("data" in episode 8)
        if (parentDirectory == null)
        {
            RealName = Name;
            Name = string.Empty;
        }

        directoryIndex.Add(RelativePath, this);

        var fileCount = binaryReader.ReadInt32();
        for (var i = 0; i < fileCount; i++)
        {
            var file = new SFile(binaryReader, this, fileIndex);
            AddFile(file);
        }

        var subfolderCount = binaryReader.ReadInt32();

        // Recursively read subfolder data
        for (var i = 0; i < subfolderCount; i++)
        {
            var subfolder = new SDirectory(binaryReader, this, directoryIndex, fileIndex);
            AddDirectory(subfolder);
        }
    }

    public SDirectory(string name, SDirectory parentDirectory) : this(parentDirectory)
    {
        Name = name;
    }

    /// <summary>
    /// The folder's name
    /// </summary>
    [DataMember]
    public string Name { get; set; } = string.Empty;

    public string RealName { get; set; } = string.Empty;

    /// <summary>
    /// The relative path to the folder
    /// </summary>
    public string RelativePath => ParentDirectory == null || string.IsNullOrEmpty(ParentDirectory.Name)
        ? Name
        : Path.Combine(ParentDirectory.RelativePath, Name);

    /// <summary>
    /// List of files the folder has
    /// </summary>
    [DataMember]
    public List<SFile> Files { get; } = new();

    /// <summary>
    /// List of subfolders the file has
    /// </summary>
    [DataMember]
    public List<SDirectory> Directories { get; } = new();

    /// <summary>
    /// The folder's parent directory
    /// </summary>
    public SDirectory? ParentDirectory { get; set; }

    public void Write(SBinaryWriter binaryWriter)
    {
        if (ParentDirectory == null)
        {
            binaryWriter.Write(RealName);
        }
        else
        {
            binaryWriter.Write(Name);
        }

        binaryWriter.Write(Files.Count);
        foreach (var file in Files)
        {
            file.Write(binaryWriter);
        }

        binaryWriter.Write(Directories.Count);
        foreach (var directory in Directories)
        {
            directory.Write(binaryWriter);
        }
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
    /// Adds a <see cref="SDirectory"/> child to this directory
    /// </summary>
    /// <param name="childDirectory">The subdirectory instance</param>
    /// <exception cref="Exception">When subdirectory with the same name already existed</exception>
    public void AddDirectory(SDirectory childDirectory)
    {
        if (HasSubfolder(childDirectory.Name))
            throw new Exception($"Subdirectory {childDirectory.Name} already exists in directory {Name}");

        Directories.Add(childDirectory);
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
    public bool HasSubfolder(string name) => Directories.Any(sf => sf.Name == name);

    /// <summary>
    /// Gets a folder's file
    /// </summary>
    /// <param name="name">File name</param>
    public SFile? GetFile(string name) => Files.FirstOrDefault(f => f.Name == name);

    /// <summary>
    /// Gets a folder's subfolder
    /// </summary>
    /// <param name="name">Subfolder name</param>
    public SDirectory? GetSubfolder(string name) => Directories.FirstOrDefault(sf => sf.Name == name);
}
