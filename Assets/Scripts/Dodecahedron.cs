using UnityEngine;
using System.Collections;

public class Dodecahedron : MonoBehaviour {

	private Vector3[] vertices;
	private int[] triangles;
	private Mesh mesh;
	private Vector3[] normals;

	// Use this for initialization
	// Use this for initialization
	//void Start () {
	public void MakeMesh(){

		vertices  = new Vector3[20];
		normals  = new Vector3[20];
		triangles  = new int[111];

		//vertices[4*i] = new Vector3(-1.618f/2f,-0.5f,0);
		vertices[0]  = new Vector3(-0.5f,0.5f,-0.5f);
		vertices[1]  = new Vector3(-0.5f,0.5f,0.5f);
		vertices[2]  = new Vector3(-0.5f,-0.5f,0.5f);
		vertices[3]  = new Vector3(-0.5f,-0.5f,-0.5f);
		vertices[4]  = new Vector3(0.5f,-0.5f,-0.5f);
		vertices[5]  = new Vector3(0.5f,0.5f,-0.5f);
		vertices[6]  = new Vector3(0.5f,0.5f,0.5f);
		vertices[7]  = new Vector3(0.5f,-0.5f,0.5f);
		vertices[8]  = new Vector3(0.7f,0.3f,0);
		vertices[9]  = new Vector3(-0.7f,0.3f,0);
		vertices[10] = new Vector3(0.3f,0,0.7f);
		vertices[11] = new Vector3(0.3f,0,-0.7f);
		vertices[12] = new Vector3(-0.3f,0,0.7f);
		vertices[13] = new Vector3(-0.3f,0,-0.7f);
		vertices[14] = new Vector3(0,0.7f,0.3f);
		vertices[15] = new Vector3(0,0.7f,-0.3f);
		vertices[16] = new Vector3(0,-0.7f,0.3f);
		vertices[17] = new Vector3(-0.7f,-0.3f,0);
		vertices[18] = new Vector3(0,-0.7f,-0.3f);
		vertices[19] = new Vector3(0.7f,-0.3f,0);

		normals[0]  = new Vector3(-0.5f,0.5f,-0.5f);
		normals[1]  = new Vector3(-0.5f,0.5f,0.5f);
		normals[2]  = new Vector3(-0.5f,-0.5f,0.5f);
		normals[3]  = new Vector3(-0.5f,-0.5f,-0.5f);
		normals[4]  = new Vector3(0.5f,-0.5f,-0.5f);
		normals[5]  = new Vector3(0.5f,0.5f,-0.5f);
		normals[6]  = new Vector3(0.5f,0.5f,0.5f);
		normals[7]  = new Vector3(0.5f,-0.5f,0.5f);
		normals[8]  = new Vector3(0.7f,0.3f,0);
		normals[9]  = new Vector3(-0.7f,0.3f,0);
		normals[10] = new Vector3(0.3f,0,0.7f);
		normals[11] = new Vector3(0.3f,0,-0.7f);
		normals[12] = new Vector3(-0.3f,0,0.7f);
		normals[13] = new Vector3(-0.3f,0,-0.7f);
		normals[14] = new Vector3(0,0.7f,0.3f);
		normals[15] = new Vector3(0,0.7f,-0.3f);
		normals[16] = new Vector3(0,-0.7f,0.3f);
		normals[17] = new Vector3(-0.7f,-0.3f,0);
		normals[18] = new Vector3(0,-0.7f,-0.3f);
		normals[19] = new Vector3(0.7f,-0.3f,0);

		CreateMesh ();
	}

	public Mesh CreateMesh() {


		triangles[0]  = 11;
		triangles[1]  = 13;
		triangles[2]  = 0;

		triangles[3]  = 0;
		triangles[4]  = 15;
		triangles[5]  = 5;

		triangles[6]  = 5;
		triangles[7]  = 11;
		triangles[8]  = 0;

		triangles[9]  = 3;
		triangles[10] = 13;
		triangles[11] = 11;

		triangles[12] = 11;
		triangles[13] = 4;
		triangles[14] = 18;

		triangles[15] = 18;
		triangles[16] = 3;
		triangles[17] = 11;

		triangles[18] = 11;
		triangles[19] = 5;
		triangles[20] = 8;

		triangles[21] = 8;
		triangles[22] = 19;
		triangles[23] = 4;

		triangles[24] = 4;
		triangles[25] = 11;
		triangles[26] = 8;

		triangles[27] = 8;
		triangles[28] = 5;
		triangles[29] = 15;

		triangles[30] = 15;
		triangles[31] = 14;
		triangles[32] = 8;

		triangles[33] = 8;
		triangles[34] = 14;
		triangles[35] = 6;

		triangles[36] = 7;
		triangles[37] = 19;
		triangles[38] = 10;

		triangles[39] = 8;
		triangles[40] = 6;
		triangles[41] = 19;

		triangles[42] = 19;
		triangles[43] = 6;
		triangles[44] = 10;

		triangles[45] = 10;
		triangles[46] = 7;
		triangles[47] = 19;

		triangles[48] = 18;
		triangles[49] = 4;
		triangles[50] = 19;

		triangles[51] = 18;
		triangles[52] = 19;
		triangles[53] = 7;

		triangles[54] = 7;
		triangles[55] = 16;
		triangles[56] = 18;

		triangles[57] = 10;
		triangles[58] = 6;
		triangles[59] = 14;

		triangles[60] = 14;
		triangles[61] = 1;
		triangles[62] = 10;

		triangles[63] = 10;
		triangles[64] = 1;
		triangles[65] = 12;

		triangles[66] = 12;
		triangles[67] = 7;
		triangles[68] = 10;

		triangles[69] = 7;
		triangles[70] = 12;
		triangles[71] = 16;

		triangles[72] = 16;
		triangles[73] = 12;
		triangles[74] = 2;

		triangles[75] = 2;
		triangles[76] = 12;
		triangles[77] = 1;

		triangles[78] = 1;
		triangles[79] = 9;
		triangles[80] = 2;

		triangles[81] = 2;
		triangles[82] = 9;
		triangles[83] = 17;

		triangles[84] = 16;
		triangles[85] = 2;
		triangles[86] = 17;

		triangles[87] = 17;
		triangles[88] = 3;
		triangles[89] = 16;

		triangles[90] = 16;
		triangles[91] = 3;
		triangles[92] = 18;

		triangles[93] = 3;
		triangles[94] = 17;
		triangles[95] = 9;

		triangles[96] = 9;
		triangles[97] = 0;
		triangles[98] = 3;

		triangles[99] = 3;
		triangles[100] = 0;
		triangles[101] = 13;

		triangles[102] = 9;
		triangles[103] = 1;
		triangles[104] = 14;

		triangles[105] = 14;
		triangles[106] = 15;
		triangles[107] = 9;

		triangles[108] = 9;
		triangles[109] = 15;
		triangles[110] = 0;


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

	}
}
