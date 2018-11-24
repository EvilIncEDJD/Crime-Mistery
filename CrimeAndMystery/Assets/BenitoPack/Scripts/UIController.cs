using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject notebook;
    public GameObject info;

	public static bool infoOpen = false;
	public static bool notebookOpen = false;
    
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public Transform player;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    

        

        if(notebookOpen){
            //para de mexer
            //notebook.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
             Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            player.GetComponent<CameraControll>().enabled = false;
        }else{
            Time.timeScale = 1f;
            player.GetComponent<CameraControll>().enabled = true;
            Cursor.visible = false;
        }
        OpenInfo();
		OpenNotebook();
	}

    void OpenInfo(){
         if(Input.GetKeyDown(KeyCode.O)){
             if(!infoOpen){
                    OpenInfo_();
                }
                else{
                    CloseInfo_();
                }

         }
    }

	void OpenNotebook(){
            if(Input.GetKeyDown(KeyCode.I)){
                
                if(!notebookOpen){
                    OpenNBook();
                }
                else{
                    CloseNotebook();
                }
                
            
        }
     }

    void OpenInfo_(){
        info.SetActive(true);
        infoOpen = true;
    }
    void CloseInfo_(){
         info.SetActive(false);
        infoOpen = false;
    }

     void OpenNBook(){
            notebook.SetActive(true);
            notebookOpen = true;
     }
     void CloseNotebook(){
        notebook.SetActive(false);
        notebookOpen = false;
     }
    
    
	 void FlipPag(){
		
        
	 }

    
}
