using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiTree : MonoBehaviour {

	Animator animator;
	NavMeshAgent agent ;
	BTSelector myTree;
	void Start () {
		
		animator = GetComponent<Animator>();
		 agent = GetComponent<NavMeshAgent>();

			 myTree = new BTSelector(new List<BTNode>() 
		
				{ new BTSequence(new List<BTNode>()
				{
						new AmITired(transform), new Sit(transform,animator,agent)
				}), 
				new BTSequence(new List<BTNode>()
				{
						new AmIBored(transform), new SeePainting(transform,animator,agent)
				})

				});
	}
	
	// Update is called once per frame
	void Update () {

			myTree.Tick();

	}
}
