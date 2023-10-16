using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerHp;
    public EnemySpawner Espawner;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            PlayerHp--;
            Espawner.DestroyEnemy(collision.gameObject);
        }
    }
}
