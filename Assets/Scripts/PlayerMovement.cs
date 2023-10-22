using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float ThrustForce = 5.0f;
    public float ShootForce = 5.0f;

    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private ShootBullet bulletSpawner;

    private void Update()
    {
        // Get horizontal and vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate force vector
        Vector2 force = new Vector2(horizontalInput, verticalInput).normalized * ThrustForce / 100;

        // Apply force to the Rigidbody2D
        playerRigidBody.AddForce(force);

        Vector2 moveDirection = playerRigidBody.velocity.normalized;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


        if(Input.GetButtonDown("Shoot"))
        {
            bulletSpawner.Shoot(playerRigidBody.transform.position, playerRigidBody.transform.right, ShootForce);
        }
    }
}
