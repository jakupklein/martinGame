#pragma strict

var quadsCount : int = 10000;

function Start () {
	var i : int;

	var newVertices : Vector3[] = new Vector3[quadsCount * 4];
	var newTriangles : int[] = new int[quadsCount * 6];
	
	for (i = 0; i < quadsCount; i++)
	{
		var position : Vector3 = Vector3(Random.Range(-10.0, 10.0), Random.Range(0.0, 10.0), Random.Range(-10.0, 10.0));
		newVertices[i * 4 + 0] = position + Vector3(-0.05, -0.05, 0.0); 
		newVertices[i * 4 + 1] = position + Vector3(0.05, -0.05, 0.0); 
		newVertices[i * 4 + 2] = position + Vector3(0.05, 0.05, 0.0); 
		newVertices[i * 4 + 3] = position + Vector3(-0.05, 0.05, 0.0); 
		newTriangles[i * 6 + 0] = i * 4 + 0; 
		newTriangles[i * 6 + 1] = i * 4 + 2; 
		newTriangles[i * 6 + 2] = i * 4 + 1; 
		newTriangles[i * 6 + 3] = i * 4 + 0; 
		newTriangles[i * 6 + 4] = i * 4 + 3; 
		newTriangles[i * 6 + 5] = i * 4 + 2; 
	}

	var mesh : Mesh = new Mesh ();
	GetComponent.<MeshFilter>().mesh = mesh;
	mesh.vertices = newVertices;
	mesh.triangles = newTriangles;
}


function Update () {
	var mesh : Mesh = GetComponent.<MeshFilter>().mesh;
	var vertices : Vector3[] = mesh.vertices;
	var normals : Vector3[] = mesh.normals;

	for (var i :int = 0; i < quadsCount; i++)
	{
		if (vertices[i * 4 + 0].y > 0.1)
		{
			vertices[i * 4 + 0].y -= 0.5;
			vertices[i * 4 + 1].y -= 0.5;
			vertices[i * 4 + 2].y -= 0.5;
			vertices[i * 4 + 3].y -= 0.5;
		}
		else 
		{
			vertices[i * 4 + 0].y += 10.0;
			vertices[i * 4 + 1].y += 10.0;
			vertices[i * 4 + 2].y += 10.0;
			vertices[i * 4 + 3].y += 10.0;
		}
	}
	mesh.vertices = vertices;
}