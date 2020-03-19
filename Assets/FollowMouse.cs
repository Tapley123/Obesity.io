using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime / transform.localScale.x); //player moves slower the bigger they are
    }
}
