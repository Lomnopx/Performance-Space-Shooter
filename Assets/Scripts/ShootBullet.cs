using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private  ObjectPoolingBullets projectilePool;

    public void Shoot(Vector3 location, Vector3 direction, float force)
    {
        GameObject projectile = projectilePool.GetPooledProjectile();

        if (projectile != null)
        {
            projectile.transform.position = location;
            projectile.SetActive(true);

            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.velocity = Vector3.zero;
            projectileRb.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}
