using UnityEngine;
using System.Collections;

public class QuadTest : MonoBehaviour
{

    private MeshBuilder meshBuilder ;
    private MeshFilter filter;
    private Mesh mesh;
    public float mesh_Length, mesh_Width, mesh_Height, segments;
    private Vector3 faceUp, faceRight, faceForward;


    void Start()
    {
        
        mesh = new Mesh();
        filter = GetComponent<MeshFilter>();
        meshBuilder = new MeshBuilder();
        faceUp = Vector3.up * mesh_Height;
        faceRight = Vector3.right * mesh_Width;
        faceForward = Vector3.forward * mesh_Length;

    }
    void Update() { 
        for (int i=0; i< segments; i++)
        {
            float z = mesh_Length * i;

            for(int j=0; j<segments; j++)
            {

                float x = mesh_Width * j;
                Vector3 origin = new Vector3(x, Random.Range(0f, mesh_Height), z);
                
                MakeACube(origin);
            }
        }
       
    }

  

    void MakeACube( Vector3 origin)
    {
        //Vector3 origin = Vector3.one;
        Vector3 end = origin + (faceUp + faceRight +faceForward);

        BuildQuad(meshBuilder, origin, faceForward, faceRight);
        BuildQuad(meshBuilder, origin, faceRight, faceUp);
        BuildQuad(meshBuilder, origin, faceUp, faceForward);

        BuildQuad(meshBuilder, end, -faceRight, -faceForward);
        BuildQuad(meshBuilder, end, -faceUp, -faceRight);
        BuildQuad(meshBuilder, end, -faceForward, -faceUp);

      
        filter.sharedMesh = meshBuilder.CreateMesh();
        MeshCollider meshc = filter.gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;

    }

    void BuildQuad(MeshBuilder meshBuilder, Vector3 offset, Vector3 widthDirection, Vector3 lengthDirection)
    {
        Vector3 normal = Vector3.Cross(lengthDirection, widthDirection).normalized;

        //Set up the vertices and triangles:
        meshBuilder.Vertices.Add(offset);
        meshBuilder.Uvs.Add(new Vector2(0.0f, 0.0f));
        meshBuilder.Normals.Add(normal);

        meshBuilder.Vertices.Add(offset + lengthDirection);
        meshBuilder.Uvs.Add(new Vector2(0.0f, 1.0f));
        meshBuilder.Normals.Add(normal);

        meshBuilder.Vertices.Add(offset + lengthDirection + widthDirection);
        meshBuilder.Uvs.Add(new Vector2(1.0f, 1.0f));
        meshBuilder.Normals.Add(normal);

        meshBuilder.Vertices.Add(offset + widthDirection);
        meshBuilder.Uvs.Add(new Vector2(1.0f, 0.0f));
        meshBuilder.Normals.Add(normal);

        int startPoint = meshBuilder.Vertices.Count - 4;

        meshBuilder.AddTriangle(startPoint, startPoint + 1, startPoint + 2);
        meshBuilder.AddTriangle(startPoint, startPoint + 2, startPoint + 3);
    }
       

}