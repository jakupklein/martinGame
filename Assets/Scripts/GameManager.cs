using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int zombieCount;
    public static float zombieKilled;
    public static float speedIncrementRight = 0f;
    public static float speedIncrementLeft = 0f;
    public GameObject speedBarRight, speedBarLeft;

    void Update() {

        if (zombieCount == 0)
        {
           
            
            
        }
      
    }

    public void ZombiePlus()
    {
        zombieCount++;
    }


    public void ZombieMinus()
    {
        zombieCount--;
        zombieKilled++;
        Debug.Log(zombieKilled);
    }

    public void IncreaseSpeedRight()
    {
        speedIncrementRight +=  0.02f;
        Debug.Log("speedIncrementRight = " + speedIncrementRight);
        speedBarRight.transform.localScale = new Vector3(Mathf.Clamp(speedIncrementRight, 0f, 1f), transform.localScale.y, transform.localScale.z);
    }
    public void IncreaseSpeedLeft()
    {
        speedIncrementLeft += 0.02f;
        Debug.Log("speedIncrementLeft = " + speedIncrementLeft);
        speedBarLeft.transform.localScale = new Vector3(Mathf.Clamp(speedIncrementLeft, 0f, 1f), transform.localScale.y, transform.localScale.z);
    }
}
