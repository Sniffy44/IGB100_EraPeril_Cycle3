using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Configurations")]
    public float health;
    public int damage;

    private PlayerController playerHealth;

    public NavMeshAgent enemy;
    public Transform Player;

    public float howclose;

    public AudioClip hitSound;
    public AudioClip deathSound;

    private bool hasDied = false;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);

        if(health <= 0 && !hasDied){
            hasDied = true;
            DieSound();
            Invoke("Die", 0.5f);
        }

        
    }

    public void Hit(int damage)
    {
        health -= damage;
        AudioSource audioC = GetComponentInParent<AudioSource>();
        audioC.PlayOneShot(hitSound, 1f);
    }

    public void Die()
    {
        //Instantiate(BloodPrefab, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
        //ScoreScript.scoreValue += 10;

    }

    public void DieSound(){
        AudioSource audioC = GetComponentInParent<AudioSource>();
        audioC.PlayOneShot(deathSound, .7f);
    }

    
}
