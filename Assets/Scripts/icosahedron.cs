using UnityEngine;
using System.Collections;

public class Icosahedron : MonoBehaviour {

	public Vector3[] vertices;
	private int[] triangles;
	private Mesh mesh;
	private int quads;
	public bool debug;
	public Transform[] debugPoints;
	public bool showDebugBalls;
	private Vector3[] normals;
	// Use this for initialization
	//void Start () {
	public void MakeMesh(){

		quads = 3;
		vertices  = new Vector3[quads*4];
		normals  = new Vector3[quads*4];
		triangles  = new int[60];


		for (int i = 0; i < quads; i++) {
			if(i == 0){
				vertices[4*i] = new Vector3(-1.618f/2f,-0.5f,0);
				//vertices[4*i] = new Vector3(0,0,0);
				vertices[4*i+1] = vertices[4*i] + new Vector3(1.618f,0,0);
				vertices[4*i+2] = vertices[4*i] + new Vector3(0,1,0);
				vertices[4*i+3] = vertices[4*i] + new Vector3(1.618f,1,0);

				normals[4*i] = new Vector3(-1.618f/2f,-0.5f,0);
				normals[4*i+1] = vertices[4*i] + new Vector3(1.618f,0,0);
				normals[4*i+2] = vertices[4*i] + new Vector3(0,1,0);
				normals[4*i+3] = vertices[4*i] + new Vector3(1.618f,1,0);
			}

			if(i == 1){
				vertices[4*i] = new Vector3(0,-1.618f/2f,-0.5f);
				//vertices[4*i] = new Vector3(0,0,0);
				vertices[4*i+1] = vertices[4*i] + new Vector3(0,1.618f,0);
				vertices[4*i+2] = vertices[4*i] + new Vector3(0,0,1);
				vertices[4*i+3] = vertices[4*i] + new Vector3(0,1.618f,1);

				normals[4*i] = new Vector3(0,-1.618f/2f,-0.5f);
				normals[4*i+1] = vertices[4*i] + new Vector3(0,1.618f,0);
				normals[4*i+2] = vertices[4*i] + new Vector3(0,0,1);
				normals[4*i+3] = vertices[4*i] + new Vector3(0,1.618f,1);
			}

			if(i == 2){
				vertices[4*i] = new Vector3(-0.5f,0,-1.618f/2f);
				//vertices[4*i] = new Vector3(0,0,0);
				vertices[4*i+1] = vertices[4*i] + new Vector3(0,0,1.618f);
				vertices[4*i+2] = vertices[4*i] + new Vector3(1,0,0);
				vertices[4*i+3] = vertices[4*i] + new Vector3(1,0,1.618f);

				normals[4*i] = new Vector3(-0.5f,0,-1.618f/2f);
				normals[4*i+1] = vertices[4*i] + new Vector3(0,0,1.618f);
				normals[4*i+2] = vertices[4*i] + new Vector3(1,0,0);
				normals[4*i+3] = vertices[4*i] + new Vector3(1,0,1.618f);
			}
		}

		for (int i = 0; i < debugPoints.Length; i++) {
			if(debugPoints != null)
				debugPoints[i].position = vertices[i];
		}

		CreateMesh ();
	}

	public Mesh CreateMesh() {

		if(debug)
		for (int i = 0; i < quads; i++) {
			triangles[6*i+0] = 4*i + 0;
			triangles[6*i+1] = 4*i + 3;
			triangles[6*i+2] = 4*i + 1;
			triangles[6*i+3] = 4*i + 0;
			triangles[6*i+4] = 4*i + 2;
			triangles[6*i+5] = 4*i + 3;
		}



		if (!debug) {
			triangles[0] = 8;
			triangles[1] = 2;
			triangles[2] = 5;

			triangles[3] = 8;
			triangles[4] = 5;
			triangles[5] = 10;

			triangles[6] = 10;
			triangles[7] = 5;
			triangles[8] = 3;

			triangles[9] = 3;
			triangles[10] = 7;
			triangles[11] = 11;

			triangles[12] = 11;
			triangles[13] = 7;
			triangles[14] = 9;

			triangles[15] = 9;
			triangles[16] = 7;
			triangles[17] = 2;

			triangles[18] = 3;
			triangles[19] = 5;
			triangles[20] = 7;

			triangles[21] = 6;
			triangles[22] = 11;
			triangles[23] = 9;

			triangles[24] = 6;
			triangles[25] = 1;
			triangles[26] = 11;

			triangles[27] = 11;
			triangles[28] = 1;
			triangles[29] = 3;


			triangles[30] = 3;
			triangles[31] = 1;
			triangles[32] = 10;

			triangles[33] = 1;
			triangles[34] = 4;
			triangles[35] = 10;

			triangles[36] = 4;
			triangles[37] = 8;
			triangles[38] = 10;

			triangles[39] = 6;
			triangles[40] = 4;
			triangles[41] = 1;

			triangles[42] = 5;
			triangles[43] = 2;
			triangles[44] = 7;

			triangles[45] = 6;
			triangles[46] = 9;
			triangles[47] = 0;

			triangles[48] = 0;
			triangles[49] = 9;
			triangles[50] = 2;


			triangles[51] = 0;
			triangles[52] = 2;
			triangles[53] = 8;

			triangles[54] = 8;
			triangles[55] = 4;
			triangles[56] = 0;

			triangles[57] = 4;
			triangles[58] = 6;
			triangles[59] = 0;

		}
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
		//mesh.colors = colors;
		//mesh.uv = newUV;



		return mesh;
	}

	// Update is called once per frame
	void Update () {

		for (int i = 0; i < debugPoints.Length; i++) {
			//if(debugPoints != null)
			//	vertices[i] = debugPoints[i].position;
		}
	//	CreateMesh ();
		//print (debugPoints [1].position + "    " + vertices[1]);

	}
}
