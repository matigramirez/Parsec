using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Parsec.Serialization;

namespace Parsec.Shaiya.Data;

[DataContract]
public sealed class SFile
{
    [JsonConstructor]
    public SFile()
    {
    }

    public SFile(SDirectory parentDirectory)
    {
        ParentDirectory = parentDirectory;
    }

    public SFile(string name, long offset, int length)
    {
        Name = name;
        Offset = offset;
        Length = length;
    }

    public SFile(SBinaryReader binaryReader, SDirectory directory, Dictionary<string, SFile> fileIndex) : this(directory)
    {
        Name = binaryReader.ReadString();
        Offset = binaryReader.ReadInt64();
        Length = binaryReader.ReadInt32();
        Version = binaryReader.ReadInt32();

        if (!fileIndex.ContainsKey(RelativePath))
            fileIndex.Add(RelativePath, this);
    }

    /// <summary>
    /// The name of the file
    /// </summary>
    [DataMember]
    public string Name { get; set; } = string.Empty;

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
    public string RelativePath => string.IsNullOrEmpty(ParentDirectory.Name) ? Name : Path.Combine(ParentDirectory.RelativePath, Name);

    /// <summary>
    /// The directory in which the file is
    /// </summary>
    public SDirectory ParentDirectory { get; set; } = null!;

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Name);
        binaryWriter.Write(Offset);
        binaryWriter.Write(Length);
        binaryWriter.Write(Version);
    }
}
