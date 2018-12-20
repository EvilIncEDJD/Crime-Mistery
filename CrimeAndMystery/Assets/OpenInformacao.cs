using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInformacao : MonoBehaviour {

	public GameObject policeUI;
	public static bool policeUIOpen = false;
	public GameObject textUI;
	
	
	
	// Use this for initialization
	void Start () {
		
		policeUI.SetActive(false);
	}
	
	void OnTriggerStay(Collider other){
		policeUI.SetActive(true);
		
		
	}
	void OnTriggerExit(){
		
		policeUI.SetActive(false);
		Destroy(this);
		
	}
}
