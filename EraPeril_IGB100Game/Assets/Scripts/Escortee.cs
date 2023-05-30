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
    public int health = 100;
    public int maxHealth = 100;

    private Transform player;
    private GameObject[] allEnemies;
    private Transform enemyClosest;

    public float movementDeciderDist = 10;

    public AudioClip hitSound;

    public Rigidbody rb;

    private float dist_toPlayer;
    private float fleeDistance = 20;

    public NavMeshAgent escorteeNav;

    private bool isConfident = true;

    public HealthBar healthBar;
    public AudioClip helpSound;


    // Start is called before the first frame update
    void Start()
    {
        //enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(health <= (maxHealth/2)) isConfident = false;
        
        //health = maxHealth;

    }

    // Update is called once per frame
    void Update(){
        
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(health <= 0){
            Die(); 
        }
        //ESCORT MOVEMENT PATTERNS |||||||||||||||||||||||||||||||||||||||||||
        dist_toPlayer = Vector3.Distance(player.position, transform.position);
        if(allEnemies.Length != 0){ // enemies in room

            enemyClosest = ClosestEnemy(); // finds closest enemy

            if(dist_toPlayer >= movementDeciderDist){ // far from player
                escorteeNav.SetDestination(player.position);
                transform.LookAt(player);

            } else { // standing close to player, looks at enemy
                float distToCloEnemy = Vector3.Distance(transform.position, enemyClosest.position);
                escorteeNav.ResetPath();
                transform.LookAt(enemyClosest);
                if(UnityEngine.Random.Range(0,1500) == 10 && health > (maxHealth/2)){ // confidence changer
                    if(isConfident){
                         isConfident = false;
                    } else {
                        isConfident = true;
                    }
                    
                    UnityEngine.Debug.Log("switched confidence to" + isConfident);
                    //if(health <= (maxHealth/2)) isConfident = false;               
                }
                if(isConfident){
                    escorteeNav.SetDestination(enemyClosest.position);
                } else { //not confident 

                    //escorteeNav.ResetPath();
                    if(distToCloEnemy <= fleeDistance){ // runs away from close enemy if too close
                        Vector3 dirToCloEnemy = transform.position - enemyClosest.position;
                        Vector3 fleeToPos = transform.position + dirToCloEnemy;
                        escorteeNav.SetDestination(fleeToPos);
                    }

                }
                
                gameObject.GetComponentInChildren<EscorteeAttack>().CheckDistanceToEnemy(distToCloEnemy);
                
            }
        } else { // no enemies left
            if(dist_toPlayer >= 3){
                escorteeNav.SetDestination(player.position);
                transform.LookAt(player);

            } else {
                escorteeNav.ResetPath();
                transform.LookAt(player);
            }
        }
        
        
    }

    Transform ClosestEnemy(){
        Transform closestHere = transform;
        float leastDistance = Mathf.Infinity;

        foreach (var enemy in allEnemies){
            float distanceHere = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceHere < leastDistance){
                leastDistance = distanceHere;
                closestHere = enemy.transform;
            }
            
        }
        return closestHere;
    }

    public void Hit(int damage)
    {
        health -= damage;
        AudioSource audioC = GetComponent<AudioSource>();
        audioC.PlayOneShot(hitSound, 1f);
        if(health <= (maxHealth/2)) isConfident = false;   

        if(health <= (maxHealth/4)){
            audioC.PlayOneShot(helpSound, 1f);
        }

        healthBar.SetHealth(health);
    }

    public void AddHealth (int amount)
    {
        health += amount;
        if(health > maxHealth){
            health = maxHealth;
            isConfident = true;  
        }
        //if(health >= 25){
        //    healthLow = false;
        //}
        healthBar.SetHealth(health);
        //Debug.Log("Health Increased, Current Health: " + health);
    }

    public void Die(){
        
        
        //AudioSource audioC = GetComponentInParent<AudioSource>();
        //audioC.PlayOneShot(deathSound, .7f);

        //Destroy(gameObject);

    }
}
