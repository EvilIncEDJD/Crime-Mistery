using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmarioDoor : MonoBehaviour {

	 Animator animeA;
	public float openDistance = 10f;
	private bool closed ;
	private GameObject Player;
	private OpenDoor doorA;
	
	
	
	
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		animeA= GetComponent<Animator>();
		doorA = Player.GetComponent<OpenDoor>();
	}
	
	

public bool Closed{get {return closed;} set{closed = value;}}

public void CoOpenA()
{
	StartCoroutine(OpenA());
}

public void CoCloseA()
{
	StartCoroutine(CloseA());
}

public IEnumerator OpenA() 
{
   				animeA.Play("OpenA");
				Debug.Log("1");
				yield return new WaitForSeconds(animeA.GetCurrentAnimatorStateInfo(0).length);
				closed = true;
					
					
}
public IEnumerator CloseA() 
{
   					animeA.Play("CloseA");
					Debug.Log("0");
					yield return new WaitForSeconds(animeA.GetCurrentAnimatorStateInfo(0).length);
					closed = false;
					
					
					
}
}
