using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int maxEnemies = 999;
    private int currentEnemyCount;

    void Start()
    {
        currentEnemyCount = 0;
        InvokeRepeating("SpawnEnemy", 2f, 5f);
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount < maxEnemies)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            currentEnemyCount++;
        }
    }
}
