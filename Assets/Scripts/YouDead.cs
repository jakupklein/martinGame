using UnityEngine;
using System.Collections;

public class YouDead : MonoBehaviour {


    public GameObject particles;
    public bool dead = false;
    private PlayParticles particlesScript;
    private float shrink;


    void Start()
    {

        particlesScript = particles.GetComponent<PlayParticles>();
    }


    void Update()
    {
        if (dead) { 
        shrink = Mathf.Clamp(shrink - Time.deltaTime, 0, 1f);
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, shrink*10);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Zombie")
        {
            dead = true;
            shrink = 1f;
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            particlesScript.ParticlesPlay(transform.position);
           
            
            Invoke("killPlayer", 1f);


        }
    }

   

    void killPlayer()
    {
        
        
        gameObject.SetActive(false);
    }
}
