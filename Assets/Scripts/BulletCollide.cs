using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class BulletCollide : MonoBehaviour
{
    //[SerializeField] private ObjectPoolingBullets pool;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
        else
        {
            if(collision.CompareTag("Enemy"))
            {
                Profiler.BeginSample("Destroy enemy and bullet");
                EnemySpawner.DestroyEnemy(collision.gameObject);
            }
            Destroy(gameObject);
            if (collision.CompareTag("Enemy"))
            {
                Profiler.EndSample();
            }
                
        }
    }
}
