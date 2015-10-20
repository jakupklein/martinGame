using UnityEngine;
using System.Collections;

public class PlayParticles : MonoBehaviour {

    private ParticleSystem particles;

    void Start()
    {
        particles = gameObject.GetComponent<ParticleSystem>();

    }


    public void ParticlesPlay(Vector3 position)
    {
        Debug.Log("particles");
        transform.position = position;
        particles.Play();
    }
}
