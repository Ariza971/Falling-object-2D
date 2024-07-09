using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 10.0f;
    float jumpForce = 5.0f;
    bool isJumping = false;

    Rigidbody2D rb;

    public event Action PlayerDied;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1.1f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Check for jump input
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Apply jump force
        if (isJumping)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Object"))
        {
            Debug.Log("Collision with Object tag detected.");
            PlayerDied?.Invoke();
            Destroy(collision.gameObject);
            Destroy(this.gameObject); // Destroy the player as well
        }
    }
}
