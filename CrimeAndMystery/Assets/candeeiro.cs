using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candeeiro : MonoBehaviour {

		private bool oN = true;
		Light obLight;
	// Use this for initialization
	void Start () {
		
			
			obLight = transform.GetComponentInChildren<Light>();

	
	}
	 void Update() {
	
	}

	public void TurnLightOff()
	{
		StartCoroutine(LightsOff());
	}
	public void TurnLightOn()
	{
		StartCoroutine(LightsOn());
	}
	public IEnumerator LightsOff() 
	{
	
			obLight.enabled = false;
			yield return new WaitForSeconds(0.1f);
			oN = false;

	}
	public IEnumerator LightsOn() 
	{
	
			obLight.enabled = true;
			yield return new WaitForSeconds(0.1f);
			oN = true;

	}


	public bool On{get {return oN;} set{oN = value;}}
	public Light LightOn{get {return obLight;} set{obLight = value;}}
}

	