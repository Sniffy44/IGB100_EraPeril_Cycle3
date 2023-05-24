using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Static Variable", menuName = "Static Variable")]
public class LevelData : ScriptableObject{
    
    public int level = 0;
    public int passHealth_Player;
    public int passHealth_Escortee;

    //[HideInInspector]
    



}
