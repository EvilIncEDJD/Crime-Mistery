using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    public Animator animator;
    public GameObject player;
    public GameObject head;
    public GameObject FirstPersonCamera;
    //public Texture2D mira;
    public Texture mira;
    public Texture look;
    private GUI DrawTexture;
    private float yaw1, yaw = 0.0f;
    private float pitch, pitchfirst = 0.0f;
    public float speed;


    //public Transform player;
    public float distance = 2f;
    public float height = 1f;

    private Vector3 offsetX;
    private Vector3 offsetY;
    private Vector3 offset;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
    public float yMinLimitfirst = -90f;
    public float yMaxLimitfirst = 60f;
    public float xMinLimit = -90f;
    public float xMaxLimit = 60f;
    private float xMinLimit1;
    public float xMaxLimit1;


    public float distanceMin = 4f;
    public float distanceMax = 15f;

    public float pickUpDistance = 10f;

    private bool collide;
    [HideInInspector]
    public bool zoom;
    private Vector3 playerPosition;
    public float ecra;
    public float rotateSpeed = 20.0f;

    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    

    // Use this for initialization
    void Start()
    {
        animator = player.GetComponent<Animator>();
        FirstPersonCamera.gameObject.active = true;
        playerPosition = player.transform.position;
        Vector3 angles = transform.eulerAngles;
        pitch = angles.y;
        yaw = angles.x;
        collide = false;
        
    

    }

    private void LateUpdate()
    {

        if (zoom == false)
        { 
        pitchfirst -= Input.GetAxis("Mouse Y") * speed;

        pitchfirst = ClampAngle(pitchfirst, yMinLimitfirst, yMaxLimitfirst);

        yaw += Input.GetAxis("Mouse X") * speed;
        }
       
            player.transform.eulerAngles = new Vector3(0, yaw, 0);
            head.transform.eulerAngles = new Vector3(pitchfirst, yaw, 0.0f);
        

        


       

       /* pitch -= Input.GetAxis("Mouse Y") * speed;

        pitch = ClampAngle(pitch, yMinLimit, yMaxLimit);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin - 1, distanceMax);
        if (distance == distanceMin - 1)
        {
            FirstPersonCamera.gameObject.active = true;
            
        }
        else
        {
            FirstPersonCamera.gameObject.active = true;
           
        }

        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 heighten = new Vector3(0.0f, height, 0.0f);
        Vector3 position = rotation * negDistance + player.transform.position + heighten;*/
    }


    // Update is called once per frame
    void Update()
    {
        // Interact with the item
        
        Ray ray = Camera.main.ScreenPointToRay(Camera.main.transform.position);
        RaycastHit hit;
        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickUpDistance) && hit.collider.gameObject.tag == "Item")
        {

            collide = true;
         
        }
        else
        {

            collide = false;

        }

        if (collide == true)//AQUI O JOGADOR N PODE SE MEXER
        {
            if(Input.GetButton("Pick") == true || zoom == true)
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                hit.collider.gameObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
                // hit.collider.gameObject.transform.parent = tempParent.transform;

                /* item.gameObject.GetComponent<Rigidbody>().useGravity = false;
                 item.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                 item.gameObject.transform.position = guide.transform.position;
                 item.gameObject.transform.parent = tempParent.transform;*/
                // gameObject.transform.position = playerPosition + new Vector3(0.5f, 1.0f, 0.5f );

                if (Input.GetButton("Fire2"))
                {
                    zoom = true;


                }
                else zoom = false;

                if(zoom == true)
                {
                    Camera.main.fieldOfView = 30;
                    hit.collider.gameObject.transform.Rotate(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0);
                    /*hit.collider.gameObject.transform.Rotate(Vector3.up, -(Input.GetAxis("Mouse X")*Mathf.Deg2Rad * rotateSpeed));
                    hit.collider.gameObject.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * Mathf.Deg2Rad * rotateSpeed);*/
                }
                else Camera.main.fieldOfView = 60;

            }
            else //if(Input.GetButtonDown("Pick") == false)
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                /*item.gameObject.GetComponent<Rigidbody>().useGravity = true;
                item.gameObject.GetComponent<Rigidbody>().isKinematic = false;*/
                // hit.collider.transform.position = guide.transform.position;
                // hit.collider.transform.parent = null;
            }



            // else Camera.main.fieldOfView = 60;
        }


      

    }


    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
    void OnGUI()
    {
        Cursor.visible = false;
       if(collide == true) 
            GUI.DrawTexture(new Rect(Screen.width / 2 - mira.width / ecra, Screen.height / 2 - mira.height / 2, mira.width, mira.height), look);
       else  
            GUI.DrawTexture(new Rect(Screen.width / 2 - mira.width / 2, Screen.height / 2 - mira.height / 2, mira.width, mira.height), mira);
              
    }
}
