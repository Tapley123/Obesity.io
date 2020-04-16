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
        spawn = true;
        follow = false;

        chicken = GameObject.Find("Chicken").transform;
        CenterOfRoom = GameObject.Find("CenterOfRoom").transform;
    }

    void Update()
    {
        if(spawn)
        {
            //StartCoroutine(SpawnCourotine(spawnStateTime));
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("CAUGHT!!");
            GameController.caughtByEnemy = true;
            Cursor.visible = true;
        }

        if(other.CompareTag("Spawn1"))
            DoorOpener.door1 = true;

        if (other.CompareTag("Spawn2"))
            DoorOpener.door2 = true;

        if (other.CompareTag("Spawn3"))
            DoorOpener.door3 = true;

        if (other.CompareTag("Spawn4"))
            DoorOpener.door4 = true;
    }
}
