using UnityEngine;
using System.Collections;

public class FireFists : MonoBehaviour {

    public GameObject rightFist, leftFist, rightBullet, leftBullet, rightArm, leftArm, leftHand, rightHand;
    public float bulletForce;
    private Vector3 orRightArmPos, orLeftArmPos, leftHandInitialScale, rightHandInitialScale;
    private float rightArmRecoilWeight, leftArmRecoilWeight;
    private GameObject gMO;
    private GameManager gM;

    void Start()
    {
        orRightArmPos = rightArm.transform.localPosition;
        orLeftArmPos = leftArm.transform.localPosition;
        leftHandInitialScale = leftHand.transform.localScale;
        rightHandInitialScale = rightHand.transform.localScale;
        gMO = GameObject.Find("GameManager");
        gM = gMO.GetComponent<GameManager>();
    }

    void Update() {
        float multiplierRight = 1f + GameManager.speedIncrementRight * 7f;
        float multiplierLeft = 1f + GameManager.speedIncrementLeft * 7f;
        rightArmRecoilWeight = Mathf.Clamp(rightArmRecoilWeight - Time.deltaTime * multiplierRight, 0, 1f);
        leftArmRecoilWeight = Mathf.Clamp(leftArmRecoilWeight - Time.deltaTime * multiplierLeft, 0, 1f);

        if (Input.GetMouseButtonDown(0) && Mathf.Approximately(orRightArmPos.x, rightArm.transform.localPosition.x) )
        {
            FireRightBullet();
            
        }

        if (Input.GetMouseButtonDown(1) && Mathf.Approximately(orLeftArmPos.x, leftArm.transform.localPosition.x))
        {
            FireLeftBullet();
        }
        
        rightArm.transform.localPosition = Vector3.Lerp(orRightArmPos, orRightArmPos - new Vector3(0.5f, 0, 0), rightArmRecoilWeight);
        rightHand.transform.localScale = Vector3.Lerp(rightHandInitialScale, Vector3.zero, rightArmRecoilWeight);

        leftArm.transform.localPosition = Vector3.Lerp(orLeftArmPos, orLeftArmPos - new Vector3(0.5f, 0, 0), leftArmRecoilWeight);
        leftHand.transform.localScale = Vector3.Lerp(leftHandInitialScale, Vector3.zero, leftArmRecoilWeight);

    }


    void FireRightBullet()
    {
        rightArmRecoilWeight = 1;
        //rightArm.transform.position = Vector3.Lerp(rightArm.transform.position, rightArm.transform.position - new Vector3(0.2f, 0, 0), 0.1f);
        GameObject rightProj = Instantiate(rightBullet, rightFist.transform.position, rightFist.transform.rotation) as GameObject;
        rightProj.transform.position = rightProj.transform.position + rightFist.transform.forward ;
        Rigidbody rbRight = rightProj.GetComponent<Rigidbody>();
        rbRight.velocity = rightFist.transform.forward * bulletForce;
    }

    void FireLeftBullet()
    {
        leftArmRecoilWeight = 1;
        GameObject leftProj = Instantiate(leftBullet, leftFist.transform.position, leftFist.transform.rotation) as GameObject;
        leftProj.transform.position = leftProj.transform.position + leftFist.transform.forward;
        Rigidbody rbLeft= leftProj.GetComponent<Rigidbody>();
        rbLeft.velocity = leftFist.transform.forward * bulletForce;
    }



}
