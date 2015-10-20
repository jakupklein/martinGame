using UnityEngine;
using System.Collections;
using System;

public class Rotator : MonoBehaviour {

    public Rigidbody hinge;
    private Quaternion tarAngle;
    public float rotSpeed = 0.5f;
    //public float rotAngle = 180f;

    
    
    void FixedUpdate()
    {
        
            transform.Rotate(Vector3.up * rotSpeed);
        
        
        
    }

    public void RotateThings(float rotAngle, float rotSpeed)
    {
        tarAngle = Quaternion.Euler(0, rotAngle, 0);
        hinge.transform.localRotation = Quaternion.Slerp(hinge.transform.localRotation, tarAngle, Time.deltaTime * rotSpeed);

    }

    
}
