using System.Runtime.Serialization;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Data;

[DataContract]
public sealed class SFile : IBinary
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
        Offset = binaryReader.Read<long>();
        Length = binaryReader.Read<int>();
        Version = binaryReader.Read<int>();

        if (!fileIndex.ContainsKey(RelativePath))
            fileIndex.Add(RelativePath, this);
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
    public string RelativePath => ParentDirectory == null || string.IsNullOrEmpty(ParentDirectory.Name)
        ? Name
        : Path.Combine(ParentDirectory.RelativePath, Name);

    /// <summary>
    /// The directory in which the file is
    /// </summary>
    public SDirectory ParentDirectory { get; set; }

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
