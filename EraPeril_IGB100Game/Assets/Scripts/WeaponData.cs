using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject{
    
    public new string name;
    public int damage;
    public int swingTime;
    public bool isThrowable;

    [HideInInspector]
    public bool isAttacking;



}
