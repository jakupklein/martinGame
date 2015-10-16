using UnityEngine;
using System.Collections;

public class Tetrahedron : MonoBehaviour {
	
	void Start() {
	MeshFilter meshFilter = GetComponent<MeshFilter>();
	if (meshFilter==null){
	    Debug.LogError("MeshFilter not found!");
	    return;
            

        }

        Vector3 p0 = new Vector3(-0.5f,-Mathf.Sqrt(0.75f)/2f,-Mathf.Sqrt(0.75f)/2f);
	Vector3 p1 = p0 + new Vector3(1,0,0);
	Vector3 p2 = p0 + new Vector3(0.5f,0,Mathf.Sqrt(0.75f));
	Vector3 p3 = p0 + new Vector3(0.5f,Mathf.Sqrt(0.75f),Mathf.Sqrt(0.75f)/3);
	Vector3[] normals = {p0,p1,p2,p3};
	Mesh mesh = meshFilter.mesh;
	if (mesh == null){
	    meshFilter.mesh = new Mesh();
	    mesh = meshFilter.mesh;
	}
	mesh.Clear();
	mesh.vertices = new Vector3[]{p0,p1,p2,p3};
	mesh.triangles = new int[]{
	    0,1,2,
	    0,2,3,
	    2,1,3,
	    0,3,1
	};
	mesh.normals = normals;
	mesh.RecalculateNormals();
	mesh.RecalculateBounds();
	mesh.Optimize();

    


    }


}