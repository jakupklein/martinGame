#pragma strict

var startObject : GameObject;
private var newVertices : Vector3[];
private var newNormals : Vector3[];
private var newUV : Vector2[];
private var newTriangles : int[];
private var offsetVertices : int = 0;
private var offsetTriangles : int = 0;
private var maxVertices : int = 65534;
private var maxTriangles : int = 65534;

function Start () {
	var mesh : Mesh = new Mesh ();

	if (null == GetComponent.<MeshFilter>())
	{
		gameObject.AddComponent.<MeshFilter>();
	}
	if (null == GetComponent.<MeshRenderer>())
	{
		gameObject.AddComponent.<MeshRenderer>();
	}
	
	GetComponent.<MeshFilter>().mesh = mesh;
}

function Update()
{
	if (null != startObject) 
	{
		var mesh : Mesh = GetComponent.<MeshFilter>().sharedMesh;
		var i : int;
		
		newVertices = new Vector3[maxVertices];
		newNormals = new Vector3[maxVertices];
		newUV = new Vector2[maxVertices];
		offsetVertices = 0;
		newTriangles = new int[maxTriangles];
		offsetTriangles = 0;
	
		LSystem(0, transform.worldToLocalMatrix * startObject.transform.localToWorldMatrix);

		var allVertices : Vector3[] = new Vector3[offsetVertices];
		var allNormals : Vector3[] = new Vector3[offsetVertices];
		var allUV : Vector2[] = new Vector2[offsetVertices];
		var allTriangles : int[] = new int[offsetTriangles];
		
		for (i = 0; i < offsetVertices; i++)
		{
			allVertices[i] = newVertices[i];
			allNormals[i] = newNormals[i];
			allUV[i] = newUV[i];
		}
		for (i = 0; i < offsetTriangles; i++)
		{
			allTriangles[i] = newTriangles[i];
		}
		
		Debug.Log(offsetVertices + " " + offsetTriangles);
		
		mesh.Clear();
		mesh.vertices = allVertices;
		mesh.normals = allNormals;
		mesh.uv = allUV;	
		mesh.triangles = allTriangles;
	}		
}

private var recursionMax : int = 7;


function LSystem(recursion : int, startMatrix : Matrix4x4)
{
	var newStartMatrix : Matrix4x4 = startMatrix * Matrix4x4.identity;
	var endMatrix : Matrix4x4;

	if (recursion > recursionMax)
	{
		return;
	}

	// stem
	{
	  	endMatrix = newStartMatrix * Matrix4x4.TRS(Vector3(0.0, 3.0, 0.0), 
			Quaternion.Euler(2.0, 0.0, 0.0), 
			Vector3(0.9, 1.0, 0.9)) ; 
		generateTube(2, 9, newStartMatrix, (recursion + 0.0f) / recursionMax, endMatrix, (recursion + 1.0f) / recursionMax);  		
		LSystem(recursion + 1, endMatrix);
	}

}

