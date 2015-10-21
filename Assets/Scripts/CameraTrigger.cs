using UnityEngine;
using System.Collections;

public class CameraTrigger : MonoBehaviour {

	private GameObject camera;
	public GameObject cameraPoint;
	// Use this for initialization
	void Start () {
			camera = GameObject.FindGameObjectWithTag("MainCamera");

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider other) {

		if(other.gameObject.tag == "Player"){
			camera.transform.position = cameraPoint.transform.position;
			camera.transform.rotation = cameraPoint.transform.rotation;}
	}
}
