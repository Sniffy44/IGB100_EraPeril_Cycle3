using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{

    private int clipID;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;

    private float audioPlayedAtTime;
    private float timeSinceLastAudioPlay;

    public float frequencyTopRange = 450;
    
    void Start()
    {
        //AudioSource audioC = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update(){

        timeSinceLastAudioPlay = Time.time - audioPlayedAtTime;

    
        if(Random.Range(0,450) == 5 && timeSinceLastAudioPlay > 2 && 
                        GetComponent<Enemy>().hasDied == false){
            audioPlayedAtTime = Time.time;
            clipID = Random.Range(0,4); // random num of 0, 1, 2, or 3  NOT 4
            PlaySoundClip(clipID);

        }
    }

    private void PlaySoundClip(int audioClipID){
        AudioSource audioC = GetComponent<AudioSource>();
        if(audioClipID == 0){
            audioC.PlayOneShot(audioClip1, 3.0f);
        }
        if(audioClipID == 1){
            audioC.PlayOneShot(audioClip2, 3.0f);
        }
        if(audioClipID == 2){
            audioC.PlayOneShot(audioClip3, 3.0f);
        }
        if(audioClipID == 3){
            audioC.PlayOneShot(audioClip4, 3.0f);
        }
        
    }
}
