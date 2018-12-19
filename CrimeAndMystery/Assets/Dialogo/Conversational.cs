using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Conversational : MonoBehaviour {

    public Conversation conversation;
    public Transform player;
	public Transform camerap;
	private PostProcessingBehaviour PPB;
	
	public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private static bool openDialogoP = false;
    private bool policeTriggerState = false;
    public bool inChat = false;

    //public GameObject Conversational;

    public void TriggerConversation()
    {
        ConversationManager.Instance.StartConversation(conversation);
    }
   

   void Update(){
       
        Debug.Log(Time.timeScale);
      if(policeTriggerState){
                   
            if(Input.GetKeyDown(KeyCode.E)){

                if(!inChat){

                     openDialogoP = true;
                     StartTalk();
                    
                                         
                }
                else
                {
                openDialogoP = false;
                }
               
            }
            

        //Caso a janela de dialogo esteja aberta
                if(openDialogoP){
                    Debug.Log("Dialogo Aberto");
                    
                    Time.timeScale = 0f;
                    Cursor.visible = true;
                    Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                    camerap.GetComponent<PostProcessingBehaviour>().enabled = true;
                    player.GetComponent<CameraControll>().enabled = false; 
                    player.rotation = Quaternion.Euler(player.rotation.x, player.rotation.y, player.rotation.z); 
                }
                else 
                {
                    Debug.Log("Dialogo Fechado");
                    Time.timeScale = 1f;
                    camerap.GetComponent<PostProcessingBehaviour>().enabled = false;
                    player.GetComponent<CameraControll>().enabled = true;
                    Cursor.visible = false;
                    
                }
      }
       
   }
   
    void StartTalk(){
        inChat = true;
        ConversationManager.Instance.StartConversation(conversation);
    }

    void StopTalk(){
        ConversationManager.Instance.EndConversation();
        inChat = false;
    }

    void OnTriggerStay(Collider other){
         //if(other.gameObject.tag == "Player"){
        policeTriggerState = true;
        //}
        
    }

    void OnTriggerExit(){
         
         policeTriggerState = false;
         inChat = false;
         
    
    }
}
