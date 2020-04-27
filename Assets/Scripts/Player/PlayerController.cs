﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

    public Joystick joystick;


    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        ainm = GetComponent<Animator>();
    }

    void Update()
    {
        float pcInputX = Input.GetAxisRaw("Horizontal"); //computer controls
        float mobileInputX = joystick.Horizontal; //phone controls

        transform.Rotate(0, mobileInputX * turnSpeed, 0);
        transform.Rotate(0, pcInputX * turnSpeed, 0);

        float pcInputY = Input.GetAxisRaw("Vertical"); //computer controls
        float mobileInputY = joystick.Vertical; //phone controls

        //moving Mobile
        if (mobileInputY >= -0.75f)
            moveDirection = new Vector3(0, 0, mobileInputY).normalized;
        else
            moveDirection = new Vector3(0, 0, 0);

        //moving PC
        if (pcInputY >= -0.75f)
            moveDirection = new Vector3(0, 0, pcInputY).normalized;
        else
            moveDirection = new Vector3(0, 0, 0);

        Vector3 targetMoveAmount = moveDirection * walkSpeed;

        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);


        // fly animation plays when chicken isnt on a surface
        if (grounded)
            ainm.SetBool("grounded", true);
        else
            ainm.SetBool("grounded", false);

        //play walk animation when moving
        if (moveAmount.z > 0.2 || moveAmount.z < -0.2)
            ainm.SetBool("moving", true);
        else
            ainm.SetBool("moving", false);
    }


    void FixedUpdate()
    {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        myRb.MovePosition(myRb.position + localMove);

        //jumping Mobile
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                //For right half screen
                if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2 && grounded)
                {
                    grounded = false;
                    myRb.AddForce(transform.up * jumpForce);
                    //Debug.Log("Right Touch");
                }
            }
        }

        //jumping PC
        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            //Debug.Log("Space");
            grounded = false;
            myRb.AddForce(transform.up * jumpForce);
        }
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
        //grounded = false;
    }
}
