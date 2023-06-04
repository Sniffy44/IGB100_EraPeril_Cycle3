using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EvEscortee : MonoBehaviour
{
    [Header("Configurations")]
    public int health = 400;
    public int maxHealth = 400;

    private Transform player;
    //private GameObject[] allEnemies;
    //private Transform enemyClosest;

    //public float movementDeciderDist = 10;

    public AudioClip hitSound;
    public AudioClip deathSound;

    public Rigidbody rb;

    private float dist_toPlayer;
    private float fleeDistance = 20;

    public NavMeshAgent escorteeNav;

    private bool isConfident = true;
    private bool moveAround = false;

    public HealthBar healthBar;

    public Transform[] moveSpots;

    private float lastAttackTime;
    public AudioClip angrySound;

    private Transform randomMoveSpot;

    public static bool finalLevelStarted = false;

    private bool isAlive = true;

    public GameObject DialogueBox;


    // Start is called before the first frame update
    void Start()
    {
        //enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        escorteeNav.SetDestination(moveSpots[0].position);

        //health = DataHolderScript.passHealth_Escortee;
        
        //if(health <= (maxHealth/2)) isConfident = false;
        
        //health = maxHealth;

    }

    // Update is called once per frame
    void Update(){
        
        //allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
       if(isAlive){

            if(health <= 0){
                Die(); 
            }
            //ESCORT MOVEMENT PATTERNS |||||||||||||||||||||||||||||||||||||||||||
            dist_toPlayer = Vector3.Distance(player.position, transform.position);
            
            if(finalLevelStarted) transform.LookAt(player);

            if(isConfident && finalLevelStarted){ // ATTACKING
                escorteeNav.SetDestination(player.position);
                
            } else if(finalLevelStarted) { // RECEDING
                if(!moveAround){
                    Vector3 dirToPlayer = transform.position - player.position;
                    Vector3 fleeToPos = transform.position + dirToPlayer;
                    escorteeNav.SetDestination(fleeToPos);
                } else {
                    escorteeNav.SetDestination(randomMoveSpot.position);
                }
            }
            if(dist_toPlayer <= 2.5  && finalLevelStarted){ // if close, try to attack
                if(gameObject.GetComponentInChildren<EscorteeAttack>().canAttack){
                    gameObject.GetComponentInChildren<EscorteeAttack>().Attack();
                    isConfident = false;
                    lastAttackTime = Time.time;
                    if(moveAround){
                        moveAround = false;
                    } else {
                        moveAround = true;
                        randomMoveSpot = moveSpots[UnityEngine.Random.Range(0, moveSpots.Length)]; //set moveSpot
                    }
                }
            }

            if(Time.time - lastAttackTime > 2 && !isConfident){ // reset confidence to true
                if(UnityEngine.Random.Range(0,300) == 10){
                    isConfident = true;
                }
            }
       } else { // is dead
            transform.LookAt(new Vector3(0,100,0));
            escorteeNav.ResetPath();
            //rb.transform += new Vector3(0, -2, 0);
       }            
    
        //escorteeNav.ResetPath();   
    }

    public void Hit(int damage)
    {
        if(finalLevelStarted) health -= damage;
        AudioSource audioC = GetComponent<AudioSource>();
        audioC.PlayOneShot(hitSound, 1f);  

        if(health <= (maxHealth/8) && health > 0){
            audioC.PlayOneShot(angrySound, 1f);
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
        
        
        AudioSource audioC = GetComponent<AudioSource>();
        audioC.PlayOneShot(deathSound, .7f);
        gameObject.GetComponentInChildren<EscorteeAttack>().canAttack = false;
        isAlive = false;
        DialogueBox.GetComponent<DialogueFinal>().Invoke("BeginFinalDialogue", 1.5f);
        

        //Destroy(gameObject);

    }
}