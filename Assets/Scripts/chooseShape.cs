using UnityEngine;
using System.Collections;

public class chooseShape : MonoBehaviour {

	public int counter;
    private GameObject gMO;
    private GameManager gM;
    private Material mat;
    private Renderer rend;
    Tetrahedron tetrahedron;	//4
	Octahedron octahedron;		//8
	Dodecahedron dodecahedron;	//12
	Icosahedron icosahedron;	//20

	public Color tetrahedronColor;
	public Color octahedronColor;
	public Color dodecahedronColor;
	public Color icosahedronColor;

    bool wasLeftFist;

	bool runCollisoinOnce = true;
	// Use this for initialization
	void Start () {
		rend = gameObject.GetComponent<Renderer>();
		//mat = new Material(Shader.Find("Standard"));
		//rend = new Renderer();
		//rend.material = mat;
        gMO = GameObject.Find("GameManager");
        gM = gMO.GetComponent<GameManager>();
        tetrahedron  = gameObject.GetComponent<Tetrahedron>();
		octahedron   = gameObject.GetComponent<Octahedron>();
		dodecahedron = gameObject.GetComponent<Dodecahedron>();
		icosahedron  = gameObject.GetComponent<Icosahedron>();

		counter = (int)Random.Range(1f, 5f);
		if(counter == 5)
			counter = 4;

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
            gM.ZombieMinus();
            if (wasLeftFist)
            {
                gM.IncreaseSpeedLeft();
            }
            else
            {
                gM.IncreaseSpeedRight();
            }

            Destroy(gameObject);

            
		}
		else if(counter == 1){
			tetrahedron.MakeMesh();
			transform.localScale = new Vector3(2f, 2f, 2f);
			rend.material.color = tetrahedronColor;

		}
		else if(counter == 2){
			octahedron.MakeMesh();
			transform.localScale = new Vector3(2f, 2f, 2f);
			rend.material.color = octahedronColor;
		}
		else if(counter == 3){
			dodecahedron.MakeMesh();
			rend.material.color = dodecahedronColor;
		}
		else if(counter == 4){
			icosahedron.MakeMesh();
			rend.material.color = icosahedronColor;

		}else{
			//print("the counter of chooseShape is to big! ");
		}

		//print(counter);
		runCollisoinOnce = true;

	}

	 void OnCollisionEnter(Collision other) {
		if((other.gameObject.tag == "RightFist" || other.gameObject.tag == "LeftFist" )&& runCollisoinOnce) {
			print("fist");
			runCollisoinOnce = false;
				counter--;
            if(other.gameObject.tag == "LeftFist")
            {
                wasLeftFist = true;
            }
            else
            {
                wasLeftFist = false;
            }

		}
        

	}


}
