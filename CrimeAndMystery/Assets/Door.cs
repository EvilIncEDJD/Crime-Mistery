using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	 Animator anime;
	public float openDistance = 10f;
	private bool closed ;
	private GameObject Player;
	private OpenDoor door;
	
	
	
	
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		anime= GetComponent<Animator>();
		door =Player.GetComponent<OpenDoor>();
	}
	
	

public bool Closed{get {return closed;} set{closed = value;}}

public void CoOpen()
{
	StartCoroutine(Open());
}

public void CoClose()
{
	StartCoroutine(Close());
}

public IEnumerator Open() 
{
   				anime.Play("Open");
				Debug.Log("1");
				yield return new WaitForSeconds(anime.GetCurrentAnimatorStateInfo(0).length);
				closed = true;
					
					
}
public IEnumerator Close() 
{
	
   					anime.Play("Close");
					Debug.Log("0");
					yield return new WaitForSeconds(anime.GetCurrentAnimatorStateInfo(0).length);
					closed = false;
					
					
					
}

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
   				anime.Play("OpenA");
				Debug.Log("1");
				yield return new WaitForSeconds(anime.GetCurrentAnimatorStateInfo(0).length);
				closed = true;
					
					
}
public IEnumerator CloseA() 
{
   					anime.Play("CloseA");
					Debug.Log("0");
					yield return new WaitForSeconds(anime.GetCurrentAnimatorStateInfo(0).length);
					closed = false;
					
					
					
}



 }