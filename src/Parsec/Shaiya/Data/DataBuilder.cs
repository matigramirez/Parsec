namespace Parsec.Shaiya.Data;

public static class DataBuilder
{
    /// <summary>
    /// The path to the data directory (both data.sah and data.saf)
    /// </summary>
    private static string _path;

    /// <summary>
    /// The binary write instance for the saf file
    /// </summary>
    private static BinaryWriter _safWriter;

    /// <summary>
    /// The total file count
    /// </summary>
    private static int _fileCount;

    /// <summary>
    /// Creates both sah and saf files based on the data inside a directory
    /// </summary>
    /// <param name="inputFolderPath">Path to the base directory that holds the data to be read</param>
    /// <param name="outputFolderPath">Path of the file to be created</param>
    public static Data CreateFromDirectory(string inputFolderPath, string outputFolderPath)
    {
        try
        {
            _path = inputFolderPath;

            Directory.CreateDirectory(outputFolderPath);
            var outputDirectoryInfo = new DirectoryInfo(outputFolderPath);

            var safPath = Path.Combine(outputFolderPath, $"{outputDirectoryInfo.Name}.saf");
            var sahPath = Path.Combine(outputFolderPath, $"{outputDirectoryInfo.Name}.sah");

            _safWriter = new BinaryWriter(File.OpenWrite(safPath));

            var rootFolder = new SDirectory(null);
            ReadFolderFromDirectory(rootFolder, inputFolderPath);

            var sah = new Sah(inputFolderPath, rootFolder, _fileCount);
            sah.Write(sahPath);

            var saf = new Saf(safPath);
            var data = new Data(sah, saf);

            return data;
        }
        finally
        {
            _safWriter?.Dispose();
            _safWriter = null;
            _path = "";
            _fileCount = 0;
        }
    }

    /// <summary>
    /// Reads a folder's content and assigns it to a <see cref="SDirectory"/> instance
    /// </summary>
    /// <param name="directory">The <see cref="SDirectory"/> instance</param>
    /// <param name="directoryPath">Directory path</param>
    private static void ReadFolderFromDirectory(SDirectory directory, string directoryPath)
    {
        ReadFilesFromDirectory(directory, directoryPath);
        var subfolders = Directory.GetDirectories(directoryPath).Select(sf => new DirectoryInfo(sf).Name);

        foreach (var subfolder in subfolders)
        {
            var shaiyaFolder = new SDirectory(directory) { Name = subfolder, ParentDirectory = directory };
            directory.AddDirectory(shaiyaFolder);
            ReadFolderFromDirectory(shaiyaFolder, Path.Combine(directoryPath, subfolder));
        }
    }

    /// <summary>
    /// Reads the files inside a directory and adds them to a ShaiyaFolder instance
    /// </summary>
    /// <param name="directory">The shaiya folder instance</param>
    /// <param name="directoryPath">Directory path</param>
    private static void ReadFilesFromDirectory(SDirectory directory, string directoryPath)
    {
        var files = Directory.GetFiles(directoryPath).Select(Path.GetFileName);

        foreach (var file in files)
        {
            var filePath = Path.Combine(directoryPath, file);

            var fileStream = File.OpenRead(filePath);

            var shaiyaFile = new SFile(directory) { Name = file, Length = (int)fileStream.Length };

            WriteFile(shaiyaFile);
            directory.AddFile(shaiyaFile);

            _fileCount++;
        }
    }

    /// <summary>
    /// Appends a file at the end of the saf file
    /// </summary>
    /// <param name="file"><see cref="SFile"/> instance to add</param>
    private static void WriteFile(SFile file)
    {
        file.Offset = _safWriter.BaseStream.Position;

        var fileBytes = File.ReadAllBytes(Path.Combine(_path, file.RelativePath));
        _safWriter.Write(fileBytes);
    }
}
