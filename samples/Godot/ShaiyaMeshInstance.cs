using System.Linq;
using Godot;
using Godot.Collections;
using Parsec;
using Parsec.Shaiya._3DC;

namespace ShaiyaGodotProject
{
    public class ShaiyaMeshInstance : MeshInstance
    {
        private string _3dcPath = "Mob_Elk_01.3DC";
        private string _ddsPath = "Mob_Elk_01.dds";

        public override void _Ready()
        {
            var obj = Reader.ReadFromFile<_3DC>(_3dcPath);

            var surfaceArray = new Array();
            surfaceArray.Resize((int)ArrayMesh.ArrayType.Max);

            var vertices = new Array<Vector3>();
            var uvs = new Array<Vector2>();
            var normals = new Array<Vector3>();
            var indices = new Array<int>();

            foreach (var vertex in obj.Vertices)
            {
                vertices.Add(new Vector3(vertex.Coordinates.X, vertex.Coordinates.Y, vertex.Coordinates.Z));
                normals.Add(new Vector3(vertex.Normal.X, vertex.Normal.Y, vertex.Normal.Z));
                uvs.Add(new Vector2(vertex.UV.X, vertex.UV.Y));
            }

            foreach (var face in obj.Faces)
            {
                indices.Add(face.VertexIndex1);
                indices.Add(face.VertexIndex3);
                indices.Add(face.VertexIndex2);
            }

            surfaceArray[(int)Mesh.ArrayType.Vertex] = vertices.ToArray();
            surfaceArray[(int)Mesh.ArrayType.TexUv] = uvs.ToArray();
            surfaceArray[(int)Mesh.ArrayType.Normal] = normals.ToArray();
            surfaceArray[(int)Mesh.ArrayType.Index] = indices.ToArray();

            var arrayMesh = new ArrayMesh();
            arrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, surfaceArray);
            Mesh = arrayMesh;

            var texture = GD.Load<Texture>(_ddsPath);
            var material = new SpatialMaterial
            {
                AlbedoTexture = texture
            };

            MaterialOverride = material;
        }
    }
}
