using UnityEngine;
using System.Collections;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(NavMeshObstacle))]
public class QuadTest : MonoBehaviour
{

    private MeshBuilder meshBuilder ;
    private MeshFilter filter;
    private Mesh mesh;
    public float mesh_Length, mesh_Width, mesh_Height, segments;
    private Vector3 faceUp, faceRight, faceForward;
    MeshCollider meshc;
    public Transform test;
    BoxCollider[] boxColliders;
    bool first = true;
    public bool MakeMountain = true;

    void Start() {
        if(MakeMountain){
            StartMountain();
        }else{
            StartPlanet();
        }
    }

    void StartMountain()
    {
        //meshBuilder.segments = (int)(segments*segments);
        mesh = new Mesh();
        filter = GetComponent<MeshFilter>();
        meshBuilder = new MeshBuilder();
        faceUp = Vector3.up * mesh_Height;
        faceRight = Vector3.right * mesh_Width;
        faceForward = Vector3.forward * mesh_Length;
        boxColliders = new BoxCollider[(int)(segments * segments)];

        for(int i = 0; i < segments * segments; i++){
            boxColliders[i] = filter.gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        }

        int k = 0;
        for (int i = 0; i < segments; i++)
        {
            float z = mesh_Length * i;

            for (int j = 0; j < segments; j++)
            {
                float x = mesh_Width * j;
                Vector3 origin = new Vector3(x, Random.Range(0f, mesh_Height), z);
                boxColliders[k].center = origin + new Vector3(mesh_Width/2, mesh_Height/2, mesh_Length/2);
                boxColliders[k].size = new Vector3(mesh_Width, mesh_Height, mesh_Length);
                k++;

                MakeACube(origin);
            }
        }
    }

    void StartPlanet()
    {
        //meshBuilder.segments = (int)(segments*segments);
        mesh = new Mesh();
        filter = GetComponent<MeshFilter>();
        meshBuilder = new MeshBuilder();
        faceUp = Vector3.up * mesh_Height;
        faceRight = Vector3.right * mesh_Width;
        faceForward = Vector3.forward * mesh_Length;
        boxColliders = new BoxCollider[(int)(segments * segments)];

        for(int i = 0; i < segments * segments; i++){
            boxColliders[i] = filter.gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        }

        int k = 0;
        for (int i = 0; i < segments; i++)
        {
            float z = mesh_Length * i;

            for (int j = 0; j < segments; j++)
            {
                float randomScale = Random.Range(1f, 2f);
                float x = mesh_Width * j;
                Vector3 origin = new Vector3(x, Random.Range(0, 0.2f), z) ;//+ new Vector3(0,randomScale,0);
                float tmpj;
                float tmpi;
                if(i < segments/2){
                    tmpi = i+1;
                }else{
                    tmpi = segments - i;
                }
                if(j < segments/2){
                    tmpj = j+1;
                }else{
                    tmpj = segments - j;
                }
                faceUp = Vector3.up * mesh_Height * randomScale * tmpi *tmpj;
               //boxColliders[k].center = origin + new Vector3(mesh_Width/2, mesh_Height/2, mesh_Length/2);
               //boxColliders[k].size = new Vector3(mesh_Width, mesh_Height, mesh_Length);
                k++;

                MakeACube(origin);
            }
        }
    }
    // Older version than below
   /* void Update() {

        for(int i = 0; i < segments * segments; i++){
            boxColliders[i] = filter.gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        }

      //  print(boxColliders.Length);

         int k = 0;

        for (int i=0; i< segments; i++)
        {
            float z = mesh_Length * i;

            for(int j=0; j<segments; j++)
            {

                float x = mesh_Width * j;
                Vector3 origin = new Vector3(x, Random.Range(0f, mesh_Height), z);
                boxColliders[k].center = origin + new Vector3(mesh_Length/2, mesh_Width/2, mesh_Height/2);
                boxColliders[k].size = new Vector3(mesh_Length, mesh_Width, mesh_Height);
                k++;
                MakeACube(k, origin);

            }
        }
        meshBuilder.ClearMesh();



    }

    */

    void Update() {
        // int k = 0;
        // for (int i=0; i< segments; i++)
        // {
        //     float z = mesh_Length * i;

        //     for(int j=0; j<segments; j++)
        //     {

        //         float x = mesh_Width * j;
        //         Vector3 origin = new Vector3(x, Random.Range(0f, mesh_Height), z);
        //         boxColliders[k].center = origin + new Vector3(mesh_Length/2, mesh_Width/2, mesh_Height/2);
        //         boxColliders[k].size = new Vector3(mesh_Length, mesh_Width, mesh_Height);
        //         k++;
        //         MakeACube(k, origin);

        //     }
        // }
        // //print(meshBuilder.triangles.Count/3);
        // meshBuilder.ClearMesh();



    }



    public void MakeACube(Vector3 origin)
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
        if(meshc == null){
           // meshc = filter.gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        }else{
           // Destroy(gameObject.GetComponent("MeshCollider"));
           // meshc = filter.gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        }
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
        if(first){
        meshBuilder.AddTriangle(startPoint, startPoint + 1, startPoint + 2);
        meshBuilder.AddTriangle(startPoint, startPoint + 2, startPoint + 3);
        //first = false;
        }
    }



}
