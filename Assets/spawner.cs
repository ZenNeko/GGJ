using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;
    public Transform spawnPoint;

    void Start()
    {
        // Start spawning enemies at random intervals
        Invoke("SpawnEnemy", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnEnemy()
    {
        // Instantiate an enemy at the spawn point
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Schedule the next spawn at a random interval
        Invoke("SpawnEnemy", Random.Range(minSpawnInterval, maxSpawnInterval));
    }
}
