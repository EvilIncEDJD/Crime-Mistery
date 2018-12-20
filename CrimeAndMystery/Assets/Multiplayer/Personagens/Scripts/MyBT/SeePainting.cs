using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeePainting : BTNode {

	GameObject[] objects;
	Transform play;
    Animator animator;
    GameObject maisPerto;
    NavMeshAgent agent ;
	StatsAi stats; 

    public SeePainting(Transform play,Animator animator, NavMeshAgent agent)
    {
            objects = GameObject.FindGameObjectsWithTag("Painting");
            agent = play.GetComponent<NavMeshAgent>();
			animator = play.GetComponent<Animator>();
			stats = play.GetComponent<StatsAi>();
            this.play = play;
			this.animator = animator;
            this.agent = agent;
			
    }

    public override EstadoNode Tick()
    {
				
             if(DistanceFrom(play,Closest(play,objects)) < 3f)
			 {
				Stop();
				agent.isStopped = true;
				play.transform.LookAt(Closest(play,objects).transform);
				stats.bored = stats.bored- 50;
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