using Parsec.Readers;
using Parsec.Shaiya.Ani;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Obj3DC;

Console.Write("Enter the scale factor:");
var scaleFactorText = Console.ReadLine();
Console.WriteLine();

if (!float.TryParse(scaleFactorText, out var scale))
{
    Console.WriteLine("[ERROR]: Scale factor couldn't be parsed.");
    return;
}

var dir = Directory.GetCurrentDirectory();
var files = Directory.GetFiles(dir);
var aniFiles = files.Where(f => Path.GetExtension(f).ToLower() == ".ani").ToList();
var obj3dcFiles = files.Where(f => Path.GetExtension(f).ToLower() == ".3dc").ToList();

// Rescale 3dcs
foreach (var obj3dcPath in obj3dcFiles)
{
    var obj3dc = Reader.ReadFromFile<Obj3DC>(obj3dcPath);

    // Rescale vertices
    foreach (var vertex in obj3dc.Vertices)
        vertex.Position = new Vector3(vertex.Position.X * scale, vertex.Position.Y * scale, vertex.Position.Z * scale);

    // Rescale bones
    for (var i = 0; i < obj3dc.Bones.Count; i++)
    {
        // Rescale bone matrix
        var bone = obj3dc.Bones[i];
        var matrix = bone.Matrix;
        var translation = matrix.Translation;
        matrix.Translation = new Vector3(translation.X * scale, translation.Y * scale, translation.Z * scale);

        // Redefine bone
        var newBone = new Parsec.Shaiya.Obj3DC.Bone
        {
            BoneIndex = bone.BoneIndex,
            Matrix = matrix
        };

        obj3dc.Bones[i] = newBone;
    }

    obj3dc.Write(obj3dcPath);
}

// Rescale anis
foreach (var aniPath in aniFiles)
{
    var ani = Reader.ReadFromFile<Ani>(aniPath);

    for (var i = 0; i < ani.Bones.Count; i++)
    {
        // Rescale bone matrix
        var bone = ani.Bones[i];
        var matrix = bone.Matrix;
        var translation = matrix.Translation;
        matrix.Translation = new Vector3(translation.X * scale, translation.Y * scale, translation.Z * scale);

        // Rescale translations
        foreach (var frame in bone.TranslationFrames)
        {
            frame.Vector = new Vector3(frame.Vector.X * scale, frame.Vector.Y * scale, frame.Vector.Z * scale);
        }

        // Redefine bone
        var newBone = new Parsec.Shaiya.Ani.Bone
        {
            BoneIndex = bone.BoneIndex,
            ParentBoneIndex = bone.ParentBoneIndex,
            Matrix = matrix,
            RotationFrames = bone.RotationFrames,
            TranslationFrames = bone.TranslationFrames
        };

        ani.Bones[i] = newBone;
    }

    ani.Write(aniPath);
}

Console.WriteLine($"Converted {aniFiles.Count} ANI files.");
Console.WriteLine($"Converted {obj3dcFiles.Count} 3DC files.");
Console.ReadLine();
