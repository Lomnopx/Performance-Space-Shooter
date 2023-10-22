using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingBullets : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int poolSize = 10;

    private List<GameObject> projectiles;
    private int currentIndex = 0;

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        projectiles = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            projectiles.Add(projectile);
        }
    }

    public GameObject GetPooledProjectile()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            int index = (currentIndex + i) % projectiles.Count;
            if (!projectiles[index].activeInHierarchy)
            {
                currentIndex = (index + 1) % projectiles.Count;
                return projectiles[index];
            }
        }

        // If no inactive projectiles found, reuse the oldest one
        GameObject oldestProjectile = projectiles[currentIndex];
        currentIndex = (currentIndex + 1) % projectiles.Count;
        return oldestProjectile;
    }

    public static void ReturnToPool(GameObject projectile)
    {
        projectile.SetActive(false);
    }
}
