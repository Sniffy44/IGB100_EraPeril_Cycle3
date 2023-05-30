//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Media;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawners : MonoBehaviour
{
    public float SpawningRate = 1f;
    public GameObject EnemyPrefab;
    public Transform[] SpawnPoints;
    public PlayerController Player;
    public GameObject playerObject;
    
    public static int level;

    public static int level1enemySpawnMax = 3;
    public static int level2enemySpawnMax = 3;
    public static int level3enemySpawnMax = 3;
    private int enemiesLeftToSpawn;

    private float LastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "S0_MainMenu"){
            level = -1;
        }
        if(SceneManager.GetActiveScene().name == "S1_Tutorial"){
            level = 0;
        }
        if(SceneManager.GetActiveScene().name == "S2_Stoneage"){
            enemiesLeftToSpawn = level1enemySpawnMax;
            level = 1;
            Enemy.enemiesLeft = level1enemySpawnMax;
            playerObject.GetComponent<PlayerHealth>().AddHealth(100);
        } 
        if(SceneManager.GetActiveScene().name == "S3_Medieval"){
            enemiesLeftToSpawn = level2enemySpawnMax;
            level = 2;
            Enemy.enemiesLeft = level2enemySpawnMax;
        }
        if(SceneManager.GetActiveScene().name == "S4_WW1"){
            enemiesLeftToSpawn = level3enemySpawnMax;
            level = 3;
            Enemy.enemiesLeft = level3enemySpawnMax;
        }
        if(SceneManager.GetActiveScene().name == "S5_Final"){
            level = 3;
            Enemy.enemiesLeft = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Player == null) return;
        if (LastSpawnTime + SpawningRate < Time.time && enemiesLeftToSpawn > 0 && Random.Range(0,100) == 10)
        {
            var randomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            Instantiate(EnemyPrefab, randomSpawnPoint.position, Quaternion.identity);
            LastSpawnTime = Time.time;

            Debug.Log("enemy jus spawned ha");

            enemiesLeftToSpawn --;
            
        }
    }
}
