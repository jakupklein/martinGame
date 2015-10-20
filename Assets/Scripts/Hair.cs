using UnityEngine;
using System.Collections;

public class Hair : MonoBehaviour {

//public GameObject test;
	//void Start() {
	public void Start(){
	MeshFilter meshFilter = GetComponent<MeshFilter>();

	if (meshFilter==null){
	    Debug.LogError("MeshFilter not found!");
	    return;


        }

    Vector3 p0 = new Vector3(-0.5f,-Mathf.Sqrt(0.75f)/2f,-Mathf.Sqrt(0.75f)/2f);

	Vector3 p1 = p0 + new Vector3(1,0,0);
	Vector3 p2 = p0 + new Vector3(0.5f,0,Mathf.Sqrt(0.75f));
	Vector3 p3 = p0 + new Vector3(0.5f,Mathf.Sqrt(0.75f),Mathf.Sqrt(0.75f)/3);

	Vector3 fixCenterOffset = new Vector3(0,-0.223f,-0.144f);
	//Vector3 fixCenterOffset = new Vector3(
	//									(p0.x + p1.x + p2.x + p3.x)/3,
	//									(p0.y + p1.y + p2.y + p3.y)/3,
	//									(p0.z + p1.z + p2.z + p3.z)/3
	//									);
//	test.transform.position = fixCenterOffset;
	Vector3[] normals = {p0 + fixCenterOffset,p1 + fixCenterOffset,p2 + fixCenterOffset,p3 + fixCenterOffset};
	for(int i = 0; i < normals.Length; i++){
		normals[i] = normals[i].normalized;
	}
	Mesh mesh = meshFilter.mesh;
	if (mesh == null){
	    meshFilter.mesh = new Mesh();
	    mesh = meshFilter.mesh;
	}
	mesh.Clear();
	mesh.vertices = new Vector3[]{p0,p1,p2,p3};
	var test = new Vector3[]{p0,p1,p2,p3};
	mesh.triangles = new int[]{
	    0,1,2,
	    0,2,3,
	    2,1,3,
	    0,3,1
	};
	//for(int i = 0; i < test.Length; i++){
	//	Debug.DrawLine(test[i]+transform.position, new Vector3(test[i].x+test[i].x+transform.position.x,
	//														   test[i].y+test[i].y+transform.position.y,
	//														   test[i].z+test[i].z+transform.position.z));
	//}
	mesh.normals = test;
	//mesh.RecalculateNormals();
	mesh.RecalculateBounds();
	mesh.Optimize();
	//mesh.Optimize();
	//	var tem = new QuadTest();
	}




}
