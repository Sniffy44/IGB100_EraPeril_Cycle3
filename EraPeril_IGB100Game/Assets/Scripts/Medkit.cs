using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    private GameObject player;
    private bool isLookedAt;

    public GameObject text;

    public bool medMenuOpen = false;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isLookedAt = player.GetComponent<PlayerController>().lookingAtMedkit;

        
        text.SetActive(isLookedAt);

        if(medMenuOpen){
            if(Input.GetKeyDown(KeyCode.E)) medMenuOpen = false;

        }
        if(isLookedAt && Input.GetKeyDown(KeyCode.E) && !medMenuOpen){
            medMenuOpen = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("pressed E medkit");
        }

        
        
    }
}
