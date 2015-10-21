using UnityEngine;
using System.Collections;

public class ProgressFist : MonoBehaviour {

    public float maxProgress = 100f;
    public float currentProgress = 0f;
    private float speedIncrement;
    private GameObject gMO;
    private GameManager gM;

    void Start()
    {
        gMO = GameObject.Find("GameManager");
        gM = gMO.GetComponent<GameManager>();
    }


    public void IncreaseSpeed()
    {
        speedIncrement = GameManager.zombieKilled * 0.2f;
        transform.localScale = new Vector3(speedIncrement, transform.localScale.y, transform.localScale.z);
    }
}
