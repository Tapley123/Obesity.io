using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void Update()
    {
        //Vector3 target = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        //transform.position = target;

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
