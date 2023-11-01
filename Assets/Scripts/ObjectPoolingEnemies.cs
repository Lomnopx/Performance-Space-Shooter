using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 10;

    private List<GameObject> enemies;
    private int currentIndex = 0;

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        enemies = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }
    }

    public GameObject GetPooledEnemy()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            int index = (currentIndex + i) % enemies.Count;
            if (!enemies[index].activeInHierarchy)
            {
                currentIndex = (index + 1) % enemies.Count;
                return enemies[index];
            }
        }

        // If no inactive enemy found, reuse the oldest one
        GameObject oldestEnemy = enemies[currentIndex];
        currentIndex = (currentIndex + 1) % enemies.Count;
        return oldestEnemy;
    }

    public static void ReturnToPool(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}
