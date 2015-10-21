using UnityEngine;
using System.Collections;

public class BossChooseShape : MonoBehaviour {

	Tetrahedron tetrahedron;	//4
	Octahedron octahedron;		//8
	Dodecahedron dodecahedron;	//12
	Icosahedron icosahedron;	//20
	private float rotationSpeed;
	private Renderer rend;

	void Start () {
		rotationSpeed = Random.Range(-5f, 5f);
		rend = gameObject.GetComponent<Renderer>();

        tetrahedron  = gameObject.GetComponent<Tetrahedron>();
		octahedron   = gameObject.GetComponent<Octahedron>();
		dodecahedron = gameObject.GetComponent<Dodecahedron>();
		icosahedron  = gameObject.GetComponent<Icosahedron>();
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * rotationSpeed);
	}

	public void ChangeShape(int shapeNumber, Color shapeColor) {

		switch(shapeNumber)
		{
			case 0:
				//print("0");
				tetrahedron.MakeMesh();
				transform.localScale = new Vector3(1.63965f, 1.63965f, 1.63965f);
				transform.localPosition = new Vector3(0f, 0.137f, 0.071f);
				rend.material.color = shapeColor;
				break;
			case 1:
				//print("1");
				octahedron.MakeMesh();
				transform.localScale= new Vector3(2.165706f, 2.165706f, 2.165706f);
				rend.material.color = shapeColor;
				break;
			case 2:
				//print("2");
				dodecahedron.MakeMesh();
				transform.localScale = new Vector3(1.04493f, 1.04493f, 1.04493f);
				rend.material.color = shapeColor;
				break;
			case 3:
				//print("3");
				icosahedron.MakeMesh();
				transform.localScale = new Vector3(1,1,1);
				rend.material.color = shapeColor;
				break;

		}
	}
}
