using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	bool onDoor = false;
	bool onDoorA = false;
	bool onLight = false;
	private Door door;
	private ArmarioDoor doorA;
	private candeeiro doorL;
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
			else onDoor = false;

			if(hit.collider.gameObject.tag == "Armario")
			{
				onDoor = true;

				doorA = hit.collider.gameObject.GetComponentInParent<ArmarioDoor>();
					if(Input.GetButton("Pick") == true && doorA.Closed == false)
					{
						
						
					doorA.CoOpenA();
					
				
					}
					if(Input.GetButton("Pick") == true && doorA.Closed == true)
					{

						doorA.CoCloseA();
						
						
						
					}

					if(doorA.Closed == false)
					close = true;
					else if ((doorA.Closed == true))
					close = false;

			}
			else onDoor = false;

			if(hit.collider.gameObject.tag == "Light")
			{
				onDoor = true;

				doorL = hit.collider.gameObject.GetComponentInParent<candeeiro>();
					if(Input.GetButton("Pick") == true && doorL.Closed == false)
					{
						
						
					doorL.CoOpenL();
					
				
					}
					if(Input.GetButton("Pick") == true && doorA.Closed == true)
					{

						doorL.CoCloseL();
						
						
						
					}

					if(doorL.Closed == false)
					close = true;
					else if ((doorL.Closed == true))
					close = false;

			}
			else onDoor = false;

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
		
    }
	


}


