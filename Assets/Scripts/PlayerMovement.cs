using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float thrustForce = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal and vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate force vector
        Vector2 force = new Vector2(horizontalInput, verticalInput).normalized * thrustForce / 100;

        // Apply force to the Rigidbody2D
        rb.AddForce(force);
    }
}
