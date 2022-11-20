using System.Runtime.Serialization;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Cryptography;
using Parsec.Extensions;
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
    public Dictionary<string, SFolder> FolderIndex = new(StringComparer.InvariantCultureIgnoreCase);

    [JsonConstructor]
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

    /// <summary>
    /// SAH signature, normally "SAH" but it can be changed. Read as char[3].
    /// </summary>
    public string Signature { get; set; } = "SAH";

    /// <summary>
    /// 4 bytes after signature. Meaning isn't truly known but it's suspected that's used for versioning.
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// Path to the saf file linked to this sah
    /// </summary>
    public string SafPath => string.Concat(Path.Substring(0, Path.Length - 3), "saf");

    /// <summary>
    /// Total amount of files that are present in the data; does not include directories.
    /// </summary>
    [DataMember]
    public int FileCount { get; set; }

    /// <summary>
    /// The data's root directory.
    /// </summary>
    [DataMember]
    public SFolder RootFolder { get; set; }

    /// <summary>
    /// Defines how file and folder counts should be encrypted/decrypted.
    /// </summary>
    public SahCrypto Crypto { get; set; }

    public void ResetEncryption() => Crypto = null;

    [JsonIgnore]
    public override string Extension => "sah";

    /// <inheritdoc />
    public override void Read(params object[] options)
    {
        if (options.Length > 0)
            Crypto = (SahCrypto)options[0];

        Signature = _binaryReader.ReadString(3);
        Version = _binaryReader.Read<int>();
        FileCount = _binaryReader.Read<int>();

        // Index where data starts (after header - skip padding bytes)
        _binaryReader.Skip(40);

        // Read root folder and all of its subfolders
        RootFolder = new SFolder(_binaryReader, null, FolderIndex, FileIndex, Crypto);
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
        var parentFolder = AddFolder(directoryPath);

        // Assign parent folder to file
        file.ParentFolder = parentFolder;

        // Add file to file list and file index
        parentFolder.AddFile(file);
        FileIndex.Add(file.RelativePath, file);
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

                // Add new folder to current folder's subfolders
                currentFolder.AddSubfolder(newFolder);

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

    /// <summary>
    /// Checks if the sah has a folder with the given path
    /// </summary>
    /// <param name="relativePath">Folder's relative path (ie. "Character/Human")</param>
    public bool HasFolder(string relativePath) => FolderIndex.ContainsKey(relativePath);

    /// <summary>
    /// Checks if the sah has a file with the given path
    /// </summary>
    /// <param name="relativePath">File's relative path (ie. "Character/Human/3DC/model.3DC")</param>
    public bool HasFile(string relativePath) => FileIndex.ContainsKey(relativePath);

    /// <inheritdoc />
    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        // Create byte list which will have the sah's data
        var buffer = new List<byte>();
        buffer.AddRange(Signature.GetBytes());
        buffer.AddRange(Version.GetBytes());
        buffer.AddRange(FileCount.GetBytes());
        // Write padding
        buffer.AddRange(new byte[40]);
        buffer.AddRange(RootFolder.GetBytes(Crypto));
        // Write last 8 empty bytes
        buffer.AddRange(new byte[8]);
        return buffer;
    }
}
