using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Camera playerCamera;
    public Camera endCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameEndVictory(){
        //playerCamera.SetActive(false);
        //endCamera.SetActive(true);
        //endCamera.position = new Vector3(endCamera.position.x, endCamera.position.y + 0.1f ,endCamera.position.z);
        //if(endCamera.position.y < 100) endCamera.velocity = new Vector3(0, 1, 0);
   
    }

    public void GameOver(){

        

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(6);

    }













}
