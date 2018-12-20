using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sit : BTNode {
    
	GameObject[] objects;
	Transform play;
    Animator animator;
    GameObject maisPerto;
    NavMeshAgent agent ;


    public Sit(Transform play,Animator animator, NavMeshAgent agent)
    {
            objects = GameObject.FindGameObjectsWithTag("Chair");
            agent = play.GetComponent<NavMeshAgent>();
			animator = play.GetComponent<Animator>();
		
            this.play = play;
			this.animator = animator;
            this.agent = agent;
			agent.isStopped = false;
    }

    public override EstadoNode Tick()
    {
				
             if(DistanceFrom(play,Closest(play,objects)) < 0.8f)
			 {
				 agent.isStopped = true;
				 Sitin();
				 return EstadoNode.SUCCESS;
			 }
			 else
			 {
				 agent.isStopped = false;
				 agent.destination = Closest(play,objects).transform.position;
              Debug.Log("Something");
        		Walk();

                 return EstadoNode.RUNNING;
			 }
              
          
         
        
          
         

    }

 public float DistanceFrom(Transform play,GameObject go)
    {

        float distance = Vector3.Distance(play.transform.position, go.transform.position);
        return distance;
    }

     public GameObject Closest(Transform play,GameObject[] gameObjects)
    {
     
       
        float estaDistancia =  Mathf.Infinity;
        float distance = Mathf.Infinity;

        foreach (GameObject go in gameObjects)
        {
            //Debug.Log("ob entry-> "+go.tag);
            estaDistancia = DistanceFrom(play,go);

            if (estaDistancia < distance)
            {
                maisPerto = go;
               // Debug.Log("aqui" + maisPerto.tag);
                distance = estaDistancia;
            }
        }

        return maisPerto;
    }

    public void Walk()
    {
        animator.Play("Walk");
    }

    public void Stop()
    {
        animator.Play("Idle");
    }

    public void Sitin()
    {
        animator.Play("Sit");
    }
}


