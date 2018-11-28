using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour {

    // Use this for initialization
       
    
    public  TextAsset textAsset;
    static List<string> listText = new List<string>();
    
    private Text uiText1, uiText2, uiText3, uiText4, text;
    public int linePerPage;

    private RectTransform parentRect;
    private float longestCharWidth = 50;
    //public string filename;

    void Start () {
        
         uiText1 = transform.Find("cover/bookPart/FirstCanvas/FirstText").GetComponent<Text>();
       // parentRect = transform.Find("cover/bookPart/FirstCanvas/FirstText").GetComponent<RectTransform>();
        uiText2 = transform.Find("Page/page1/Page1Canvas/Page1Text").GetComponent<Text>();
          uiText3 = transform.Find("Page/page2/Page2Canvas/Page2Text").GetComponent<Text>();
          uiText4 = transform.Find("Back/bookPart/LastCanvas/LastText").GetComponent<Text>();
        InputField inputField = gameObject.GetComponent<InputField>();
          text = inputField.textComponent;
       // textAsset = Resources.Load(filename) as TextAsset;
       CountLine();

                parentRect = GetComponent<RectTransform>();
                
               
      
    }
	
	// Update is called once per frame
	void Update ()
    {
        

    }

    public void CountLine()
    {
        
         listText = textAsset.text.Split('\n').ToList();
         for(int i = 0; i < listText.Count(); i++)
         {
             
               uiText1.text += listText[i] + "\n" ;
             
         }
        
       /*  uiText1.text = listText[1];
        uiText1.text = listText[2];
        uiText1.text = listText[3];
        uiText1.text = listText[4];
        uiText1.text = listText[5];*/

     
    }

     

    

    protected bool CheckTextWidth()
    {
        float textWidth = LayoutUtility.GetPreferredWidth(uiText1.rectTransform); //This is the width the text would LIKE to be
        float parentWidth = parentRect.rect.width; //This is the actual width of the text's parent container

        return (textWidth > (parentWidth - longestCharWidth)); //is the text almost too wide?  Stop when the next character could be too wide
    }
}
