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

    private PlayerController playerHealth;

    public NavMeshAgent enemy;
    private Transform player;

    public float howclose;

    public AudioClip hitSound;
    public AudioClip deathSound;

    public bool hasDied = false;

    public Rigidbody rb;
    public GameObject medkit;
    public GameObject portal;
    private Vector3 portalPos;
    public ScriptableObject levelData;

    private int killCount;
    public static int enemiesLeft;



    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        enemiesLeft = Spawners.level1enemySpawnMax;

        portalPos = portal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasDied) enemy.SetDestination(player.position);

        if(health <= 0 && !hasDied){
            hasDied = true;
            Die(); 
            Invoke("Destroy", 1f);
        }

       

        //Debug.Log(portal.transform.position);
        //Debug.Log(enemiesLeft);
 
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
        //enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesLeft--;

        Debug.Log(enemiesLeft);
        if(enemiesLeft == 0) {
            SpawnMedkit(rb.position);
            SpawnPortal();
        }
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

    public void SpawnPortal(){
        Instantiate(portal, new Vector3(0f,2.6f,30f), portal.transform.rotation * Quaternion.Euler(0f,-90f,0f));
        Debug.Log("portal tryin spawn");
        //portal.SetActive(true); doesnt work bruh
        //portal.transform.position += new Vector3(0, 0, -100);

    }

    

    
}
