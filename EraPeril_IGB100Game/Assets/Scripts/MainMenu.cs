using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     void Update(){
        if(Input.GetKeyDown(KeyCode.S)){
            PlayGame();
        }
     }
    
    public void PlayGame(){
        Spawners.level = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("S1_Tutorial");
        
    }

    public void QuitGame(){
        //Debug.Log("I Quit.");
        Application.Quit();
    }

}
