using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    private Transform playerScaler;
    [SerializeField] float massIncreseAmount = 1.2f;

    void Start()
    {
        playerScaler = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Food"))
        {
            playerScaler.localScale *= massIncreseAmount;
            GameObject go = other.gameObject;
            Destroy(go);
        }
    }
}
