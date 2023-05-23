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
    private Transform player;

    public float howclose;

    public AudioClip hitSound;
    public AudioClip deathSound;

    public bool hasDied = false;

    public Rigidbody rb;
    public GameObject medkit;

    private int killCount;
    public static int enemiesLeft;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        enemiesLeft = Spawners.level1enemySpawnMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasDied) enemy.SetDestination(player.position);

        if(health <= 0 && !hasDied){
            hasDied = true;
            Die(); 
            Invoke("Destroy", 5f);
        }
 
    }

    public void Hit(int damage)
    {
        health -= damage;
        AudioSource audioC = GetComponentInParent<AudioSource>();
        audioC.PlayOneShot(hitSound, 1f);
    }

    public void Die(){
        rb.velocity = new Vector3(0,0,0);
        AudioSource audioC = GetComponentInParent<AudioSource>();
        audioC.PlayOneShot(deathSound, .7f);

        killCount ++;
        enemiesLeft--;

        if(enemiesLeft == 0) SpawnMedkit(rb.position);
    }

    public void Destroy(){
        //Instantiate(BloodPrefab, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
        //ScoreScript.scoreValue += 10;

    }

    public void SpawnMedkit(Vector3 pos){
        Debug.Log("medkit tryin spawn");
        Instantiate(medkit, pos + new Vector3(0,3,0), Quaternion.identity);
    }

    

    
}
