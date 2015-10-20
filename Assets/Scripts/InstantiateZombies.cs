using UnityEngine;
using System.Collections;

public class InstantiateZombies : MonoBehaviour {

	public int numberOfZombiesOnStart;
	public GameObject Zombie;
	// Use this for initialization
	void Start () {
		if(numberOfZombiesOnStart == null){
			print("Number of zombies not set, default value is 5.");
			numberOfZombiesOnStart = 5;
		}
		for(int i = 0; i < numberOfZombiesOnStart; i ++){
			//Instantiate(Zombie);
			//Zombie = Instantiate(Resources.Load("Zombie")) as GameObject;
		}

	}

	// Update is called once per frame
	void Update () {

	}
}
