using UnityEngine;
using System.Collections;

public class agentMovement : MonoBehaviour {

 	private NavMeshAgent agent;
 	private Vector3 playerLastKnownPos;
 	private GameObject player;
 	public static float chasingDistance = 5;
 	public GameObject floor;
 	private GameObject navMesh;
 	private float startHeight;
 	private QuadTest floorScript;
 	Vector3 curiousPosition;


 	enum States{PATROLLING, STOPPING, CURIOUS, CHASING}
    private States agentState;
    void Start() {


        startHeight = transform.position.y;

    	//navMesh = GameObject.Find("NavMesh");
    	//floor = GameObject.Find("Floor");
    	floorScript = floor.GetComponent<QuadTest>();
    	agent = GetComponent<NavMeshAgent>();
    	player = GameObject.FindWithTag("Player");
    	agentState = States.PATROLLING;
    	//var tmpMin = floor.transform.position;
    	//var tmpMax = floor.transform.position - new Vector3(floorScript.segments * floorScript.mesh_Width, 0, floorScript.segments * floorScript.mesh_Length);

    	//transform.position = new Vector3(Random.Range(tmpMin.x, tmpMax.x), 4, Random.Range(tmpMin.z, tmpMax.z) );
    	GoToNextPoint();
    	//agent.SetDestination(new Vector3(1,0,0));

    }

    void GoToNextPoint() {
    	var tmpMin = floor.transform.position - new Vector3(floor.transform.localScale.x * 10f, 0, floor.transform.localScale.z * 10f)/2;
        var tmpMax = floor.transform.position + new Vector3(floor.transform.localScale.x*10f, 0,floor.transform.localScale.z*10f)/2;

    	agent.SetDestination(new Vector3(Random.Range(tmpMin.x, tmpMax.x),
    								 			 Random.Range(tmpMin.y, tmpMax.y),
    								 			 Random.Range(tmpMin.z, tmpMax.z) ));
    	//////print(agent.destination);
    }

    void Update() {
    	//////print(agentState);
    	switch(agentState)
    	{
    		case States.PATROLLING:
    		//print("patrolling");
    		if(Vector3.Distance(transform.position, player.transform.position) < chasingDistance )
    		{
    			////print("is goning to chase");
    			agentState = States.CHASING;
    		}else if(agent.remainingDistance < 0.5f)
    		{
    			////print("is goint to stop");
    			agentState = States.STOPPING;
    		}else{
    			////print("patrolling");
    		}
    		break;
    		case States.CURIOUS:
    			agent.SetDestination(curiousPosition);
    			if(Vector3.Distance(transform.position, player.transform.position) < chasingDistance )
    		{
    			////print("is goning to chase");
    			agentState = States.CHASING;
    		}else if(agent.remainingDistance < 0.5f)
    		{
    			////print("is goint to stop");
    			agentState = States.STOPPING;
    		}
    		break;
    		case States.STOPPING:
    		//print("stopping");
    			////print("stopping");
    			GoToNextPoint();
    			//agent.SetDestination(new Vector3(Random.Range(tmpMin.x, tmpMax.x),
    			//					 			 Random.Range(tmpMin.y, tmpMax.y),
    			//					 			 Random.Range(tmpMin.z, tmpMax.z) ));
    			agentState = States.PATROLLING;
    		break;

    		case States.CHASING:
    		//print("casing");
    			agent.SetDestination(player.transform.position);
    			if(agent.remainingDistance < chasingDistance){
    				agentState = States.STOPPING;
    			}

    		break;
    	}



    }

     void OnCollisionEnter(Collision other) {
        //print("collider");
        if(other.gameObject.tag == "LeftFist" || other.gameObject.tag == "RightFist" || other.gameObject.tag == "Fist")
        {
        	print("fist");
        	curiousPosition = other.gameObject.transform.position;
        	agentState = States.CHASING;
        }
    }
}
