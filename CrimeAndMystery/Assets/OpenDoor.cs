using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	bool onDoor = false;
	bool onDoorA = false;
	bool onLight = false;
	private Door door;
	private candeeiro cand;
	public float openDistance = 10f;
	private bool close = true;
	// Use this for initialization
	void Start () {
			
			
	}
	
	// Update is called once per frame
	void Update () {
		
		 Ray ray = Camera.main.ScreenPointToRay(Camera.main.transform.position);
        RaycastHit hit;
        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, openDistance))
        {

			if(hit.collider.gameObject.tag == "Porta")
			{
					
					onDoor = true;

					door = hit.collider.gameObject.GetComponentInParent<Door>();
					if(Input.GetButton("Pick") == true && door.Closed == false)
					{
						
						
					door.CoOpen();
					
				
					}
					if(Input.GetButton("Pick") == true && door.Closed == true)
					{

						door.CoClose();
						
						
						
					}

					if(door.Closed == false)
					close = true;
					else if ((door.Closed == true))
					close = false;
				
			}
			
			 else if(hit.collider.gameObject.tag == "Armario")
			{
				onDoor = true;

				door = hit.collider.gameObject.GetComponentInParent<Door>();
					if(Input.GetButton("Pick") == true && door.Closed == false)
					{
						
						
					door.CoOpenA();
					
				
					}
					if(Input.GetButton("Pick") == true && door.Closed == true)
					{

						door.CoCloseA();
						
						
						
					}

					if(door.Closed == false)
					close = true;
					else if ((door.Closed == true))
					close = false;

			}
			else onDoor = false; 

			if(hit.collider.gameObject.tag == "Light")
			{
				onLight = true;
				Debug.Log("Light");
				cand = hit.collider.gameObject.GetComponentInParent<candeeiro>();
				if(Input.GetButton("Pick") == true && cand.On == true)
					{
						
						
					cand.TurnLightOff();
					
				
					}
					if(Input.GetButton("Pick") == true && cand.On == false)
					{
						
						
					cand.TurnLightOn();
					
				
					}
				
			}

			else onLight = false;
		}
	}

	public bool Close{get{return close;} set{close = value;}}
	public bool OnDoor{get{return onDoor;} set{onDoor = value;}}

void OnGUI()
    {
		if(onDoor == true)
		{
			if(close ==true)
			{
 				 GUI.Label(new Rect(Screen.width/2, Screen.height/2, 200, 25), "Open");
			}
      		
      		 else if(close == false)
	 		  {
		   		 GUI.Label(new Rect(Screen.width/2, Screen.height/2, 200, 25), "Close");
	  		 }
		}

		if(onLight == true)
		{
			 GUI.Label(new Rect(Screen.width/2, Screen.height/2, 200, 25), "Light");
		}
		
    }
	


}


