using UnityEngine;
using System.Collections;

public class InstantiateZombies : MonoBehaviour {

	public int numberOfZombiesOnStart;
	public GameObject Zombie;
	// Use this for initialization
	void Start () {
		//Zombie = Instantiate(Resources.Load("Zombie")) as GameObject;

		if(numberOfZombiesOnStart == null){
			print("Number of zombies not set, default value is 5.");
			numberOfZombiesOnStart = 5;
		}
		for(int i = 0; i < numberOfZombiesOnStart; i ++){

			Zombie.transform.position = new Vector3(Random.Range(-5f, 5),3f,Random.Range(-5f, 5));
			Instantiate(Zombie);
		}

	}

	// Update is called once per frame
	void Update () {

	}
}
