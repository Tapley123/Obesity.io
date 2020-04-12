using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static GameObject enemy;
    public GameObject enemyPrefab;

    public GameObject[] enemies;
    private bool canSpawn = true;
    public static int enemySpawnNumber = -1;

    void Start()
    {
        enemy = enemyPrefab;
        for (int i = 0; i <= 8; i++)
        {
            enemies[i].transform.position = new Vector3(Random.Range(-55, 75), 6, Random.Range(-55, 75));
            enemies[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        enemies[enemySpawnNumber].SetActive(true);
    }

    public static void SpawnEnemy()
    {
        Vector3 enemySpawnLocation = new Vector3(Random.Range(-80, 50), 6, Random.Range(-65, 70));
        Instantiate(enemy, enemySpawnLocation, Quaternion.identity);
    }
}
