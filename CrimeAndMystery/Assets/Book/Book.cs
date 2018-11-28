using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour {

 
    public GameObject cover,page,back;
    public TextAsset text;
    private Text uiText1, uiText2, uiText3, uiText4;

    void Start () {

          uiText1 = transform.Find("cover/bookPart/FirstCanvas/FirstText").GetComponent<Text>();
         // parentRect = transform.Find("cover/bookPart/FirstCanvas/FirstText").GetComponent<RectTransform>();
          uiText2 = transform.Find("Page/page1/Page1Canvas/Page1Text").GetComponent<Text>();
          uiText3 = transform.Find("Page/page2/Page2Canvas/Page2Text").GetComponent<Text>();
          uiText4 = transform.Find("Back/bookPart/LastCanvas/LastText").GetComponent<Text>();
      
	}
	
	// Update is called once per frame
	void Update () {

	
    
	}
}

