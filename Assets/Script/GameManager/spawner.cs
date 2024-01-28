using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of different enemy prefabs
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;
    public Transform spawnPoint;

    void Start()
    {
        // Start spawning enemies at random intervals
        Invoke("SpawnRandomEnemy", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnRandomEnemy()
    {
        // Select a random enemy prefab from the array
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Instantiate the selected enemy at the spawn point
        Instantiate(randomEnemyPrefab, spawnPoint.position, Quaternion.identity);

        // Schedule the next spawn at a random interval
        Invoke("SpawnRandomEnemy", Random.Range(minSpawnInterval, maxSpawnInterval));
    }
}
