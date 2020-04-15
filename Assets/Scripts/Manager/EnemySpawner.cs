using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static GameObject enemy;
    public GameObject enemyPrefab;

    public GameObject[] enemies;
    public static bool canSpawn = false;
    public static int enemySpawnNumber = -1;
    public Transform[] spawnPositions;

    private Vector3 RandomSpawnPos()
    {
        Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;
        return spawnPosition;
    }

    void Start()
    {
        enemy = enemyPrefab;
        for (int i = 0; i < 8; i++)
        {
            //enemies[i].transform.position = new Vector3(Random.Range(-55, 75), 6, Random.Range(-55, 75));
            enemies[i].gameObject.SetActive(false);
            enemies[i].gameObject.transform.position = RandomSpawnPos();
        }
    }

    void Update()
    {
        if(canSpawn)
        {
            enemies[enemySpawnNumber].SetActive(true);
            enemies[enemySpawnNumber].gameObject.GetComponent<EnemyController>().spawn = true;
            
            canSpawn = false;
        }
    }
}
