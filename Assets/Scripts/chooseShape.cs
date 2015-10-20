using UnityEngine;
using System.Collections;

public class chooseShape : MonoBehaviour {

	public int counter;
	Tetrahedron tetrahedron;	//4
	Octahedron octahedron;		//8
	Dodecahedron dodecahedron;	//12
	Icosahedron icosahedron;	//20
	// Use this for initialization
	void Start () {
		tetrahedron  = gameObject.GetComponent<Tetrahedron>();
		octahedron   = gameObject.GetComponent<Octahedron>();
		dodecahedron = gameObject.GetComponent<Dodecahedron>();
		icosahedron  = gameObject.GetComponent<Icosahedron>();

		counter = (int)Random.Range(1f, 4f);
		if(counter == 1)
			tetrahedron.MakeMesh();
		if(counter == 2)
			octahedron.MakeMesh();
		if(counter == 3)
			dodecahedron.MakeMesh();
		if(counter == 4)
			icosahedron.MakeMesh();
	}

	// Update is called once per frame
	void Update () {
		if(counter == 1){
			tetrahedron.MakeMesh();
			transform.localScale = new Vector3(2f, 2f, 2f);
		}
		if(counter == 2){
			octahedron.MakeMesh();
			transform.localScale = new Vector3(2f, 2f, 2f);
		}
		if(counter == 3){
			dodecahedron.MakeMesh();
		}
		if(counter == 4){
			icosahedron.MakeMesh();
		}

	}


}
