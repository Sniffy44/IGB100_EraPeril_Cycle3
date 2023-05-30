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
    private Transform escort;

    private float distToEscort;

    public float howclose;

    public AudioClip hitSound;
    public AudioClip deathSound;

    public bool hasDied = false;

    public Rigidbody rb;
    public GameObject medkit;
    public GameObject portal;
    //private Vector3 portalPos;
    public ScriptableObject levelData;

    private int killCount;
    public static int enemiesLeft;

    private bool targetingPlayerNotEscort;



    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        escort = GameObject.FindGameObjectWithTag("Escortee").transform;

        if(UnityEngine.Random.Range(1,101) >= 25){ // 75% to target player
            targetingPlayerNotEscort = true;
        } else { // 25% to tartget escortee
            targetingPlayerNotEscort = false;
        }

        //portalPos = portal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasDied) {
            if(targetingPlayerNotEscort) enemy.SetDestination(player.position);
            if(!targetingPlayerNotEscort){

                enemy.SetDestination(escort.position);
                distToEscort = Vector3.Distance(transform.position, escort.position);
                transform.LookAt(escort);
                gameObject.GetComponentInChildren<EnemyAttack>().ShouldAttackEscort(distToEscort);
            }
            
        }

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
        if(Spawners.level == 1){
            Instantiate(portal, new Vector3(0f,2.6f,30f), 
                portal.transform.rotation * Quaternion.Euler(0f,-90f,0f));
        }
        if(Spawners.level == 2){
            Instantiate(portal, new Vector3(39.8f,2.64f,0f), 
                portal.transform.rotation * Quaternion.Euler(0f,0f,0f));
        }
        if(Spawners.level == 3){
            Instantiate(portal, new Vector3(0.8f,2.65f,3f), 
                portal.transform.rotation * Quaternion.Euler(0f,0f,0f));
        }
        
        Debug.Log("portal tryin spawn");
        //portal.SetActive(true); doesnt work bruh
        //portal.transform.position += new Vector3(0, 0, -100);

    }

    

    
}
