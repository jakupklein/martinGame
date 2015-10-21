using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YouDead : MonoBehaviour {


    public GameObject particles;
    public bool dead = false;
    private PlayParticles particlesScript;
    private float lifes;
    public GameObject spawnPos;
    public Text  loseText;


    void Awake()
    {
        loseText.enabled = false;
    }

    void Start()
    {
        
       
        particlesScript = particles.GetComponent<PlayParticles>();
    }


    void Update()
    {
       
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Zombie")
        {
            dead = true;
            loseText.enabled = true;
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            particlesScript.ParticlesPlay(transform.position);
            killPlayer();
            Invoke("SpawnPlayer", 2f);
            //Invoke("killPlayer", 0.5F);


        }
    }

   

    void killPlayer()
    {

       
       
        gameObject.SetActive(false);
    }

    void SpawnPlayer()
    {
        loseText.enabled = false;
        gameObject.SetActive(true);
        transform.position = spawnPos.transform.position;
        
    }
}
