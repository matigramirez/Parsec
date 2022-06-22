using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3DE;

public class Frame : IBinary
{
    /// <summary>
    /// The frame's key.
    /// </summary>
    public int Keyframe { get; set; }

    /// <summary>
    /// The frame's vertex translations. There's one translation defined for each vertex.
    /// </summary>
    public List<VertexTranslation> VertexTranslations { get; } = new();

    [JsonConstructor]
    public Frame()
    {
    }

    public Frame(SBinaryReader binaryReader, int vertexCount)
    {
        Keyframe = binaryReader.Read<int>();

        for (int i = 0; i < vertexCount; i++)
        {
            var translation = new VertexTranslation(binaryReader);
            VertexTranslations.Add(translation);
        }
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Keyframe.GetBytes());
        buffer.AddRange(VertexTranslations.GetBytes(false));
        return buffer;
    }
}
