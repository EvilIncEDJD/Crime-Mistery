using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMENU1 : MonoBehaviour {

  

    public void PlayGame(int sceneindex)
    {

        SceneManager.LoadScene(sceneindex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
