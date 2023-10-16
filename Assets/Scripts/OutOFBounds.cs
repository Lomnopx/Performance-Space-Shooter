using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOFBounds : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has a Rigidbody2D component
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Teleport the colliding object to the other side of the screen
            Vector2 currentPosition = other.transform.position;
            Vector2 newPosition = currentPosition;


            newPosition.x = -newPosition.x*0.97f; // Teleport X
            newPosition.y = -newPosition.y * 0.90f; // Teleport Y



            // Apply the new position to the colliding object
            other.transform.position = newPosition;
        }
    }
}
