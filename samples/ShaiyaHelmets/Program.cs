using System;
using Parsec.Readers;
using Parsec.Shaiya.Obj3DC;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the .3dc file where you want the bone data to be taken from: ");
            var boneDataFilePath = Console.ReadLine();
            Console.WriteLine("Enter the helmet's generated static .3dc file:");
            var staticFilePath = Console.ReadLine();
            Console.WriteLine("Enter the helmet bone index:");
            var boneIndexStr = Console.ReadLine();

            if (string.IsNullOrEmpty(boneDataFilePath) || string.IsNullOrEmpty(staticFilePath))
            {
                Console.WriteLine("[ERROR]: .3dc file paths must not be empty");
                return;
            }

            if (!byte.TryParse(boneIndexStr, out var helmetBoneIndex))
            {
                Console.WriteLine("[ERROR]: BoneIndex couldn't be parsed");
                return;
            }

            Console.WriteLine("[INFO]: Attempting to read the bone data and static data files.");

            var boneData = Reader.ReadFromFile<Obj3DC>(boneDataFilePath);
            var staticObject = Reader.ReadFromFile<Obj3DC>(staticFilePath, true);

            // Replace vertices and faces
            boneData.Vertices = staticObject.Vertices;
            boneData.Faces = staticObject.Faces;

            // Set bone vertex groups
            foreach (var vertex in boneData.Vertices)
            {
                vertex.BoneWeight = 1;
                vertex.Bone2Weight = 0;
                vertex.Bone3Weight = 0;
                vertex.BoneVertexGroup1 = helmetBoneIndex;
                vertex.BoneVertexGroup2 = 0;
                vertex.BoneVertexGroup3 = 0;
            }

            boneData.Write("CreatedHelmet.3DC");
            Console.WriteLine("[INFO]: File 'CreatedHelmet.3DC' written.");
        }
        catch (Exception)
        {
            Console.WriteLine("[ERROR]: FATAL - An error occurred while parsing the provided files.");
        }
    }
}
