using Parsec.Helpers;

namespace Parsec.Shaiya.Data;

public class Data
{
    public Data(Sah sah, Saf saf)
    {
        Sah = sah;
        Saf = saf;
    }

    public Data(string sahPath, string safPath)
    {
        if (!FileHelper.FileExists(sahPath))
        {
            throw new FileNotFoundException($"data.sah file not found at {sahPath}");
        }

        if (!FileHelper.FileExists(safPath))
        {
            throw new FileNotFoundException($"data.saf file not found at {safPath}");
        }

        Sah = ParsecReader.FromFile<Sah>(sahPath);
        Saf = new Saf(safPath);
    }

    /// <summary>
    /// <see cref="Sah"/> instance for the current data
    /// </summary>
    public Sah Sah { get; set; }

    /// <summary>
    /// <see cref="Saf"/> instance for the current data
    /// </summary>
    public Saf Saf { get; set; }

    /// <summary>
    /// The data's root folder from the sah index
    /// </summary>
    public SDirectory RootDirectory => Sah.RootDirectory;

    /// <summary>
    /// The data's file count
    /// </summary>
    public int FileCount
    {
        get => Sah.FileCount;
        set => Sah.FileCount = value;
    }

    /// <summary>
    /// Dictionary of folders that can be accessed by path
    /// </summary>
    public Dictionary<string, SDirectory> DirectoryIndex => Sah.DirectoryIndex;

    /// <summary>
    /// Dictionary of files that can be accessed by path
    /// </summary>
    public Dictionary<string, SFile> FileIndex => Sah.FileIndex;

    /// <summary>
    /// Gets a data folder from the FolderIndex
    /// </summary>
    /// <param name="path">Folder path</param>
    public SDirectory? GetFolder(string path)
    {
        DirectoryIndex.TryGetValue(path, out var folder);
        return folder;
    }

    /// <summary>
    /// Gets a data file from the FileIndex
    /// </summary>
    /// <param name="path">File path</param>
    public SFile? GetFile(string path)
    {
        FileIndex.TryGetValue(path, out var file);
        return file;
    }

    /// <summary>
    /// Extracts the whole data file
    /// </summary>
    /// <param name="extractionDirectory">Extraction directory path</param>
    public void ExtractAll(string extractionDirectory) => Extract(Sah.RootDirectory, extractionDirectory);

    /// <summary>
    /// Extracts a shaiya folder from the saf file. If the folder to be extracted is the root folder,
    /// then the folder's content gets extracted in the provided extraction directory and if it's not,
    /// a child directory will be created inside the provided extraction directory
    /// </summary>
    /// <param name="directory">The <see cref="SDirectory"/> instance to extract</param>
    /// <param name="extractionDirectory">Extraction directory path</param>
    public void Extract(SDirectory directory, string extractionDirectory)
    {
        string extractionPath = extractionDirectory;

        if (directory != Sah.RootDirectory)
            extractionPath = Path.Combine(extractionDirectory, directory.RelativePath);

        if (!FileHelper.CreateDirectory(extractionPath))
            return;

        foreach (var file in directory.Files)
            Extract(file, extractionPath);

        foreach (var subfolder in directory.Directories)
            Extract(subfolder, extractionDirectory);
    }

    /// <summary>
    /// Extracts a single file into a directory
    /// </summary>
    /// <param name="file">The <see cref="SFile" /> instance to extract</param>
    /// <param name="extractionDirectory">Extraction directory path</param>
    public void Extract(SFile file, string extractionDirectory)
    {
        var fileBytes = Saf.ReadBytes(file.Offset, file.Length);
        FileHelper.WriteFile(Path.Combine(extractionDirectory, file.Name), fileBytes);
    }

    /// <summary>
    /// Reads a file buffer from the saf file
    /// </summary>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <returns>The file buffer</returns>
    public byte[] GetFileBuffer(SFile file) => Saf.ReadBytes(file.Offset, file.Length);

    /// <summary>
    /// Removes a file from both the sah and saf files
    /// </summary>
    /// <param name="path"></param>
    public void RemoveFile(string path)
    {
        if (!FileIndex.TryGetValue(path, out var file))
            return;

        Sah.FileCount--;
        file.ParentDirectory.Files.Remove(file);
        FileIndex.Remove(path);

        Saf.ClearBytes(file.Offset, file.Length);
    }

    /// <summary>
    /// Removes data files from a deletion list (delete.lst)
    /// </summary>
    /// <param name="lstPath">Path to delete.lst file</param>
    public void RemoveFilesFromLst(string lstPath)
    {
        var filePaths = File.ReadAllLines(lstPath);

        foreach (var file in filePaths)
            RemoveFile(file);
    }
}
