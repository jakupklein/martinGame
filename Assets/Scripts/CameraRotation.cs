using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	private GameObject player;
	public float speed;
	//Transform target;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		var target =  Quaternion.LookRotation(player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, speed * Time.deltaTime);
		//transform.LookAt(player.transform);
		Debug.DrawLine(transform.position, player.transform.position, Color.green);

	}
}
