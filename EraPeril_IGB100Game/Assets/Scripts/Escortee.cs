using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Escortee : MonoBehaviour
{
    [Header("Configurations")]
    public float health = 100;
    public float maxHealth = 100;

    //public NavMeshAgent enemy;
    private Transform player;

    public float stoppingDistance = 15;

    //public AudioClip hitSound;
    //public AudioClip deathSound;

    public Rigidbody rb;

    private float dist_toPlayer;


    // Start is called before the first frame update
    void Start()
    {
        //enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;

    }

    // Update is called once per frame
    void Update(){
        

        if(health <= 0){
            Die(); 
        }

        dist_toPlayer = Vector3.Distance(player.position, transform.position);
        if(dist_toPlayer > stoppingDistance){
            //enemy.SetDestination(player.position);
            //transform.LookAt(player);
        } else {
            // walk around
        }
    }

    public void Hit(int damage)
    {
        health -= damage;
        //AudioSource audioC = GetComponentInParent<AudioSource>();
        //audioC.PlayOneShot(hitSound, 1f);
    }

    public void Die(){
        
        //AudioSource audioC = GetComponentInParent<AudioSource>();
        //audioC.PlayOneShot(deathSound, .7f);

        //Destroy(gameObject);

    }
}
