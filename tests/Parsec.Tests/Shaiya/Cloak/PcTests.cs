using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Parsec.Shaiya.Cloak.Physics;
using Parsec.Shaiya.Common;

namespace Parsec.Tests.Shaiya.Cloak;

public class PcTests
{
    [Fact]
    public void PcReadWriteTest()
    {
        var pc = CreateValidPc();

        var bytes = pc.GetBytes().ToArray();
        var parsed = ParsecReader.FromBuffer<Pc>("sample.PC", bytes);

        Assert.Equal(800, bytes.Length);
        Assert.Equal("humf_cloak_flexible.3DC", parsed.FlexibleMeshes[0].FileName);
        Assert.Equal(0xcdcdcdcd, parsed.Links[0].Padding);
        Assert.Equal(20, parsed.Links[0].Anchors.Count);
        Assert.True(parsed.Links[0].Anchors[0].IsActive);
        Assert.False(parsed.Links[0].Anchors[5].IsActive);
        Assert.Equal(bytes, parsed.GetBytes());

        var parsedFromJson = ParsecReader.FromJson<Pc>("sample.PC", parsed.JsonSerialize());
        Assert.Equal(bytes, parsedFromJson.GetBytes());
    }

    [Fact]
    public void PcRejectsTruncatedSections()
    {
        var truncatedBuffer = new byte[4 + PcMeshReference.SerializedSize - 1];
        truncatedBuffer[0] = 1;

        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<Pc>("truncated.PC", truncatedBuffer));
    }

    [Fact]
    public void PcRequiresTwentyAnchorSlotsWhenWriting()
    {
        var pc = new Pc
        {
            Links = new List<PcClothLink>
            {
                new()
            }
        };

        Assert.Throws<InvalidDataException>(() => pc.GetBytes());
    }

    [Fact]
    public void PcMatchesEftrenderValidationRules()
    {
        const int flexibleFileNameOffset = sizeof(uint) + sizeof(int);
        const int linkOffset = sizeof(uint) + PcMeshReference.SerializedSize + sizeof(uint);
        const int columnSegmentsOffset = linkOffset + sizeof(int) * 4;
        const int firstAnchorOffset = linkOffset + sizeof(int) * 11;
        const int firstAnchorPositionOffset = firstAnchorOffset + sizeof(int) * 3;

        var emptyFileName = CreateValidPc().GetBytes().ToArray();
        emptyFileName[flexibleFileNameOffset] = 0;
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<Pc>("empty-name.PC", emptyFileName));

        var invalidGrid = CreateValidPc().GetBytes().ToArray();
        BitConverter.GetBytes(0).CopyTo(invalidGrid, columnSegmentsOffset);
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<Pc>("invalid-grid.PC", invalidGrid));

        var invalidReference = CreateValidPc().GetBytes().ToArray();
        BitConverter.GetBytes(1).CopyTo(invalidReference, linkOffset);
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<Pc>("invalid-reference.PC", invalidReference));

        var invalidPosition = CreateValidPc().GetBytes().ToArray();
        BitConverter.GetBytes(float.NaN).CopyTo(invalidPosition, firstAnchorPositionOffset);
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<Pc>("invalid-position.PC", invalidPosition));

        var excessiveCount = BitConverter.GetBytes((uint)Pc.MaximumMeshReferenceCount + 1);
        Assert.Throws<InvalidDataException>(() => ParsecReader.FromBuffer<Pc>("excessive-count.PC", excessiveCount));

        var nonCanonicalActiveFlag = CreateValidPc().GetBytes().ToArray();
        BitConverter.GetBytes(2u).CopyTo(nonCanonicalActiveFlag, firstAnchorOffset);
        var parsed = ParsecReader.FromBuffer<Pc>("active-flag.PC", nonCanonicalActiveFlag);
        Assert.False(parsed.Links[0].Anchors[0].IsActive);
    }

    private static Pc CreateValidPc()
    {
        return new Pc
        {
            FlexibleMeshes = new List<PcMeshReference>
            {
                CreateMeshReference(3, "humf_cloak_flexible.3DC")
            },
            Links = new List<PcClothLink>
            {
                new()
                {
                    ClothMeshIndex = 0,
                    TextureIndex = 7,
                    SolverMode = 1,
                    RigidMeshIndex = 0,
                    ColumnSegments = 4,
                    RowSegments = 6,
                    SampleColumn = 2,
                    SampleRow = 1,
                    SampleRadiusColumn = 2,
                    SampleRadiusRow = 3,
                    Padding = 0xcdcdcdcd,
                    Anchors = Enumerable.Range(0, PcClothLink.AnchorCount)
                        .Select(index => new PcAnchor
                        {
                            IsActive = index < 5,
                            ClothVertex = index,
                            SkeletonBone = index + 10,
                            BoneLocalPosition = new Vector3(index + 0.25f, index + 0.5f, index + 0.75f)
                        })
                        .ToList()
                }
            },
            RigidMeshes = new List<PcMeshReference>
            {
                CreateMeshReference(9, "humf_cloak_rigid.3DC")
            }
        };
    }

    private static PcMeshReference CreateMeshReference(int id, string fileName)
    {
        var fileNamePadding = Enumerable.Repeat((byte)0xcd, PcMeshReference.FileNameBufferSize - fileName.Length).ToArray();
        fileNamePadding[0] = 0;

        return new PcMeshReference
        {
            Id = id,
            FileName = fileName,
            FileNamePadding = fileNamePadding
        };
    }
}
