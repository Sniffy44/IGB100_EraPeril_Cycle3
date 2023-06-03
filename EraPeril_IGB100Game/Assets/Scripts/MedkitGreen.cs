using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitGreen : MonoBehaviour
{
    private GameObject player;
    private GameObject escortee;
    private bool isLookedAt;

    public GameObject text;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        escortee = GameObject.FindGameObjectWithTag("Escortee");
    }

    // Update is called once per frame
    void Update()
    {
        isLookedAt = player.GetComponent<PlayerController>().lookingAtMedkit;

        
        text.SetActive(isLookedAt);

        if(isLookedAt && Input.GetKeyDown(KeyCode.E)){
            player.GetComponent<PlayerHealth>().AddHealth(250);
            escortee.GetComponent<Escortee>().AddHealth(250);
            //isLookedAt = false;
            Destroy(gameObject);
            
        }

        
        
    }
}
