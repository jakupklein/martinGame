using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    public GameObject openPos;
    private int inTrigger= 0;
    private Vector3 orPos;

    void Start()
    {

        orPos = transform.position;

    }

    void Update()
    {
        if (inTrigger==1)
        {
            transform.position = Vector3.Lerp(transform.position, openPos.transform.position, 0.05f);
        }else if(inTrigger == 2)
        {
            transform.position = Vector3.Lerp(transform.position, orPos, 0.05f);
        }
    }

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inTrigger = 1;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
           
            inTrigger = 2;
        }
    }
}
