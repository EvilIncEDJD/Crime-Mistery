using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerControllerMaze : MonoBehaviour {

	 public GameObject guiObj;
     public string lvlToLoad;
     public GameObject entradaMaze;

	// Use this for initialization
	void Start () {
        guiObj.SetActive(false);
        entradaMaze.SetActive(false);
	}

   
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObj.SetActive(true);
            entradaMaze.SetActive(true);
            //if ( Input.GetKeyDown(KeyCode.Space))
            //{
                SceneManager.LoadScene(lvlToLoad);
                
            //}

        }

        
    }

    void OnTriggerExit()
    {
        guiObj.SetActive(false);
    }

	

}
