using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject{
    
    public new string name;
    public GameObject weaponModelObject;
    public int damage;
    public int swingTime;
    public bool isThrowable;
    public AudioClip attackAudioClip;

    [HideInInspector]
    public bool isAttacking;
    public bool canBeSwung = true;



}
