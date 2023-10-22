using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies;
    public List<Transform> SpawnPoints;

    public int enemyAmount = 10; // Maximum number of enemies to spawn
    private static int enemiesSpawned = 0; // Counter to keep track of enemies spawned

    // spawn a random prefab from the list
    public void SpawnRandomPrefab()
    {
        if (Enemies.Count > 0)
        {
            int randomIndex = Random.Range(0, Enemies.Count);
            GameObject prefabToSpawn = Enemies[randomIndex];
            Instantiate(prefabToSpawn, SpawnPoints[Random.Range(0, SpawnPoints.Count)].position, Quaternion.identity);
            enemiesSpawned++;
        }
        else
        {
            Debug.LogError("No prefabs available to spawn");
        }
    }

    // spawn a specific prefab from the list
    public void SpawnPrefabByIndex(int index)
    {
        if (index >= 0 && index < Enemies.Count)
        {
            GameObject prefabToSpawn = Enemies[index];
            Instantiate(prefabToSpawn, SpawnPoints[Random.Range(0, SpawnPoints.Count)].position, Quaternion.identity);
            enemiesSpawned++;
        }
        else
        {
            Debug.LogError("Invalid prefab index");
        }
    }

    public static void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
        enemiesSpawned--;
    }


    void Update()
    {
        // Automatically spawn enemies until the maximum cap is reached
        while (enemiesSpawned < enemyAmount)
        {
            SpawnRandomPrefab();
        }
    }
}

