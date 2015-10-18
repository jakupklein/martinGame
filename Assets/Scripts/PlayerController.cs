using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {
	CharacterController charController;
	public float speed = 3.0F;
	public GameObject body;
	Rigidbody playerRigidbody;
	Vector3 movement, playerToMouse;
	float camRayLength =100f;
	int floorMask;


	void Awake(){
		charController = GetComponent<CharacterController> ();
		floorMask = LayerMask.GetMask ("Floor");


	}

	void FixedUpdate(){

	
		Turning ();
	}



	void Turning(){

		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			playerToMouse = floorHit.point - body.transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			body.transform.rotation = Quaternion.Slerp(body.transform.rotation, newRotation, speed *Time.deltaTime);

			//playerRigidbody.MoveRotation(newRotation);
		}
		Vector3 foward = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward) * speed;
		Vector3 side = Input.GetAxis ("Horizontal") * transform.TransformDirection (Vector3.right) * speed;
		charController.Move (foward * Time.deltaTime);
		charController.Move (side * Time.deltaTime);
		charController.SimpleMove (Physics.gravity);
	}

}
