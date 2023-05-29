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
    
    public static int level;

    public static int level1enemySpawnMax = 15;
    public static int level2enemySpawnMax = 20;
    public static int level3enemySpawnMax = 20;
    private int enemiesLeftToSpawn;

    private float LastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "S2_Stoneage"){
            enemiesLeftToSpawn = level1enemySpawnMax;
            level = 1;
            Enemy.enemiesLeft = level1enemySpawnMax;
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
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Player == null) return;
        if (LastSpawnTime + SpawningRate < Time.time && enemiesLeftToSpawn > 0 && Random.Range(0,1000) == 10)
        {
            var randomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            Instantiate(EnemyPrefab, randomSpawnPoint.position, Quaternion.identity);
            LastSpawnTime = Time.time;

            enemiesLeftToSpawn --;
            
        }
    }
}
