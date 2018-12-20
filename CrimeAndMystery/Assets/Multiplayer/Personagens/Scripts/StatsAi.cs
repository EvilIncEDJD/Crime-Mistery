using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsAi : MonoBehaviour {


	public float angry, hungry, thirsty, tired, bored,lonely;

	void Start () {
		

		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(angry!=0)
		angry -=  Time.deltaTime *0.1f;
		hungry += Time.deltaTime *0.2f;
		thirsty += Time.deltaTime *0.3f;
		tired += Time.deltaTime *0.1f;
		bored += Time.deltaTime *0.7f;
		lonely += Time.deltaTime *0.9f;

	}
}
