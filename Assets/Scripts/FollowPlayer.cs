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
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(chicken.position - transform.position),
                                                rotationSpeed * Time.deltaTime);

        /////////////Check the distance from the player/////////////
        m_distance = Vector3.Distance(transform.position, chicken.position);
        //Debug.Log(m_distance);

        /////////////Move towards player////////////////
        if (m_distance <= 200)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
