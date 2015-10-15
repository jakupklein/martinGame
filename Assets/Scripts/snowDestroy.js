#pragma strict

var quadsCount : int = 10000;

var quads : GameObject[] = new GameObject[quadsCount];
var quad : GameObject;

function Start () {
	var i : int;

	quad = GameObject.Find("Quad");
	
	for (i = 0; i < quadsCount; i++)
	{
		quads[i] = GameObject.Instantiate(quad, 
			Vector3(Random.Range(-10.0, 10.0), Random.Range(0.0, 10.0), Random.Range(-10.0, 10.0)),
			Quaternion.identity);
	}
	
}

function Update () {
	for (var i : int = 0; i < quadsCount; i++)
	{
		var quadTrafo : Transform = quads[i].transform;
		if (quadTrafo.position.y > 0.0)
		{
			quadTrafo.position.y -= 0.5;
		}
		else 
		{
			var position : Vector3 = quadTrafo.position;			
			Destroy(quads[i]);
			quads[i] = GameObject.Instantiate(quad, 
			position + Vector3(0.0, 10.0, 0.0),
			Quaternion.identity);
		}
	}
}
