using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject{
    
    public new string name;
    public GameObject weaponModelObject;
    public int damage;
    public float swingTime;
    public bool isThrowable;
    public AudioClip attackAudioClip;
    public float audioVolume;

    [HideInInspector]
    public bool isAttacking;
    public bool canBeSwung = true;



}
