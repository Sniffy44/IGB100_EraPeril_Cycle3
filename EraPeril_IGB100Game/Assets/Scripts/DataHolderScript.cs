using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolderScript : MonoBehaviour
{

    //public int level;
    public static int passHealth_Player = 100;
    public static int passHealth_Escortee = 100;
    
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        //public static int passHealth_Player = 100;
        //public static int passHealth_Escortee = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
