using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour{
    
[Header("Rederences")]
[SerializeField] private Transform[] weapons;

[Header("Keys")]
[SerializeField] private KeyCode[] keys;

private int selectedWeapon;

private void Start(){
    SetWeapons();
    Select(selectedWeapon);
}



private void SetWeapons(){
    weapons = new Transform[transform.childCount];

    for(int i = 0; i < transform.childCount; i++){
        weapons[i] = transform.GetChild(i);
    }

    if(keys == null) keys = new KeyCode[weapons.Length];
}


private void Update(){
    int previousSelectedWeapon = selectedWeapon;

    for(int i = 0; i < keys.Length; i++){
        if (Input.GetKeyDown(keys[i])){
            selectedWeapon = i;
        }
    }

    if(previousSelectedWeapon != selectedWeapon) Select(selectedWeapon);
}

private void Select(int weaponIndex){
    for(int i = 0; i < weapons.Length; i++){
        weapons[i].gameObject.SetActive(i == weaponIndex);
    }

    OnWeaponsSelected();

}



private void OnWeaponsSelected(){
    print("Selected new weapon..");
}









}
