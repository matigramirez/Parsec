using System.Runtime.Serialization;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Data;

[DataContract]
public sealed class Sah : FileBase
{
    /// <summary>
    /// Dictionary of files that can be accessed by path
    /// </summary>
    public Dictionary<string, SFile> FileIndex = new(StringComparer.InvariantCultureIgnoreCase);

    /// <summary>
    /// Dictionary of folders that can be accessed by path
    /// </summary>
    public Dictionary<string, SDirectory> DirectoryIndex = new(StringComparer.InvariantCultureIgnoreCase);

    [JsonConstructor]
    public Sah()
    {
    }

    /// <summary>
    /// Constructor used when creating a sah file from a directory
    /// </summary>
    /// <param name="path">Path where sah file will be saved</param>
    /// <param name="rootDirectory">Shaiya main Folder containing all the sah's data</param>
    /// <param name="fileCount"></param>
    public Sah(string path, SDirectory rootDirectory, int fileCount)
    {
        Path = path;
        RootDirectory = rootDirectory;
        FileCount = fileCount;
    }

    /// <summary>
    /// SAH signature, normally "SAH" but it can be changed. Read as char[3].
    /// </summary>
    public string Signature { get; set; } = "SAH";

    /// <summary>
    /// 4 bytes after signature. Meaning isn't truly known but it's suspected that's used for versioning.
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// Total amount of files that are present in the data; does not include directories.
    /// </summary>
    [DataMember]
    public int FileCount { get; set; }

    /// <summary>
    /// The data's root directory.
    /// </summary>
    [DataMember]
    public SDirectory RootDirectory { get; set; }

    [JsonIgnore]
    public override string Extension => "sah";

    /// <inheritdoc />
    protected override void Read(SBinaryReader binaryReader)
    {
        Signature = binaryReader.ReadString(3);
        Version = binaryReader.ReadInt32();
        FileCount = binaryReader.ReadInt32();

        // Index where data starts (after header - skip padding bytes)
        binaryReader.Skip(40);

        RootDirectory = new SDirectory(binaryReader, null, DirectoryIndex, FileIndex);
    }

    /// <summary>
    /// Adds a folder to the sah file
    /// </summary>
    /// <param name="path">Folder's path</param>
    public SDirectory AddFolder(string path) => EnsureFolderExists(path);

    /// <summary>
    /// Adds a file to the sah file
    /// </summary>
    /// <param name="directoryPath">Directory where file must be added. MUST NOT INCLUDE FILE NAME.</param>
    /// <param name="file">File to add</param>
    public void AddFile(string directoryPath, SFile file)
    {
        var parentFolder = AddFolder(directoryPath);
        file.ParentDirectory = parentFolder;

        parentFolder.AddFile(file);
        FileIndex.Add(file.RelativePath, file);
    }

    /// <summary>
    /// Checks if a folder exists based on its path. If it doesn't exist, it will be created
    /// </summary>
    /// <param name="path">Folder path</param>
    public SDirectory EnsureFolderExists(string path)
    {
        if (DirectoryIndex.TryGetValue(path, out var matchingFolder))
            return matchingFolder;

        var pathFolders = path.Separate().ToList();
        var currentFolder = RootDirectory;

        foreach (var folderName in pathFolders)
        {
            if (!currentFolder.HasSubfolder(folderName))
            {
                var newFolder = new SDirectory(folderName, currentFolder);
                currentFolder.AddDirectory(newFolder);

                DirectoryIndex.Add(newFolder.RelativePath, newFolder);
                currentFolder = newFolder;
            }
            else
            {
                currentFolder = currentFolder.GetSubfolder(folderName);
            }
        }

        return currentFolder;
    }

    /// <summary>
    /// Checks if the sah has a folder with the given path
    /// </summary>
    /// <param name="relativePath">Folder's relative path (ie. "Character/Human")</param>
    public bool HasFolder(string relativePath) => DirectoryIndex.ContainsKey(relativePath);

    /// <summary>
    /// Checks if the sah has a file with the given path
    /// </summary>
    /// <param name="relativePath">File's relative path (ie. "Character/Human/3DC/model.3DC")</param>
    public bool HasFile(string relativePath) => FileIndex.ContainsKey(relativePath);

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Signature.Take(3).ToString());
        binaryWriter.Write(Version);
        binaryWriter.Write(FileCount);
        binaryWriter.Write(new byte[40]); // Padding

        RootDirectory.Write(binaryWriter);

        // Suffix with 8 empty bytes - I don't think the game cares about these at all, but some other tools do
        binaryWriter.Write(new byte[8]);
    }
}
