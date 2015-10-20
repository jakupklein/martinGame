using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int zombieCount;


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
    }
}
