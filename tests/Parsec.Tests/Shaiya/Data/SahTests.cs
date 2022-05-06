﻿using System;
using System.ComponentModel;
using Parsec.Shaiya.Data;
using Xunit;

namespace Parsec.Tests.Shaiya;

public class SahTests
{
    [Theory]
    [InlineData("new_folder", "new_file.fl")]
    [InlineData("new_folder/sub1", "new_file.fl")]
    [InlineData("new_folder/sub1/sub2", "new_file.fl")]
    [InlineData("new_folder/sub1/sub2/sub3", "new_file.fl")]
    public void SahFileExistenceTest(string folderName, string fileName)
    {
        var sah = Reader.ReadFromFile<Sah>("Shaiya/Data/sample.sah");
        Assert.Equal("sah", sah.Extension);

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
        
        // Try to add the file and subfolder again
        Assert.Throws<Exception>(() => newFolder.AddFile(newFile1));
        Assert.Throws<Exception>(() => newFolder.AddSubfolder(newSubfolder));
    }

    [Fact]
    [Description("Test that checks if the Sah subclasses can be instanciated with an empty constructor for json deserialization")]
    public void SahJsonCreationTest()
    {
        var sah = new Sah();
        var folder = new SFolder();
        var file = new SFile();
        
        Assert.NotNull(sah);
        Assert.NotNull(folder);
        Assert.NotNull(file);
    }
}
