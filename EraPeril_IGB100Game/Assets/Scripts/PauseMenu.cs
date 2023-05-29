using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gamePaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){
            if(gamePaused){
                Resume();
            } else {
                Pause();
            }
        }
        if(gamePaused){
            if(Input.GetKeyDown(KeyCode.M)){
                LoadMainMenu();
            }
            if(Input.GetKeyDown(KeyCode.Q)){
                QuitGame();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMainMenu(){
        Debug.Log("wowza main menu was pressed");
        SceneManager.LoadScene(0);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public void QuitGame(){
        Debug.Log("wowza Quit was pressed");
        Application.Quit();
    }
}
