using UnityEngine;
using System.Collections;

public class CaveSpawnsZombies : MonoBehaviour {

    public int numberOfZombiesOnStart;
    public Transform spawnPoint;
    public GameObject zombie;
    bool runOnce = true;
    
    void Awake()
    {
 

    }

    void Update()
    {
        runOnce = true;
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && runOnce)
        {
            runOnce = false;
            
            
            for (int i = 0; i < numberOfZombiesOnStart; i++)
            {
               
                zombie.transform.position = spawnPoint.position;
                Instantiate(zombie);
            }

          

        }
    }
}
