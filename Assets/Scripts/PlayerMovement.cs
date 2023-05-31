using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    [SerializeField] float moveSpeed;
    [SerializeField] float groundDrag;

    [SerializeField] float jumpForce;
    [SerializeField] float jumpCooldown;
    [SerializeField] float jumpMultiplier;
    bool jumpReady = true;


    // Ground Check
    [SerializeField] float playerHeight;
    public LayerMask groundLayer;
    bool grounded;


    // Inputs
    public KeyCode jumpKey = KeyCode.Space;


    float horizontalInput;
    float verticalInput;

    public Transform orientation;

    Vector3 moveDirection;

    Rigidbody rb;

    private Animator animator;

    private bool isWalking = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        // user input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && jumpReady && grounded)
        {
            jumpReady = false;
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        // check if player is on the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        // Check if the player is moving
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        // Call animChange to update the animator parameter
        animChange(isWalking);
        // limit player movement speed
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void Move()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * jumpMultiplier, ForceMode.Force);
        }

    }

    void Jump()
    {
        animator.Play("Base Layer.Jumping", 0, 0.65f);

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        jumpReady = true;
    }

    void animChange(bool isWalking)
    {
        animator.SetBool("RunTrigger", isWalking);
        animator.SetBool("IdleTrigger", !isWalking);
    }
}