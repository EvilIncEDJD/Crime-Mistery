using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCenCrime : MonoBehaviour {

	public GameObject textoU;
	
	
	
	// Use this for initialization
	void Start () {
		
		textoU.SetActive(false);
	}
	
	void OnTriggerStay(Collider other){
		textoU.SetActive(true);
		
		
	}
	void OnTriggerExit(){
		
		textoU.SetActive(false);
		
		
	}
}
