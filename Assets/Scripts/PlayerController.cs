using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // player speed
    public float speed = 0;

    // The number of coins in game
    private int count;

    // UI text for player win
    public GameObject gameOverText;

    // Start is called before the first frame update.
    void Start()
    {
        count = 6;
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        gameOverText.SetActive(false);
    }

    // Function is called when a move input is detected using WASD or Arrow keys
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();
        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    // I use it to keep the player moving even when there is not input.
    private void FixedUpdate()
    {
        // 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // On collision with the player
        if (other.gameObject.CompareTag("Coin"))
        {
            // Make the coin disappear
            other.gameObject.SetActive(false);
            count--;
            if (count == 0)
            {
                gameOverText.SetActive(true);
            }
        }

    }

}
