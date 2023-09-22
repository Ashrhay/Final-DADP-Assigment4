using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform orientation;

    [Header("Movement")]
    public float walkSpeed = 6f;
    public float sprintSpeed = 12f;

    private Rigidbody rb;
    private Vector3 moveDirection;
    public KeyCode sprintKey = KeyCode.LeftShift;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {

        HandleMovementInput();
        
        MovePlayer();
       
    }

    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 forward = orientation.forward;
        Vector3 right = orientation.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        moveDirection = (forward * verticalInput + right * horizontalInput).normalized;
    }
    private void MovePlayer()
    {
        float moveSpeed = (Input.GetKey(sprintKey)) ? sprintSpeed : walkSpeed;

        Vector3 velocity = moveDirection * moveSpeed;
        velocity.y = rb.velocity.y; // Preserve vertical velocity

        rb.velocity = velocity;
    }

}
