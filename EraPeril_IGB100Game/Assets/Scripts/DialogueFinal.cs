using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueFinal : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject DialogueBoxUI;
    public string[] lines;
    public float textSpeed;

    public EndGame endGameScript;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void TimerToStartFinalDialogue(){
        Invoke("BeginFinalDialogue", 1.5f);
    }

    void BeginFinalDialogue(){
        //textComponent.SetActive(true);
        DialogueBoxUI.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            NextLine();
        } else {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine(){
        foreach(char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine(){
        if(index < lines.Length - 1){
            index ++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }else{ // END GAME VICTORY
            endGameScript.Invoke("GameEndVictory", 2);
        }
    }
}
