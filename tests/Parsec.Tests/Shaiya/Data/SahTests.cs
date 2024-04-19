﻿using System.ComponentModel;
using Parsec.Shaiya.Data;

namespace Parsec.Tests.Shaiya;

public class SahTests
{
    [Theory]
    [InlineData("new_folder", "new_file.fl")]
    [InlineData(@"new_folder\sub1", "new_file.fl")]
    [InlineData(@"new_folder\sub1\sub2", "new_file.fl")]
    [InlineData(@"new_folder\sub1\sub2\sub3", "new_file.fl")]
    public void SahFileExistenceTest(string folderName, string fileName)
    {
        var sah = ParsecReader.FromFile<Sah>("Shaiya/Data/sample.sah");

        // Add folder to sah
        var newFolder = sah.AddFolder(folderName);

        // Add file to created folder
        var newFile1 = new SFile(fileName, 200, 512);

        sah.AddFile(folderName, newFile1);

        Assert.True(sah.HasFolder(folderName));
        Assert.True(sah.HasFile(newFile1.RelativePath));
        Assert.NotNull(newFolder.GetFile(fileName));
        Assert.True(newFolder.HasFile(fileName));

        var newSubfolder = sah.AddFolder($"{folderName}/sub");
        Assert.True(newFolder.HasSubfolder("sub"));
    }

    // [Fact]
    // public void SahEncryptionTest()
    // {
    //     var crypto = SahCrypto.WithFileCountXorKey(0x55);
    //     var sah = Reader.ReadFromFile<Sah>("Shaiya/Data/sample.enc0x55.sah", crypto);
    //     sah.Write("Shaiya/Data/sample.new.enc0x55.sah");
    //     var cs1 = FileHash.Checksum("Shaiya/Data/sample.enc0x55.sah");
    //     var cs2 = FileHash.Checksum("Shaiya/Data/sample.new.enc0x55.sah");
    //     Assert.Equal(cs1, cs2);
    //
    //     sah.ResetEncryption();
    //     sah.Write("Shaiya/Data/sample.new.sah");
    //     var cs3 = FileHash.Checksum("Shaiya/Data/sample.sah");
    //     var cs4 = FileHash.Checksum("Shaiya/Data/sample.new.sah");
    //     Assert.Equal(cs3, cs4);
    // }

    [Fact]
    [Description("Test that checks if the Sah subclasses can be instanciated with an empty constructor for json deserialization")]
    public void SahJsonCreationTest()
    {
        var sah = new Sah();
        var folder = new SDirectory();
        var file = new SFile();

        Assert.NotNull(sah);
        Assert.NotNull(folder);
        Assert.NotNull(file);
    }

    [Fact]
    public void SahReadWriteTest()
    {
        var outputPath = "Shaiya/Data/sample_out.sah";
        var patchOutputPath = "Shaiya/Data/sample_out_patch.sah";

        var sah = ParsecReader.FromFile<Sah>("Shaiya/Data/sample.sah");
        sah.Write(outputPath);
        var patch = ParsecReader.FromFile<Sah>("Shaiya/Data/patch.sah");
        patch.Write(patchOutputPath);

        var sah2 = ParsecReader.FromFile<Sah>(outputPath);
        var patch2 = ParsecReader.FromFile<Sah>(patchOutputPath);
        Assert.Equal(sah.GetBytes(), sah2.GetBytes());
        Assert.Equal(patch.GetBytes(), patch2.GetBytes());
    }
}
