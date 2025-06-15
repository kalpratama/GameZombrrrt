using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int maxEnemies = 999;
    private int currentEnemyCount;
    //public int numberOfEnemy;
    //public bool setTimer;
    //public float timer;

    void Start()
    {
        currentEnemyCount = 0;
        InvokeRepeating("SpawnEnemy", 1f, 0.1f);
        //DontDestroyOnLoad(gameObject);
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount < maxEnemies && Time.time < 9f)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate (enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            currentEnemyCount++;
        }
    }

    /*void Timer()
    {
        setTimer = true;
        timer += Time.deltaTime;
    }*/
}
