using UnityEngine;
using System.Collections;

public class FistBehaviour : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {

        Destroy(gameObject);

    }

}
