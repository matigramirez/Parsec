using System.Runtime.Serialization;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Data;

[DataContract]
public sealed class SFile : IBinary
{
    [JsonConstructor]
    public SFile()
    {
    }

    public SFile(SFolder parentFolder)
    {
        ParentFolder = parentFolder;
    }

    public SFile(string name, long offset, int length)
    {
        Name = name;
        Offset = offset;
        Length = length;
    }

    public SFile(SBinaryReader binaryReader, SFolder folder, Dictionary<string, SFile> fileIndex) : this(folder)
    {
        Name = binaryReader.ReadString();
        Offset = binaryReader.Read<long>();
        Length = binaryReader.Read<int>();
        Version = binaryReader.Read<int>();

        // Add file to the sah's file dictionary
        if (!fileIndex.ContainsKey(RelativePath))
            fileIndex.Add(RelativePath, this);
        else
            // Follow castor's _pv file name ending for duplicate files
            fileIndex.Add(RelativePath + "_pv", this);
    }

    /// <summary>
    /// The name of the file
    /// </summary>
    [DataMember]
    public string Name { get; set; }

    /// <summary>
    /// The offset in data.saf where the file is located
    /// </summary>
    [DataMember]
    public long Offset { get; set; }

    /// <summary>
    /// The length of the file in kbs
    /// </summary>
    [DataMember]
    public int Length { get; set; }

    /// <summary>
    /// The file version -not used by the game so this value doesn't really matter
    /// </summary>
    [DataMember]
    public int Version { get; set; }

    /// <summary>
    /// The relative path to the file
    /// </summary>
    public string RelativePath => ParentFolder == null || string.IsNullOrEmpty(ParentFolder.Name)
        ? Name
        : Path.Combine(ParentFolder.RelativePath, Name);

    /// <summary>
    /// The directory in which the file is
    /// </summary>
    public SFolder ParentFolder { get; set; }

    /// <inheritdoc />
    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Name.GetLengthPrefixedBytes());
        buffer.AddRange(Offset.GetBytes());
        buffer.AddRange(Length.GetBytes());
        buffer.AddRange(Version.GetBytes());
        return buffer;
    }
}
