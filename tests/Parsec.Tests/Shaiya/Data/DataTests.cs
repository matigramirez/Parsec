using System.IO;
using System.Linq;
using Parsec.Shaiya.Data;
using Xunit;

namespace Parsec.Tests.Shaiya;

public class DataTests
{
    [Fact]
    public void DataBuildingTest()
    {
        DataBuilder.CreateFromDirectory("Shaiya/Data/sample_data", "Shaiya/Data/output_data");
        Assert.True(File.Exists("Shaiya/Data/output_data/output_data.sah"));
        Assert.True(File.Exists("Shaiya/Data/output_data/output_data.saf"));
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
}
