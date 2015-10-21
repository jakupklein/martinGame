using UnityEngine;
using System.Collections;

public class CreateBoss : MonoBehaviour {

	BossChooseShape childScript;

    Tetrahedron tetrahedron;	//4
	Octahedron octahedron;		//8
	Dodecahedron dodecahedron;	//12
	Icosahedron icosahedron;	//20

	private int endurance = 12;
	private int damage;
	private bool runCollisoinOnce = true;
    private GameObject gMO;
    private GameManager gM;
    public bool bossDead;
    public Color tetrahedronColor;
	public Color octahedronColor;
	public Color dodecahedronColor;
	public Color icosahedronColor;

	private Color[] colorArray;

	// Use this for initialization
	void Start () {
        gMO = GameObject.Find("GameManager");
        gM = gMO.GetComponent<GameManager>();
        colorArray = new Color[]{ tetrahedronColor,
								  octahedronColor,
								  dodecahedronColor,
								  icosahedronColor,
								  icosahedronColor};

		for(int i = 0; i < transform.childCount; i++) {
			
			childScript = transform.GetChild(i).gameObject.GetComponent<BossChooseShape>();
			childScript.ChangeShape(i, colorArray[i]);
		}
	}


	void Update(){
		runCollisoinOnce = true;
        if (bossDead)
        {
            GameManager.youWin = true;
        }
		if(damage >= endurance * 4){
			//if(transform.childCount == 0 + 1)
			transform.GetChild(0).gameObject.SetActive(false);
            GameManager.youWin = true;
            Destroy(gameObject);
		}else if(damage >= endurance * 3){
			//if(transform.childCount == 1 + 1)
			transform.GetChild(1).gameObject.SetActive(false);
		}else if(damage >= endurance * 2){
			//if(transform.childCount == 2 + 1)
			transform.GetChild(2).gameObject.SetActive(false);
		}else if(damage >= endurance * 1){
			//if(transform.childCount == 3 + 1)
			transform.GetChild(3).gameObject.SetActive(false);
		}

	}

	public void BossRebirth() {
		transform.GetChild(0).gameObject.SetActive(true);
		transform.GetChild(1).gameObject.SetActive(true);
		transform.GetChild(2).gameObject.SetActive(true);
		transform.GetChild(3).gameObject.SetActive(true);
		damage = 0;
	}

	void OnCollisionEnter(Collision other) {

		if(other.gameObject.tag == "Fist" && runCollisoinOnce) {
			runCollisoinOnce = false;
				damage++;

		}

	}

}
