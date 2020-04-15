using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform chicken;
    public float moveSpeed = 20f;
    private float distanceEnemyChicken;

    public bool spawn, follow;
    public Transform[] spawnPositions;

    [SerializeField] private float spawnStateTime;

    private bool canOpenDoors = true;
    private Transform CenterOfRoom;
    public float enemySeePlayerDist = 70f;
    
    private Vector3 RandomSpawnPos()
    {
        Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;
        return spawnPosition;
    }

    private void Start()
    {
        spawn = false;
        follow = true;

        chicken = GameObject.Find("Chicken").transform;
        CenterOfRoom = GameObject.Find("CenterOfRoom").transform;
    }

    void Update()
    {
        if (canOpenDoors)
        {
            if (transform.position == spawnPositions[0].transform.position)
            {
                //Debug.Log("Spawn Position 1");
                DoorOpener.door1 = true;
            }

            if (transform.position == spawnPositions[1].transform.position)
            {
                //Debug.Log("Spawn Position 2");
                DoorOpener.door2 = true;
            }

            if (transform.position == spawnPositions[2].transform.position)
            {
                //Debug.Log("Spawn Position 3");
                DoorOpener.door3 = true;
            }

            if (transform.position == spawnPositions[3].transform.position)
            {
                //Debug.Log("Spawn Position 4");
                DoorOpener.door4 = true;
            }
        }

        if(spawn)
        {
            StartCoroutine(SpawnCourotine(spawnStateTime));
        }

        Vector3 chickenPosition = new Vector3(chicken.position.x, transform.position.y, chicken.position.z);
        distanceEnemyChicken = Vector3.Distance(transform.position, chicken.position);

        if(follow)
        {
            //if the enemy can see the player
            if (distanceEnemyChicken <= enemySeePlayerDist)
            {
                transform.LookAt(chickenPosition);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }
    IEnumerator SpawnCourotine(float time)
    {
        follow = false;

        transform.LookAt(CenterOfRoom);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        yield return new WaitForSeconds(time);
        spawn = false;
        follow = true;
    }
}
