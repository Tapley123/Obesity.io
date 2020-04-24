using System.Collections;
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

    public Joystick joystick;


    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        ainm = GetComponent<Animator>();
    }

    void Update()
    {
        //float inputX = Input.GetAxisRaw("Horizontal"); //computer controls
        float inputX = joystick.Horizontal; //phone controls
        if (inputX < 0)
            transform.Rotate(Vector3.up, -turnSpeed);
        if(inputX > 0)
            transform.Rotate(Vector3.up, turnSpeed);

        //float inputY = Input.GetAxisRaw("Vertical"); //computer controls
        float inputY = joystick.Vertical; //phone controls

        //moving
        if (inputY >= 0)
            moveDirection = new Vector3(0, 0, inputY).normalized;
        else
            moveDirection = new Vector3(0, 0, 0);

        Vector3 targetMoveAmount = moveDirection * walkSpeed;

        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        

        //jumping
        //if (Input.GetButtonDown("Jump") && grounded) //computer
            //myRb.AddForce(transform.up * jumpForce);

        if(Input.touchCount > 0 && Input.GetTouch(1).phase == TouchPhase.Began && grounded) //phone
            myRb.AddForce(transform.up * jumpForce);



        // fly animation plays when chicken isnt on a surface
        if (grounded)
            ainm.SetBool("grounded", true);
        else
            ainm.SetBool("grounded", false);

        // play walking animation when the player is moving
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
