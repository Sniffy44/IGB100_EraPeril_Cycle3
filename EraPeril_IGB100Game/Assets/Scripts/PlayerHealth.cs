using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configurations")]
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth (int amount)
    {
        health += amount;
        Debug.Log("Health Increased, Current Health: " + health);
    }

    public void DecreaseHealth(int amount)
    {
        health -= amount;
        //Debug.Log("Health Decreased, Current Health; " + amount);
        if (health <= 0)
        {
            Destroy(gameObject);
            //Debug.Log("Player is dead!");
        }
    }
}
