using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform chicken;
    public float rotationSpeed = 8f;
    public float moveSpeed = 20f;
    private float m_distance;

    private void Start()
    {
        chicken = GameObject.Find("Chicken").transform;
    }

    void Update()
    {

        //////////////Rotate towards player//////////////////
        Vector3 chickenPosition = new Vector3(chicken.position.x, transform.position.y, chicken.position.z);
        transform.LookAt(chickenPosition);
        
        /////////////Check the distance from the player/////////////
        m_distance = Vector3.Distance(transform.position, chicken.position);

        /////////////Move towards player////////////////
        if (m_distance <= 200)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        
    }
    
}
