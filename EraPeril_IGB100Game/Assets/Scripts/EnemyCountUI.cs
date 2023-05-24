using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCountUI : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _text;

    private int textValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textValue = Enemy.enemiesLeft;


        _text.text = textValue.ToString();
    }
}
