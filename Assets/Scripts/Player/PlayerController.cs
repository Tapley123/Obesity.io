﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Collider coll;
    [SerializeField] private float jumpRange = 1f;
    private Animator ainm;

    public float turnSpeed = 1.5f; //angle of turn

    float rotY;

    public float walkSpeed = 6;
    public float jumpForce = 220;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;

    private Rigidbody myRb;
    private Vector3 moveDirection;

    [SerializeField] private float sizeIncrese = 1.2f;
    private bool grounded = false;
    [SerializeField] private float slowingSpeed = 0.9f;


    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        ainm = GetComponent<Animator>();
    }

    void Update()
    {
        //turn left and right
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, -turnSpeed);
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, turnSpeed);

        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(0, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        
        if (Input.GetButtonDown("Jump") && grounded)
            myRb.AddForce(transform.up * jumpForce);

        // fly animation plays when chicken isnt on a surface
        if (grounded)
            ainm.SetBool("grounded", true);
        else
            ainm.SetBool("grounded", false);



        // Check if the player is moving forwards or backwards
        if (inputY != 0)
            ainm.SetBool("moving", true);
        else if (inputY == 0)
            ainm.SetBool("moving", false);
    }


    void FixedUpdate()
    {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        myRb.MovePosition(myRb.position + localMove);
    }
    



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            grounded = true;
        }

        if(other.CompareTag("Food"))
        {
            transform.localScale *= sizeIncrese;
            walkSpeed -= slowingSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        grounded = false;
    }
}
