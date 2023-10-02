using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT;

public sealed class EFTTexture : IBinary
{
    [JsonConstructor]
    public EFTTexture()
    {
    }

    public EFTTexture(SBinaryReader binaryReader, int index)
    {
        Index = index;
        Name = binaryReader.ReadString();
    }

    public int Index { get; set; }
    public string Name { get; set; } = string.Empty;

    public IEnumerable<byte> GetBytes(params object[] options) => Name.GetLengthPrefixedBytes();
}
