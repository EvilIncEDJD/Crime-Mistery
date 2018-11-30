using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candeeiro : MonoBehaviour {

		public float openDistance = 10f;
		private bool closed ;
		private GameObject Player;
		private GameObject cand;
		private OpenDoor doorL;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		cand = GameObject.FindGameObjectWithTag("Light");
		doorL =Player.GetComponent<OpenDoor>();
		
	}
	
		public bool Closed{get {return closed;} set{closed = value;}}

	public void CoOpenL()
	{
		StartCoroutine(OpenL());
	}

	public void CoCloseL()
	{
		StartCoroutine(CloseL());
	}

	public IEnumerator OpenL() 
	{
					cand.SetActive(true);
					Debug.Log("1");
					yield return new WaitForSeconds(1);
					closed = true;
						
						
	}
	public IEnumerator CloseL() 
	{
						cand.SetActive(false);
						Debug.Log("0");
						yield return new WaitForSeconds(1);
						closed = false;
						
						
						
	}

}
