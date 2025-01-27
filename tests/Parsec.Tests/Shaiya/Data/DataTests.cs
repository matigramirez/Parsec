using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Parsec.Shaiya.Data;
using Xunit.Sdk;

namespace Parsec.Tests.Shaiya.Data;

public class DataTests
{
    [Fact]
    [Description("Tests building both data.sah and data.saf from a directory")]
    public void DataBuildingTest()
    {
        DataBuilder.CreateFromDirectory("Shaiya/Data/sample_data", "Shaiya/Data/output_data");
        Assert.True(File.Exists("Shaiya/Data/output_data/output_data.sah"));
        Assert.True(File.Exists("Shaiya/Data/output_data/output_data.saf"));
    }

    [Fact]
    [Description("Tests extracting a data file fully")]
    public void DataExtractionTest()
    {
        var data = new Parsec.Shaiya.Data.Data("Shaiya/Data/sample.sah", "Shaiya/Data/sample.saf");
        data.ExtractAll("Shaiya/Data/extracted");

        foreach (var file in data.FileIndex.Values)
            Assert.True(File.Exists($"Shaiya/Data/extracted/{file.RelativePath}"));
    }

    [Fact]
    [Description("Tests extracting a single folder from a data file")]
    public void DataFolderExtractionTest()
    {
        var data = new Parsec.Shaiya.Data.Data("Shaiya/Data/sample.sah", "Shaiya/Data/sample.saf");
        const string extractionDirectory = "Shaiya/Data/single_folder_extraction";

        var folder1 = data.RootDirectory.Directories.FirstOrDefault();
        var folder2 = data.RootDirectory.Directories.LastOrDefault();

        if (folder1 == null || folder2 == null)
            throw new XunitException("Folder not found in RootFolder");

        data.Extract(folder1, extractionDirectory);
        Assert.True(Directory.Exists($"{extractionDirectory}/{folder1.Name}"));

        foreach (var file in folder1.Files)
            Assert.True(File.Exists($"{extractionDirectory}/{file.RelativePath}"));

        data.Extract(folder2, extractionDirectory);

        Assert.True(Directory.Exists($"{extractionDirectory}/{folder1.Name}"));

        foreach (var file in folder1.Files)
            Assert.True(File.Exists($"{extractionDirectory}/{file.RelativePath}"));
    }

    [Fact]
    [Description("Tests extracting a single file from a data file")]
    public void DataFileExtractionTest()
    {
        var data = new Parsec.Shaiya.Data.Data("Shaiya/Data/sample.sah", "Shaiya/Data/sample.saf");
        const string extractionDirectory = "Shaiya/Data/single_file_extraction";

        var file1 = data.FileIndex.Values.FirstOrDefault();
        var file2 = data.FileIndex.Values.LastOrDefault();

        if (file1 == null || file2 == null)
            throw new XunitException("File not found in FileIndex");

        Directory.CreateDirectory(extractionDirectory);

        data.Extract(file1, extractionDirectory);
        Assert.True(File.Exists($"{extractionDirectory}/{file1.Name}"));

        data.Extract(file2, extractionDirectory);
        Assert.True(File.Exists($"{extractionDirectory}/{file2.Name}"));
    }

    [Fact]
    [Description("Tests applying multiple patches to a data file")]
    public void DataPatchingTest()
    {
        // Load data
        var data = new Parsec.Shaiya.Data.Data("Shaiya/Data/target.sah", "Shaiya/Data/sample.saf");
        var initialFiles = data.FileIndex.Keys.ToList();

        // Load patches
        var patch = new Parsec.Shaiya.Data.Data("Shaiya/Data/patch.sah", "Shaiya/Data/patch.saf");
        var patch2 = new Parsec.Shaiya.Data.Data("Shaiya/Data/patch2.sah", "Shaiya/Data/patch2.saf");

        var patchFiles = patch.FileIndex.Keys.Concat(patch2.FileIndex.Keys).ToList();

        int patchedFileCount = 0;
        var callback = new Action(() => { patchedFileCount++; });

        // Apply patches
        using var dataPatcher = new DataPatcher();
        dataPatcher.Patch(data, patch, callback);
        dataPatcher.Patch(data, patch2, callback);

        Assert.Equal(patchFiles.Count, patchedFileCount);

        // Get files that were added to the data and weren't present before
        var newFiles = patchFiles.Except(initialFiles).ToList();

        // Check the data file count
        Assert.Equal(initialFiles.Count + newFiles.Count, data.FileIndex.Count);

        // Check that patch files are present in the data
        foreach (var patchFile in patchFiles)
            Assert.True(data.FileIndex.ContainsKey(patchFile));
    }

    [Fact]
    [Description("Tests deleting files from a delete.lst list")]
    public void DataDeleteListTest()
    {
        var data = new Parsec.Shaiya.Data.Data("Shaiya/Data/delete.sah", "Shaiya/Data/sample.saf");

        var lstPath = "Shaiya/Data/delete.lst";
        data.RemoveFilesFromLst(lstPath);

        var fileList = File.ReadAllLines(lstPath);

        foreach (var fileName in fileList)
            Assert.True(!data.FileIndex.ContainsKey(fileName));
    }
}
