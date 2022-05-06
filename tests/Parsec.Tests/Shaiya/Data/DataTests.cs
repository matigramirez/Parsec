using System.IO;
using System.Linq;
using Parsec.Shaiya.Data;
using Xunit;

namespace Parsec.Tests.Shaiya;

public class DataTests
{
    [Fact]
    public void DataReadingTest()
    {
        var dataFromSah = new Data("Shaiya/Data/sample.sah");
        var dataFromSaf = new Data("Shaiya/Data/sample.saf");
        
        Assert.Equal(dataFromSah.FileIndex.Count, dataFromSaf.FileIndex.Count);
        Assert.Equal(dataFromSah.FolderIndex.Count, dataFromSaf.FolderIndex.Count);
    }
    
    [Fact]
    public void DataBuildingTest()
    {
        DataBuilder.CreateFromDirectory("Shaiya/Data/sample_data", "Shaiya/Data/output_data");
        Assert.True(File.Exists("Shaiya/Data/output_data/output_data.sah"));
        Assert.True(File.Exists("Shaiya/Data/output_data/output_data.saf"));

        Assert.Throws<DirectoryNotFoundException>(
            () => DataBuilder.CreateFromDirectory("Shaiya/wrong_folder_path/does_not_exist",
                                                  "Shaiya/Data/output_data/"));
    }

    [Fact]
    public void DataExtractionTest()
    {
        var data = new Data("Shaiya/Data/sample.sah");
        data.ExtractAll("Shaiya/Data/extracted");

        foreach (var file in data.FileIndex.Values)
            Assert.True(File.Exists($"Shaiya/Data/extracted/{file.RelativePath}"));
    }

    [Fact]
    public void DataFolderExtractionTest()
    {
        var data = new Data("Shaiya/Data/sample.sah");
        const string extractionDirectory = "Shaiya/Data/single_folder_extraction";

        var folder1 = data.RootFolder.Subfolders.FirstOrDefault();
        var folder2 = data.RootFolder.Subfolders.LastOrDefault();

        if (folder1 != null)
        {
            data.Extract(folder1, extractionDirectory);
            Assert.True(Directory.Exists($"{extractionDirectory}/{folder1.Name}"));

            foreach (var file in folder1.Files)
                Assert.True(File.Exists($"{extractionDirectory}/{file.RelativePath}"));
        }

        if (folder2 != null)
        {
            data.Extract(folder2, extractionDirectory);

            Assert.True(Directory.Exists($"{extractionDirectory}/{folder1.Name}"));

            foreach (var file in folder1.Files)
                Assert.True(File.Exists($"{extractionDirectory}/{file.RelativePath}"));
        }
    }

    [Fact]
    public void DataFileExtractionTest()
    {
        var data = new Data("Shaiya/Data/sample.sah");
        const string extractionDirectory = "Shaiya/Data/single_file_extraction";

        var file1 = data.FileIndex.Values.FirstOrDefault();
        var file2 = data.FileIndex.Values.LastOrDefault();

        if (file1 != null)
        {
            data.Extract(file1, extractionDirectory);
            Assert.True(File.Exists($"{extractionDirectory}/{file1.Name}"));
        }

        if (file2 != null)
        {
            data.Extract(file2, extractionDirectory);
            Assert.True(File.Exists($"{extractionDirectory}/{file2.Name}"));
        }
    }

    [Fact]
    public void DataPatchingTest()
    {
        // Load data
        var data = new Data("Shaiya/Data/sample.sah");
        var initialFiles = data.FileIndex.Keys.ToList();
        
        // Load patches
        var patch = new Data("Shaiya/Data/patch.sah");
        var patch2 = new Data("Shaiya/Data/patch2.sah");

        var patchFiles = patch.FileIndex.Keys.Concat(patch2.FileIndex.Keys);
        
        // Apply patch
        DataPatcher.Patch(data, patch, patch2);

        // Get files that were added to the data and weren't present before
        var newFiles = patchFiles.Except(initialFiles).ToList();
        
        // Check the data file count
        Assert.Equal(initialFiles.Count + newFiles.Count, data.FileIndex.Count);
        
        // Check that patch files are present in the data
        foreach(var patchFile in patchFiles)
            Assert.True(data.FileIndex.ContainsKey(patchFile));
    }
}
