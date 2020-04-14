﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform chicken;
    public float rotationSpeed = 8f;
    public float moveSpeed = 20f;
    private float m_distance;

    public bool spawn, follow;
    public static Vector3 spawnPos1, spawnPos2, spawnPos3, spawnPos4;
    public Transform[] spawnPositions;

    [SerializeField] private float spawnStateTime;
    private Vector3 spawnPosition;

    private Vector3 RandomSpawnPos()
    {
        spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;
        return spawnPosition;
    }


    private void Start()
    {
        spawn = false;
        follow = true;

        chicken = GameObject.Find("Chicken").transform;
    }

    void Update()
    {
        if(spawn)
        {
            StartCoroutine(SpawnCourotine(spawnStateTime));
            spawn = false;
        }

        if (transform.position == spawnPositions[0].transform.position)
            Debug.Log("Spawn Position 1");
        if (transform.position == spawnPositions[1].transform.position)
            Debug.Log("Spawn Position 2");
        if (transform.position == spawnPositions[2].transform.position)
            Debug.Log("Spawn Position 3");
        if (transform.position == spawnPositions[3].transform.position)
            Debug.Log("Spawn Position 4");


        if (follow)
        {
            spawn = false;
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

    IEnumerator SpawnCourotine(float time)
    {
        follow = false;
        transform.position = RandomSpawnPos();

        yield return new WaitForSeconds(time);
        spawn = false;
        follow = true;
    }
}
