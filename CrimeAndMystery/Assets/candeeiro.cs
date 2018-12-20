using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candeeiro : MonoBehaviour {

		public AudioSource ligaDesligaSound;
		private bool oN = true;
		Light[] obLight;
	// Use this for initialization
	void Start () {
		
			ligaDesligaSound = GetComponent<AudioSource>();
			obLight = transform.GetComponentsInChildren<Light>();

	
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
	for(int i = 0; i < obLight.Length; i++)
	{
			ligaDesligaSound.Play();
			obLight[i].enabled = false;
	}
			yield return new WaitForSeconds(0.1f);
			oN = false;

	}
	public IEnumerator LightsOn() 
	{
	
			for(int i = 0; i < obLight.Length; i++)
	{
			ligaDesligaSound.Play();
			obLight[i].enabled = true;
	}
			yield return new WaitForSeconds(0.1f);
			oN = true;

	}


	public bool On{get {return oN;} set{oN = value;}}
	//public Light[] LightOn{get {return obLight;} set{obLight = value;}}
}

	