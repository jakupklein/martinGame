using UnityEngine;
using System.Collections;

public class CreateBoss : MonoBehaviour {

	BossChooseShape childScript;

    Tetrahedron tetrahedron;	//4
	Octahedron octahedron;		//8
	Dodecahedron dodecahedron;	//12
	Icosahedron icosahedron;	//20

	public int counter;

	public Color tetrahedronColor;
	public Color octahedronColor;
	public Color dodecahedronColor;
	public Color icosahedronColor;

	private Color[] colorArray;

	// Use this for initialization
	void Start () {
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
}
