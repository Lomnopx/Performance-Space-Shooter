using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                EnemySpawner.DestroyEnemy(collision.gameObject);
            }
            ObjectPoolingBullets.ReturnToPool(gameObject);
        }
    }
}
