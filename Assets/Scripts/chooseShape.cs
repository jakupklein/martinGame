using UnityEngine;
using System.Collections;

public class chooseShape : MonoBehaviour {

	public int counter;
    private GameObject gMO;
    private GameManager gM;
    Tetrahedron tetrahedron;	//4
	Octahedron octahedron;		//8
	Dodecahedron dodecahedron;	//12
	Icosahedron icosahedron;	//20
	bool runCollisoinOnce = true;
	// Use this for initialization
	void Start () {
        gMO = GameObject.Find("GameManager");
        gM = gMO.GetComponent<GameManager>();
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

        gM.ZombiePlus();

    }

	// Update is called once per frame
	void Update () {
		if(counter == 0){
			Destroy(gameObject);
		}
		else if(counter == 1){
			tetrahedron.MakeMesh();
			transform.localScale = new Vector3(2f, 2f, 2f);
		}
		else if(counter == 2){
			octahedron.MakeMesh();
			transform.localScale = new Vector3(2f, 2f, 2f);
		}
		else if(counter == 3){
			dodecahedron.MakeMesh();
		}
		else if(counter == 4){
			icosahedron.MakeMesh();

		}else{
			//print("the counter of chooseShape is to big! ");
		}

		//print(counter);
		runCollisoinOnce = true;

	}

	 void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Fist" && runCollisoinOnce) {
			//print("fist");
			runCollisoinOnce = false;
				counter--;

		}
        

	}


}
