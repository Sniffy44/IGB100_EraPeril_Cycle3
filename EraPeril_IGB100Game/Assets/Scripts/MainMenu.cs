using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame(){
        SceneManager.LoadScene("S1_Tutorial");
        Spawners.level = 1;
    }

    public void QuitGame(){
        Debug.Log("I Quit.");
        Application.Quit();
    }

}
