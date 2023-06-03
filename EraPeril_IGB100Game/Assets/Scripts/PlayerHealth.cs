using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configurations")]
    public int maxHealth = 100;
    public int health = 100;

    public HealthBar healthBar;
    //public GameObject audioObject;

    public AudioSource audio_heartbeat;

    public AudioClip owSound;

    private bool healthLow = false;

    //public AudioClip audioClip_heartBeat;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        audio_heartbeat.enabled = healthLow;
    }

    public void AddHealth (int amount)
    {
        health += amount;
        if(health > maxHealth){
            health = maxHealth;
        }
        if(health >= 25){
            healthLow = false;
        }
        healthBar.SetHealth(health);
        //Debug.Log("Health Increased, Current Health: " + health);
    }

    public void DecreaseHealth(int amount)
    {
        health -= amount;

        AudioSource audioC = GetComponentInChildren<AudioSource>();
        audioC.PlayOneShot(owSound, .7f);

        if(health < 25){
            healthLow = true;
            //AudioSource audioC = audioObject.GetComponent<AudioSource>();
            //audioC.PlayOneShot(audioClip_heartBeat, 1f);
        }
        
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(6);
            //Debug.Log("Player is dead!");
        }
    }
}
