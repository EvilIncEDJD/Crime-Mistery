
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.PostProcessing;

public class NPC : MonoBehaviour {

	bool inRange = false; // to be enabled when player is within range of NPC
	bool inChat = false; // to be enable and disabled when in/out of chat window
	bool inDialogue1 = true;
	bool inDialogueLeftSubTree = false;
	bool inDialogueUpSubTree = false;
	bool inDialogueRightSubTree = false;
	[Header("Objects")]
	public GameObject npcWindow;
	public Text chatText;
	public Text leftText;
	public Text upText;
	public Text rightText;
	[Header("All Possible Dialogue Options")]
	public string greeting;
	[Header("Dialogue 1")]
	public string left1;
	public string leftResponse1;
	public string up1;
	public string upResponse1;
	public string right1;
	public string rightResponse1;
	[Header("Dialogue 1 LEFT Sub Tree")]
	public string left2;
	public string leftResponse2;
	public string up2;
	public string upResponse2;
	public string right2;
	public string rightResponse2;
	[Header("Dialogue 1 UP Sub Tree")]
	public string left3;
	public string leftResponse3;
	public string up3;
	public string upResponse3;
	public string right3;
	public string rightResponse3;
	
	public GameObject PoliceTrigger;
	private bool policeTriggerState = false;
	public Transform player;
	public Transform camerap;
	 private PostProcessingBehaviour PPB;
	

	public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
	private static bool openDialogoP = false;

	// Use this for initialization
	void Start () { 
		
		inRange = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		Debug.Log("InChat é " + inChat  );
		Debug.Log("OpenDialogoP é " + openDialogoP);
		
		if(policeTriggerState)//enquanto tiver em contacto com o policia
		{
			if(Input.GetKeyDown("e"))
			{
				if(!inChat)
				{
				npcWindow.gameObject.SetActive(true);//janela abre
				openDialogoP = true;
				chatText.GetComponent<Text>().text = greeting;
				loadDialogue1();
				}
				else
				{
				npcWindow.gameObject.SetActive(false);//janela fecha
				openDialogoP = false;
				
				
				}


			}

		//Caso a janela de dialogo esteja aberta
		if(openDialogoP){
			Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            player.GetComponent<CameraControll>().enabled = false;
			camerap.GetComponent<PostProcessingBehaviour>().enabled = true;
			
		}else 
		{
            Time.timeScale = 1f;
            player.GetComponent<CameraControll>().enabled = true;
            Cursor.visible = false;
			camerap.GetComponent<PostProcessingBehaviour>().enabled = false;
        }

		}
	}


	// primeiras mensagens
	void loadDialogue1(){
		inChat = true;
		inDialogue1 = true;
		inDialogueLeftSubTree = false;
		inDialogueUpSubTree = false;
		inDialogueRightSubTree = false;
		leftText.GetComponent<Text>().text = left1;
		upText.GetComponent<Text>().text = up1;
		rightText.GetComponent<Text>().text = right1;
	}

	// lado esquerdo 1s
	void loadDialogueLeftSubTree(){
		inDialogue1 = false;
		inDialogueLeftSubTree = true;
		inDialogueUpSubTree = false;
		inDialogueRightSubTree = false;
		leftText.GetComponent<Text>().text = left2;
		upText.GetComponent<Text>().text = up2;
		rightText.GetComponent<Text>().text = right2;
	}

	// lado esquerdo 2s
	void loadDialogueLeftSubTree2(){
		inDialogue1 = false;
		inDialogueLeftSubTree = true;
		inDialogueUpSubTree = false;
		inDialogueRightSubTree = false;
		leftText.GetComponent<Text>().text = left3;
		upText.GetComponent<Text>().text = up3;
		rightText.GetComponent<Text>().text = right3;
	}

	void loadDialogueLeftSubTree3(){
		inDialogue1 = false;
		inDialogueLeftSubTree = true;
		inDialogueUpSubTree = false;
		inDialogueRightSubTree = false;
		leftText.GetComponent<Text>().text = "";
		upText.GetComponent<Text>().text = "";
		rightText.GetComponent<Text>().text = "";
	}






	// lado baixo 1s
	void loadDialogueUpSubTree(){
		inDialogue1 = false;
		inDialogueLeftSubTree = false;
		inDialogueUpSubTree = true;
		inDialogueRightSubTree = false;
		leftText.GetComponent<Text>().text = left3;
		upText.GetComponent<Text>().text = up3;
		rightText.GetComponent<Text>().text = right3;
	}

	// lado baixo 2s
	void loadDialogueUpSubTree2(){
		inDialogue1 = false;
		inDialogueLeftSubTree = false;
		inDialogueUpSubTree = false;
		inDialogueRightSubTree = false;
		leftText.GetComponent<Text>().text = "";
		upText.GetComponent<Text>().text = "";
		rightText.GetComponent<Text>().text = "";
	}







	// lado Direito 1s
	void loadDialogueRigthSubTree(){
		inDialogue1 = false;
		inDialogueLeftSubTree = false;
		inDialogueUpSubTree = false;
		inDialogueRightSubTree = true;
		leftText.GetComponent<Text>().text = left3;
		upText.GetComponent<Text>().text = up3;
		rightText.GetComponent<Text>().text = right3;
	}

	// lado Direito 2s
	void loadDialogueRigthSubTree2(){
		inDialogue1 = false;
		inDialogueLeftSubTree = true;
		inDialogueUpSubTree = false;
		inDialogueRightSubTree = false;
		leftText.GetComponent<Text>().text = "";
		upText.GetComponent<Text>().text = "";
		rightText.GetComponent<Text>().text = "";
	}



	// if the player presses the left button at any point
	public void Left(){
		if(inDialogue1){
			chatText.GetComponent<Text>().text = leftResponse1;
			loadDialogueLeftSubTree();
		}else if(inDialogueLeftSubTree){
			chatText.GetComponent<Text>().text = leftResponse2;
			loadDialogueLeftSubTree2();
		}else if(inDialogueLeftSubTree){
			chatText.GetComponent<Text>().text = leftResponse3;
			loadDialogueLeftSubTree2();
		}
	}

	// if the player presses the up button at any point
	public void Up(){
		if(inDialogue1){
			chatText.GetComponent<Text>().text = upResponse1;
			loadDialogueUpSubTree();
		}else if(inDialogueLeftSubTree){
			chatText.GetComponent<Text>().text = upResponse2;
			loadDialogueLeftSubTree2();
		}else if(inDialogueUpSubTree){
			chatText.GetComponent<Text>().text = upResponse3;
			loadDialogueUpSubTree2();
		}
	}
		
	public void Right(){
		if(inDialogue1){
			chatText.GetComponent<Text>().text = rightResponse1;
			loadDialogueRigthSubTree();
		}else if(inDialogueRightSubTree){
			chatText.GetComponent<Text>().text = rightResponse2;
			loadDialogueRigthSubTree2();
		}else if(inDialogueRightSubTree){
			chatText.GetComponent<Text>().text = rightResponse3;
			loadDialogueRigthSubTree2();
		}
	}

	public void CloseParle(){
		CloseDialogue();
	}

	void CloseDialogue(){
		npcWindow.gameObject.SetActive(false);
		inChat = false;
		openDialogoP = false;
		
	}

	void OnTriggerStay(Collider other){
		
		policeTriggerState = true;
		inRange = true;
	}

	void OnTriggerExit(){
		
		policeTriggerState = false;
		inRange = false;
		inChat = false;
		Time.timeScale = 1f;
        player.GetComponent<CameraControll>().enabled = true;
        Cursor.visible = false;

	}

}
