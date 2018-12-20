using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	 Animator anime;
	public float openDistance = 10f;
	private bool closed ;
	private GameObject Player;
	private OpenDoor door;
	public float speed = 3;
	float value;
	public AudioSource portaSound;

	private void Update() {
	
		 
	}
	
	
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		portaSound = GetComponent<AudioSource>();
		anime= GetComponent<Animator>();
		door =Player.GetComponent<OpenDoor>();
		value = transform.eulerAngles.y +0.1f;
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
				portaSound.Play();
				while(transform.eulerAngles.y < value + 89)
				{
					
   				transform.Rotate(Vector3.up *0.8f);
				  

				yield return null;
				}
				closed = true;
					Debug.Log(closed);
				
					
}
public IEnumerator Close() 
{
				portaSound.Play();
   				
   				while(transform.eulerAngles.y > value)
				{
					
   				transform.Rotate(Vector3.up *-0.8f);
				
				yield return null;
				}
					closed = false;
						Debug.Log(closed);
					
					
					
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