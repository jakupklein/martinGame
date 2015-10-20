using UnityEngine;
using System.Collections;

public class agentMovement : MonoBehaviour {

 	private NavMeshAgent agent;
 	private Vector3 playerLastKnownPos;
 	private GameObject player;
 	public static float curiousDistance = 2;
 	public static float chasingDistance = 5;
 	public static float chasingAngle = 30;
 	private GameObject floor;
 	private GameObject navMesh;
 	private float startHeight;
 	private QuadTest floorScript;

 	enum States{PATROLLING, STOPPING, CURIOUS, CHASING}
    private States agentState;
    void Start() {
    	startHeight = transform.position.y;

    	navMesh = GameObject.Find("NavMesh");
    	floor = GameObject.Find("Floor");
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
    	var tmpMin = floor.transform.position;
    	var tmpMax = floor.transform.position - new Vector3(floorScript.segments * floorScript.mesh_Width, 0, floorScript.segments * floorScript.mesh_Length);

    	agent.SetDestination(new Vector3(Random.Range(tmpMin.x, tmpMax.x),
    								 			 Random.Range(tmpMin.y, tmpMax.y),
    								 			 Random.Range(tmpMin.z, tmpMax.z) ));
    	//print(agent.destination);
    }

    void Update() {
    	//print(agentState);
    	switch(agentState)
    	{
    		case States.PATROLLING:
    		if(Vector3.Distance(gameObject.transform.position, player.transform.position) < curiousDistance)
    		{
    			print("is getting curious");
    			agentState = States.CURIOUS;
    			//agent.SetDestination(player.transform.position);

    		}else if(Vector3.Distance(transform.position, player.transform.position) < chasingDistance &&
    				 Vector3.Angle(transform.forward, player.transform.forward) < chasingAngle)
    		{
    			print("is goning to chase");
    			agentState = States.CHASING;
    		}else if(agent.remainingDistance < 0.5f)
    		{
    			print("is goint to stop");
    			agentState = States.STOPPING;
    		}else{
    			print("patrolling");
    		}
    		break;

    		case States.STOPPING:
    			print("stopping");
    			GoToNextPoint();
    			//agent.SetDestination(new Vector3(Random.Range(tmpMin.x, tmpMax.x),
    			//					 			 Random.Range(tmpMin.y, tmpMax.y),
    			//					 			 Random.Range(tmpMin.z, tmpMax.z) ));
    			agentState = States.PATROLLING;
    		break;

    		case States.CURIOUS:
    		print("is curious");
    			if(agent.remainingDistance < 0.5f)
    				agentState = States.STOPPING;
    		break;

    		case States.CHASING:
    		if(Vector3.Distance(transform.position, player.transform.position) < chasingDistance &&
    				 Vector3.Angle(transform.forward, player.transform.forward) < chasingAngle)
    		{
    			print("is chasing");
    			//agent.SetDestination(player.transform.position);
    		}

    		break;
    	}



    }
}
