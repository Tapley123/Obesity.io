using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Transform playerScale;

    void Start()
    {
        Debug.Log("Started");
        playerScale = GameObject.Find("Player").transform;
    }
    void Update()
    {
        Vector3 target = new Vector3(Input.mousePosition.x, Input.mousePosition.z, Input.mousePosition.y);

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime / playerScale.localScale.x); //player moves slower the bigger they are
    }
}
