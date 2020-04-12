using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static GameObject enemy;
    public GameObject enemyPrefab;

    void Start()
    {
        enemy = enemyPrefab;
    }

    public static void SpawnEnemy()
    {
        Vector3 enemySpawnLocation = new Vector3(Random.Range(-80, 50), 6, Random.Range(-65, 70));
        Instantiate(enemy, enemySpawnLocation, Quaternion.identity);
    }
}
