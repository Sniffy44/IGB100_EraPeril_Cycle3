using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitMenu : MonoBehaviour
{
    public GameObject medkitMenuUI;
    private GameObject medkit;
    private GameObject player;
    private GameObject escortee;


    public void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        escortee = GameObject.FindGameObjectWithTag("Escortee");
    }
    public void Update(){
        medkit = GameObject.FindGameObjectWithTag("Medkit");

        
        if(medkit != null) medkitMenuUI.SetActive(medkit.GetComponent<Medkit>().medMenuOpen);
        
        
    }

    public void MedkitToPlayer(){
        Debug.Log("player heal");
        
        player.GetComponent<PlayerHealth>().AddHealth(medkit.GetComponent<Medkit>().healAmount);
        medkit.GetComponent<Medkit>().medMenuOpen = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Destroy(medkit);
        
    }

    public void MedkitToEscortee(){
        Debug.Log("escort heal");
        
        escortee.GetComponent<Escortee>().AddHealth(medkit.GetComponent<Medkit>().healAmount);
        medkit.GetComponent<Medkit>().medMenuOpen = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Destroy(medkit);
    }

}
