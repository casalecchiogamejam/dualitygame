using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyManager spawnedEnemy;

    public float spawnDelaySeconds;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameManager.instance.enemyPool.GetElemFromPool(transform);
            yield return new WaitForSecondsRealtime(spawnDelaySeconds);
        }
    }
}
