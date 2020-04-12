using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nugget : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    
    void Update()
    {
        Vector3 rotate = new Vector3(transform.rotation.x, transform.rotation.y + rotationSpeed * Time.deltaTime, transform.rotation.z);
        transform.Rotate(rotate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = new Vector3(0, -100, 0);
            UIManager.nuggetAmount += 1;
        }
    }
}
