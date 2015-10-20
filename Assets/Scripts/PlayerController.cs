using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public float speed = 3.0F, jumpSpeed=0.0F;
	Vector3 movement, playerToMouse, foward, side, upDirection;
	float camRayLength =100f;
	int floorMask;
    bool m_IsGrounded;
    private Rigidbody rb;


	void Awake(){
        rb = GetComponent<Rigidbody>();
        upDirection = Vector3.zero;
        floorMask = LayerMask.GetMask ("Floor");


	}

    void Update()
    {
        if (Input.GetButtonDown("Jump") && m_IsGrounded)
        {

            rb.AddForce(Vector3.up * jumpSpeed);


        }
    }

	void FixedUpdate(){


        MoveNTurning();
	}



	void MoveNTurning(){

		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
            float angle = Vector3.Angle(playerToMouse, transform.forward);
            //float angle = Quaternion.Angle(transform.rotation, body.transform.rotation);
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            // Debug.Log(angle);
            transform.rotation = newRotation;
      
           
             
            //playerRigidbody.MoveRotation(newRotation);
        }
		
        foward = Vector3.ProjectOnPlane(Camera.main.transform.forward * Input.GetAxis("Vertical") * speed, Vector3.up);
        side = Vector3.ProjectOnPlane(Camera.main.transform.right * Input.GetAxis("Horizontal") * speed, Vector3.up);

        rb.transform.position = (rb.transform.position + foward + side) ;
       // rb.transform.position = (rb.transform.position + side);

       
            
            
        
       
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            m_IsGrounded = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            m_IsGrounded = false;
        }
    }
}
