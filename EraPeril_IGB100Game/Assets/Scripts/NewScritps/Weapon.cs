using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{

    [SerializeField] WeaponData weaponData;

    private float swungAtTime;
    
    private void Start(){
        PlayerSwing.swingInput += Swing;

        swungAtTime = Time.time;
        weaponData.isAttacking = false;
    }

    private void Update(){
        if(weaponData.swingTime < Time.time - swungAtTime){

            weaponData.canBeSwung = true;
    
        }
    }
        

    public void Swing(){
        //Debug.Log("im swingin boi");

        if(weaponData.canBeSwung){
            weaponData.canBeSwung = false;
            weaponData.isAttacking = true;
            swungAtTime = Time.time;

        }

    }
    
}
