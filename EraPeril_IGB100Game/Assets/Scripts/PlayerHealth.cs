using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configurations")]
    public int maxHealth = 100;
    public int health = 100;

    public HealthBar healthBar;
    //public GameObject audioObject;

    public AudioSource audio_heartbeat;

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

        if(health < 25){
            healthLow = true;
            //AudioSource audioC = audioObject.GetComponent<AudioSource>();
            //audioC.PlayOneShot(audioClip_heartBeat, 1f);
        }
        
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Destroy(gameObject);
            //Debug.Log("Player is dead!");
        }
    }
}
