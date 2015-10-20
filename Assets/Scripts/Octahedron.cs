using UnityEngine;
using System.Collections;

public class Octahedron : MonoBehaviour {

	private Vector3[] vertices;
	private int[] triangles;
	private Mesh mesh;
	private Vector3[] normals;

	// Use this for initialization
	//void Start () {
	public void MakeMesh(){

		vertices  = new Vector3[6];
		normals  = new Vector3[6];
		triangles  = new int[24];

		//vertices[4*i] = new Vector3(-1.618f/2f,-0.5f,0);
		vertices[0] = new Vector3(0.5f,0,0);
		vertices[1] = new Vector3(-0.5f,0,0);
		vertices[2] = new Vector3(0,-0.5f,0);
		vertices[3] = new Vector3(0,0.5f,0);
		vertices[4] = new Vector3(0,0,0.5f);
		vertices[5] = new Vector3(0,0,-0.5f);

		normals[0] = new Vector3(0.5f,0,0);
		normals[1] = new Vector3(-0.5f,0,0);
		normals[2] = new Vector3(0,-0.5f,0);
		normals[3] = new Vector3(0,0.5f,0);
		normals[4] = new Vector3(0,0,0.5f);
		normals[5] = new Vector3(0,0,-0.5f);

		CreateMesh ();
	}

	public Mesh CreateMesh() {


		triangles[0] = 0;
		triangles[1] = 3;
		triangles[2] = 4;

		triangles[3] = 4;
		triangles[4] = 3;
		triangles[5] = 1;

		triangles[6] = 5;
		triangles[7] = 3;
		triangles[8] = 0;


		triangles[9] = 5;
		triangles[10] = 1;
		triangles[11] = 3;

		triangles[12] = 5;
		triangles[13] = 0;
		triangles[14] = 2;

		triangles[15] = 2;
		triangles[16] = 0;
		triangles[17] = 4;

		triangles[18] = 2;
		triangles[19] = 1;
		triangles[20] = 5;

		triangles[21] = 2;
		triangles[22] = 4;
		triangles[23] = 1;

		//mesh = new Mesh();
		MeshFilter filter = GetComponent<MeshFilter>();

		if (filter == null)
		{
			gameObject.AddComponent<MeshFilter>();
			filter = GetComponent<MeshFilter>();
		}

		mesh = filter.mesh;
		mesh.Clear();
		mesh.RecalculateBounds();
		mesh.vertices = vertices;
		mesh.RecalculateNormals();
		mesh.triangles = triangles;
		mesh.normals = normals;

		return mesh;
	}

	// Update is called once per frame
	void Update () {
		//CreateMesh ();
	}
}
