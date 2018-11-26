using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPage : MonoBehaviour {

    //public float zRotation = 0.00f;
    //public float zRotation1 = -181.0f;
    //public float zRotation2 = -180.0f;
   // public float CurrentZ = 0.0f;
    public float RotationSpeed = 2.0f;
    
    int i = 0;
    //private float rotateF, rotateB;

    // Use this for initialization
    void Start () {
       
      
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(""  + transform.childCount);
       

       if( i < transform.childCount && transform.childCount > 0)
        {


            if (Input.GetKey(KeyCode.K) && transform.GetChild(i).eulerAngles.z < 180)
            {
                transform.GetChild(i).Rotate(0, 0, RotationSpeed);

                if (transform.GetChild(i).eulerAngles.z > 179 && i < transform.childCount -1)
                    i++;

                Debug.Log("i" + i);
                Debug.Log("euler" + transform.GetChild(i).eulerAngles.z);
            }


            if (Input.GetKey(KeyCode.L) && transform.GetChild(i).eulerAngles.z > 1)
            {



                transform.GetChild(i).Rotate(0, 0, -RotationSpeed);
                Debug.Log("L" + transform.eulerAngles.z);
                if (transform.GetChild(i).eulerAngles.z < 2 && i > 0)
                    i--;

            }

          
        }

      //  transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(transform.eulerAngles.z, 0, 180));
    }
   
}
