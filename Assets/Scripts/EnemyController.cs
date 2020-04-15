using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform chicken;
    public float rotationSpeed = 8f;
    public float moveSpeed = 20f;
    private float distanceEnemyChicken, distanceEnemyCenter;

    public bool spawn, follow, sendtoSpawn;
    public static Vector3 spawnPos1, spawnPos2, spawnPos3, spawnPos4;
    public Transform[] spawnPositions;

    [SerializeField] private float spawnStateTime;
    private Vector3 spawnPosition;

    private bool canOpenDoors = true;
    private Transform CenterOfRoom;
    public float enemySeePlayerDist = 70f;
    
    private Vector3 RandomSpawnPos()
    {
        spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;
        return spawnPosition;
    }
    


    private void Awake()
    {
        //transform.position = RandomSpawnPos();
    }

    private void Start()
    {
        spawn = false;
        follow = true;
        sendtoSpawn = false;

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

        
        Vector3 chickenPosition = new Vector3(chicken.position.x, transform.position.y, chicken.position.z);
        distanceEnemyChicken = Vector3.Distance(transform.position, chicken.position);
        distanceEnemyCenter = Vector3.Distance(transform.position, CenterOfRoom.position);

        if (distanceEnemyChicken <= enemySeePlayerDist)
        {
            transform.LookAt(chickenPosition);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if(distanceEnemyChicken >= enemySeePlayerDist && distanceEnemyCenter >= 20)
        {
            transform.LookAt(CenterOfRoom);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
    IEnumerator SpawnCourotine(float time)
    {
        follow = false;

        yield return new WaitForSeconds(time);
        spawn = false;
        follow = true;

    }
}
