using System.Text.Json.Serialization;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Dg;

public class Dg : FileBase
{
    public BoundingBox BoundingBox { get; set; } = new();

    public List<String256> TextureNames { get; set; } = new();

    public int UnknownInt32 { get; set; }

    public List<DgNode?> Nodes { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        BoundingBox = binaryReader.Read<BoundingBox>();
        TextureNames = binaryReader.ReadList<String256>().ToList();
        UnknownInt32 = binaryReader.ReadInt32();

        while (true)
        {
            if (binaryReader.Position == binaryReader.StreamLength)
            {
                break;
            }

            // When value is 1, node data follows, otherwise node reading must be skipped
            var value = binaryReader.ReadInt32();

            if (value > 0)
            {
                var node = binaryReader.Read<DgNode>();
                Nodes.Add(node);
            }
            else
            {
                Nodes.Add(null);
            }
        }
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(TextureNames.ToSerializable());
        binaryWriter.Write(UnknownInt32);

        foreach (var node in Nodes)
        {
            if (node == null)
            {
                binaryWriter.Write(0);
                continue;
            }

            binaryWriter.Write(1);
            binaryWriter.Write(node);
        }
    }
}
