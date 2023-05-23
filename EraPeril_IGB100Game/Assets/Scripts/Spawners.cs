//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Media;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public float SpawningRate = 1f;
    public GameObject EnemyPrefab;
    public Transform[] SpawnPoints;
    public PlayerController Player;

    public static int level1enemySpawnMax = 3;
    private int enemiesLeftToSpawn;

    private float LastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        enemiesLeftToSpawn = level1enemySpawnMax;
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

            enemiesLeftToSpawn --;
            
        }
    }
}
