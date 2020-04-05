using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator ainm;
    private float verticalInput;

    protected Collider coll;

    void Start()
    {
        ainm = GetComponent<Animator>();
        coll = GetComponent<Collider>();
    }
    
    void Update()
    {
        ///////////////////////////////////////////////Check if the player is moving forwards or backwards/////////////////////////////////////////////////
        verticalInput = Input.GetAxis("Vertical");

        if(verticalInput != 0)
            ainm.SetBool("moving", true);
        else if (verticalInput == 0)
            ainm.SetBool("moving", false);
    }

    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y + 0.1f); //coll.bounds.extents.y <------ gets the cunter bottom of your collider
    }
}
