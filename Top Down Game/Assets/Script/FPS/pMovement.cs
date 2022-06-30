using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundedDrag;

    //Jumping//
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump; 


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space; 


    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 movementDirection;

    Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.freezeRotation = true; // prevents object from falling over.
    }

    private void Update()
    {
        //ground check//
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        //Handle drag//
        if (grounded)
            rBody.drag = groundedDrag;
        else
            rBody.drag = 0; 
    }

    private void FixedUpdate() // Responsible for physics//
    {
        MovePlayer();
    }

    private void MyInput() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump//
        if (Input.GetKey(jumpKey) && readyToJump && grounded) 
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown); 
        }
    }

    private void MovePlayer() 
    {
        //calculation movement direction//
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground//
        if(grounded)
           rBody.AddForce(movementDirection.normalized * moveSpeed * 10f, ForceMode.Force); //mess around with this float variabble theough.

        //In Air//
        else if(!grounded)
            rBody.AddForce(movementDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl() 
    {
        Vector3 flatVel = new Vector3(rBody.velocity.x, 0f, rBody.velocity.z);

        //limit velocity if needed(Might remove this)//
        if (flatVel.magnitude > moveSpeed) 
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rBody.velocity = new Vector3(limitedVel.x, rBody.velocity.y, limitedVel.z);
        }
    }

    private void Jump() 
    {
        //reset y velocity//
        rBody.velocity = new Vector3(rBody.velocity.x, 0f, rBody.velocity.z);

        rBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);  
    }

    private void ResetJump() 
    {
        readyToJump = true;
    }
}
