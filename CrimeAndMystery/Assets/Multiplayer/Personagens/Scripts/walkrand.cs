using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class walkrand : MonoBehaviour {

	  public float wanderRadius = 10f;
    public float wanderTimer = 2f;
	 private float timer;
	 public Animator animator;
     private Door door;
	  private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		
	}
	void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        timer = wanderTimer;
    }
	// Update is called once per frame
	void Update () {
		Patrol();

        RaycastHit hit;
        	if(Physics.Raycast(transform.position, Vector3.forward,out hit, 2))
            {
                if(hit.collider.gameObject.tag == "Porta")
                {
                    door = hit.collider.gameObject.GetComponentInParent<Door>();
					if(door.Closed == false)
					{
						
						
					        door.CoOpen();
					
				
					}

                   
                }
			
            }
	}

	 void Patrol()
    {
        timer += Time.deltaTime;
        Walk();
        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

	public void Walk()
    {
        animator.Play("Walk");
    }
}
