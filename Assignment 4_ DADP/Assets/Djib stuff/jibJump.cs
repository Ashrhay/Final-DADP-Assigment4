using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jibJump : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpHeight = 10;
    public bool grounded;
    public bool canDoubleJump = true;
    public float doubleJumpCooldown = 1.0f; // Adjust this cooldown time as needed
    private float lastJumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                grounded = false;
            }
        }
        else if (canDoubleJump && Input.GetKeyDown(KeyCode.Space) && Time.time - lastJumpTime >= doubleJumpCooldown)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            canDoubleJump = false;
            lastJumpTime = Time.time;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            grounded = true;
            canDoubleJump = true; // Reset double jump when landing on the ground.
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            grounded = false;
        }
    }
}
