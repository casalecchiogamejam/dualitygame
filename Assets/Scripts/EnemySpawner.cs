using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyBaseManager spawnedEnemy;

    public float extraSpawnDelaySeconds;
    public float spawnDelaySeconds;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameManager.instance.enemiesPool.GetElemFromPool(transform);
            yield return new WaitForSecondsRealtime(spawnDelaySeconds);
        }
    }
}
