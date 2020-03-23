using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private float yPos = 1f;
    [SerializeField] private float speed = 5f;
    private Transform playerScale;

    void Start()
    {
        Debug.Log("Started");
        playerScale = GameObject.Find("Player").transform;
    }
    void Update()
    {
        //Vector3 target = new Vector3(0, Input.mousePosition.z, Input.mousePosition.y); //Input.mousePosition.z, Input.mousePosition.y);

        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime / playerScale.localScale.x); //player moves slower the bigger they are

        //transform.LookAt(target);

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z); // this line will alter the z to match the zPos variable
    }
}
