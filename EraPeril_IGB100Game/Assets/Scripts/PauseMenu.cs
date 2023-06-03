using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gamePaused = false;

    public GameObject pauseMenuUI;

    private GameObject player;
    private GameObject escortee;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        escortee = GameObject.FindGameObjectWithTag("Escortee");
    }

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

        if(player != null && player.GetComponent<PlayerController>().lookingAtMedkit){
            MedkitMenu();
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
        //DataHolderScript.passHealth_Player = player.GetComponent<PlayerHealth>().maxHealth; 
        //DataHolderScript.passHealth_Escortee = escortee.GetComponent<Escortee>().maxHealth;
        SceneManager.LoadScene(0);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public void QuitGame(){
        Debug.Log("wowza Quit was pressed");
        Application.Quit();
    }

    private void MedkitMenu(){

    }
}
