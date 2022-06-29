using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

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
        MyInput();
    }

    private void FixedUpdate() // Responsible for physics//
    {
        MovePlayer();
        
    }

    private void MyInput() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical"); 
    }

    private void MovePlayer() 
    {
        //calculation movement direction//
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rBody.AddForce(movementDirection.normalized * moveSpeed * 10f, ForceMode.Force); //mess around with this float variabble theough.

                                                                       
    
    }
}
