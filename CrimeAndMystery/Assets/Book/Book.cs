using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {

    // Use this for initialization

    
    public List<Page> bookPage = new List<Page>();

    void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class Page
{

    public GameObject page;

}
