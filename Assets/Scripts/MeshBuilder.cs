using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshBuilder  
{

    private List<Vector3> meshVertices = new List<Vector3>();
    public List<Vector3> Vertices
    {
        get
        {
            return meshVertices;
        }
    }

    private List<Vector3> meshNormals = new List<Vector3>();
    public List<Vector3> Normals
    {
        get
        {
            return meshNormals;
        }
    }

    private List<Vector2> meshUvs = new List<Vector2>();
    public List<Vector2> Uvs
    {
        get
        {
            return meshUvs;
        }
    }

    private List<int> m_Indices = new List<int>();

    public void AddTriangle(int point0, int point1, int point2)
    {
        m_Indices.Add(point0);
        m_Indices.Add(point1);
        m_Indices.Add(point2);
    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();

        mesh.vertices = meshVertices.ToArray();
        mesh.triangles = m_Indices.ToArray();

        //To add the normal we must have the correct amount:
        if (meshNormals.Count == meshVertices.Count)
            mesh.normals = meshNormals.ToArray();

        //The same applies in the UVs . We need the same amount in order to assign them:
        if (meshUvs.Count == meshVertices.Count)
            mesh.uv = meshUvs.ToArray();

        mesh.RecalculateBounds();

        
        return mesh;
    }




}
