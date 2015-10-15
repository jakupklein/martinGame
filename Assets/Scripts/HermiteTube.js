#pragma strict

var newVertices : Vector3[];
var newTriangles : int[];

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
	mesh.vertices = newVertices;
	mesh.triangles = newTriangles;

	generateTube(10, 10, Matrix4x4.TRS(Vector3(0.0,0.0,0.0), Quaternion.Euler(45.0,0.0,0.0), Vector3(1.0,1.0,1.0)), 
		Matrix4x4.TRS(Vector3(0.0,4.0,0.0), Quaternion.Euler(-45.0,0.0,0.0), Vector3(1.0,1.0,1.0)));
			
}

function generateTube(na : int, nc : int, startMatrix : Matrix4x4, endMatrix : Matrix4x4) 
{
	var mesh : Mesh = GetComponent.<MeshFilter>().mesh;
	var i : int;
	var j : int;
	var t : float;
	var startPosition : Vector3 = startMatrix.GetColumn(3);
	var endPosition : Vector3 = endMatrix.GetColumn(3);
	var startYAxis : Vector3 = startMatrix.MultiplyVector(Vector3(0,1,0));
	var endYAxis : Vector3 = endMatrix.MultiplyVector(Vector3(0,1,0));
	var startXAxis : Vector3 = startMatrix.MultiplyVector(Vector3(1,0,0));
	var endXAxis : Vector3 = endMatrix.MultiplyVector(Vector3(1,0,0));
	var position : Vector3;
	var previousPosition : Vector3;
	var yAxis : Vector3;
	var xAxis : Vector3;
	var matrix : Matrix4x4;
	var q : Quaternion;
	var m : Matrix4x4;
	var tempYAxis : Vector3;
	
	
	startYAxis = startYAxis.normalized;
	endYAxis = endYAxis.normalized;
	startXAxis = startXAxis.normalized;
	endXAxis = endXAxis.normalized;
	
	
	newVertices = new Vector3[na * nc];
	newTriangles = new int[nc * (na - 1) * 6];

	// create vertices
	for (j = 0; j < na; j++)
	{
		t = j / (na - 1.0);
	
		// compute transformation for circle
		previousPosition = position;
		position = (2.0*t*t*t - 3.0*t*t + 1.0) * startPosition  
         + (t*t*t - 2.0*t*t + t) * startYAxis 
         + (-2.0*t*t*t + 3.0*t*t) * endPosition
         + (t*t*t - t*t) * endYAxis;

		if (0 == j) 
		{
			yAxis = startYAxis;
		}
		else if (j == na - 1)
		{
			yAxis = endYAxis;
		}		
		else
		{
			yAxis = (position - previousPosition).normalized;
		}		
		xAxis = (1.0 - t) * startXAxis + t * endXAxis;
					
		q = Quaternion.FromToRotation(Vector3(1,0,0), xAxis); // rotate x axis as needed
		tempYAxis = Matrix4x4.TRS(Vector3(0,0,0), q, Vector3(1,1,1)).MultiplyVector(Vector3(0.0, 1.0, 0.0)); // y axis rotated by q
		q = Quaternion.FromToRotation(tempYAxis, yAxis) * q; // this rotates the y axis to where it should be and the x axis should be correct, too (if possible)
		matrix = Matrix4x4.TRS(position, q, Vector3(1,1,1));
	
		// set vertices
		for (i = 0; i < nc; i++) 
		{			
			var phi : float;
			
			phi = i * 2.0 * Mathf.PI / nc;
			
			newVertices[j * nc + i] = matrix.MultiplyPoint(Vector3(Mathf.Cos(phi), 0, -Mathf.Sin(phi)));
		}
	}

	// create triangles 	
	for (j = 0; j < na - 1; j++)
	{
		for (i = 0; i < nc; i++) 
		{
			newTriangles[(j * nc + i) * 6 + 0] = j * nc + i;
			newTriangles[(j * nc + i) * 6 + 1] = (j + 1) * nc + ((i + 1) % nc);
			newTriangles[(j * nc + i) * 6 + 2] = (j + 1) * nc + i;
			newTriangles[(j * nc + i) * 6 + 3] = j * nc + i;
			newTriangles[(j * nc + i) * 6 + 4] = j * nc + ((i + 1) % nc);
			newTriangles[(j * nc + i) * 6 + 5] = (j + 1) * nc + ((i + 1) % nc);
		}
	}
	
	mesh.Clear();
	mesh.vertices = newVertices;
	mesh.triangles = newTriangles;
	
}