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
    public Button startButton;


    void Awake()
    {
        
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
           
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            particlesScript.ParticlesPlay(transform.position);
            killPlayer();
            Invoke("SpawnPlayer", 2f);
            //Invoke("killPlayer", 0.5F);


        }
    }

   

    void killPlayer()
    {

        loseText.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }

    public void SpawnPlayer()
    {
        loseText.gameObject.SetActive(false);
        gameObject.SetActive(true);
        transform.position = spawnPos.transform.position;
        Time.timeScale = 1;
        startButton.gameObject.SetActive(false);

    }
}
