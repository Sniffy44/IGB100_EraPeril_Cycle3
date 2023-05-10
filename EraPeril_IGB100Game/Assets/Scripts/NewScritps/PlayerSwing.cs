using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSwing : MonoBehaviour{

    public static Action swingInput;

    private void Update(){
        if (Input.GetMouseButton(0)){
            swingInput?.Invoke();
        }
    }

    


}
