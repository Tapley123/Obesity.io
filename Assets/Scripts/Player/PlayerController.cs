using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Collider coll;
    [SerializeField] private float jumpRange = 1f;
    private Animator ainm;

    public float angle = 1.5f;

    float rotY;

    public float walkSpeed = 6;
    public float jumpForce = 220;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;
    //Transform cameraTransform;

    private Rigidbody myRb;
    private Vector3 moveDirection;


    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        ainm = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, -angle);
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, angle);

        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(0, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            if(Grounded())
            {
                myRb.AddForce(transform.up * jumpForce);
                ainm.SetTrigger("jump");
            }
        }
    }


    void FixedUpdate()
    {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        myRb.MovePosition(myRb.position + localMove);
    }

    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y + jumpRange); //coll.bounds.extents.y <------ gets the cunter bottom of your collider
    }
}