function generateTube(na : int, nc : int, startMatrix : Matrix4x4, startV : float, endMatrix : Matrix4x4, endV : float) 
{
	var mesh : Mesh = GetComponent.<MeshFilter>().sharedMesh;
	var i : int;
	var j : int;
	var t : float;
	var startPosition : Vector3 = startMatrix.GetColumn(3);
	var endPosition : Vector3 = endMatrix.GetColumn(3);
	var startYAxis : Vector3 = startMatrix.MultiplyVector(Vector3(0,1,0));
	var endYAxis : Vector3 = endMatrix.MultiplyVector(Vector3(0,1,0));
	var startXAxis : Vector3 = startMatrix.MultiplyVector(Vector3(1,0,0));
	var endXAxis : Vector3 = endMatrix.MultiplyVector(Vector3(1,0,0));
	var startZAxis : Vector3 = startMatrix.MultiplyVector(Vector3(0,0,1));
	var endZAxis : Vector3 = endMatrix.MultiplyVector(Vector3(0,0,1));
	var position : Vector3;
	var previousPosition : Vector3;
	var yAxis : Vector3;
	var xAxis : Vector3;
	var matrix : Matrix4x4;
	var q : Quaternion;
	var tempYAxis : Vector3;
	var scaling : Vector3;
	var uv : Vector2;
		
	if (offsetVertices + nc * na > maxVertices || offsetTriangles + 6 * nc * (na - 1) > maxTriangles)
	{
		Debug.LogWarning("Mesh too large.");
		return;
	}
		
	// create vertices
	for (j = 0; j < na; j++)
	{
		t = j / (na - 1.0);
	
		// compute transformation for circle
		previousPosition = position;
		position = (2.0*t*t*t - 3.0*t*t + 1.0) * startPosition  
         + (t*t*t - 2.0*t*t + t) * startYAxis * 2.0 
         + (-2.0*t*t*t + 3.0*t*t) * endPosition
         + (t*t*t - t*t) * endYAxis * 2.0;

		if (0 == j) 
		{
			yAxis = startYAxis.normalized;
		}
		else if (j == na - 1)
		{
			yAxis = endYAxis.normalized;
		}		
		else
		{
			yAxis = (position - previousPosition).normalized;
		}		
		xAxis = (1.0 - t) * startXAxis + t * endXAxis;
		scaling = Vector3((1.0 - t) * startXAxis.magnitude + t * endXAxis.magnitude,
			(1.0 - t) * startYAxis.magnitude + t * endYAxis.magnitude,
			(1.0 - t) * startZAxis.magnitude + t * endZAxis.magnitude);
					
		q = Quaternion.FromToRotation(Vector3(1,0,0), xAxis.normalized); // rotate x axis as needed
		tempYAxis = Matrix4x4.TRS(Vector3(0,0,0), q, Vector3(1,1,1)).MultiplyVector(Vector3(0.0, 1.0, 0.0)); // y axis rotated by q
		q = Quaternion.FromToRotation(tempYAxis, yAxis) * q; // this rotates the y axis to where it should be and the x axis should be correct, too (if possible)
		matrix = Matrix4x4.TRS(position, q, scaling);
	
		// set vertices
		for (i = 0; i < nc; i++) 
		{			
			var phi : float;
			
			phi = i * 2.0 * Mathf.PI / (nc - 1.0);
			
			newVertices[offsetVertices + j * nc + i] = matrix.MultiplyPoint(Vector3(Mathf.Cos(phi), 0, -Mathf.Sin(phi)));
			newNormals[offsetVertices + j * nc + i] = matrix.inverse.transpose.MultiplyVector(Vector3(Mathf.Cos(phi), 0, -Mathf.Sin(phi)));
			newUV[offsetVertices + j * nc + i] = Vector2(i / (nc - 1.0), (1.0 - t) * startV + t * endV);
		}
	}

	// create triangles 	
	for (j = 0; j < na - 1; j++)
	{
		for (i = 0; i < nc - 1; i++) 
		{
			newTriangles[offsetTriangles + (j * nc + i) * 6 + 0] = offsetVertices + j * nc + i;
			newTriangles[offsetTriangles + (j * nc + i) * 6 + 1] = offsetVertices + (j + 1) * nc + (i + 1);
			newTriangles[offsetTriangles + (j * nc + i) * 6 + 2] = offsetVertices + (j + 1) * nc + i;
			newTriangles[offsetTriangles + (j * nc + i) * 6 + 3] = offsetVertices + j * nc + i;
			newTriangles[offsetTriangles + (j * nc + i) * 6 + 4] = offsetVertices + j * nc + (i + 1);
			newTriangles[offsetTriangles + (j * nc + i) * 6 + 5] = offsetVertices + (j + 1) * nc + (i + 1);
		}
	}	
	
	offsetVertices = offsetVertices + nc * na;
	offsetTriangles = offsetTriangles + 6 * nc * (na - 1);
}