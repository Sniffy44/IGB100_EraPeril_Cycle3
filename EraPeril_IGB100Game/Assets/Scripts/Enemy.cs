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

    


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);

        
    }

    public void Hit()
    {
        health -= 1;
    }

    public void Die()
    {
        //Instantiate(BloodPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //ScoreScript.scoreValue += 10;

    }

    
}
