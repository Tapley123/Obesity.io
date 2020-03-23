using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        Vector3 target = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
