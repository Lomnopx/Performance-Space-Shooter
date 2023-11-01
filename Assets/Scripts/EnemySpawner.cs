using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPoolingEnemies enemyPool;

    [SerializeField] private float Minforce;
    [SerializeField] private float Maxforce;

    public List<Transform> SpawnPoints;

    private static int enemiesSpawned = 0; // Counter to keep track of enemies spawned

    public void SpawnPrefab()
    {
        GameObject enemy = enemyPool.GetPooledEnemy();
        if (enemy != null)
        {
            enemy.transform.position = SpawnPoints[Random.Range(0, SpawnPoints.Count)].position;
            enemy.SetActive(true);

            Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
            enemyRb.velocity = Vector3.zero;
            enemyRb.AddForce(new Vector2(Random.Range(Minforce, Maxforce), Random.Range(Minforce, Maxforce)));
        }
        enemiesSpawned++;
    }

    public static void DestroyEnemy(GameObject enemyForDelete)
    {
        ObjectPoolingEnemies.ReturnToPool(enemyForDelete);
        enemiesSpawned--;
    }


    void Update()
    {
        // Automatically spawn enemies until the maximum cap is reached
        while (enemiesSpawned < enemyPool.poolSize)
        {
            SpawnPrefab();
        }
    }
}

