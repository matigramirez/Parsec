using Parsec.Helpers;

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

            if (!FileHelper.DirectoryExists(inputFolderPath))
                throw new DirectoryNotFoundException();

            // Create output folder
            FileHelper.CreateDirectory(outputFolderPath);

            var outputDirectoryInfo = new DirectoryInfo(outputFolderPath);

            var safPath = Path.Combine(outputFolderPath, $"{outputDirectoryInfo.Name}.saf");
            var sahPath = Path.Combine(outputFolderPath, $"{outputDirectoryInfo.Name}.sah");

            // Create binary writer instance to write saf file
            _safWriter = new BinaryWriter(File.OpenWrite(safPath));

            // Create root folder
            var rootFolder = new SFolder(null);

            // Read data folder
            ReadFolderFromDirectory(rootFolder, inputFolderPath);

            // Create sah instance
            var sah = new Sah(inputFolderPath, rootFolder, _fileCount);

            // Write sah
            sah.Write(sahPath);

            var saf = new Saf(safPath);
            var data = new Data(sah, saf);

            return data;
        }
        finally
        {
            // Cleanup
            _safWriter?.Dispose();
            _safWriter = null;
            _path = "";
            _fileCount = 0;
        }
    }

    /// <summary>
    /// Reads a folder's content and assigns it to a <see cref="SFolder"/> instance
    /// </summary>
    /// <param name="folder">The <see cref="SFolder"/> instance</param>
    /// <param name="directoryPath">Directory path</param>
    private static void ReadFolderFromDirectory(SFolder folder, string directoryPath)
    {
        ReadFilesFromDirectory(folder, directoryPath);

        var subfolders = Directory.GetDirectories(directoryPath).Select(sf => new DirectoryInfo(sf).Name);

        foreach (var subfolder in subfolders)
        {
            var shaiyaFolder = new SFolder(folder) { Name = subfolder, ParentFolder = folder };

            folder.AddSubfolder(shaiyaFolder);

            // Recursively read subfolders
            ReadFolderFromDirectory(shaiyaFolder, Path.Combine(directoryPath, subfolder));
        }
    }

    /// <summary>
    /// Reads the files inside a directory and adds them to a ShaiyaFolder instance
    /// </summary>
    /// <param name="folder">The shaiya folder instance</param>
    /// <param name="directoryPath">Directory path</param>
    private static void ReadFilesFromDirectory(SFolder folder, string directoryPath)
    {
        // Read all files in directory
        var files = Directory.GetFiles(directoryPath).Select(Path.GetFileName);

        foreach (var file in files)
        {
            var filePath = Path.Combine(directoryPath, file);

            var fileStream = File.OpenRead(filePath);

            var shaiyaFile = new SFile(folder)
            {
                Name = file, Length = (int)fileStream.Length
                //RelativePath = Path.Combine(folder.RelativePath, file)
            };

            // Write file in saf file
            WriteFile(shaiyaFile);

            folder.AddFile(shaiyaFile);

            // Increase file count
            _fileCount++;
        }
    }

    /// <summary>
    /// Appends a file at the end of the saf file
    /// </summary>
    /// <param name="file"><see cref="SFile"/> instance to add</param>
    private static void WriteFile(SFile file)
    {
        // Write file offset
        file.Offset = _safWriter.BaseStream.Position;

        // Read file bytes
        var fileBytes = File.ReadAllBytes(Path.Combine(_path, file.RelativePath));

        // Store file bytes in saf
        _safWriter.Write(fileBytes);
    }
}
