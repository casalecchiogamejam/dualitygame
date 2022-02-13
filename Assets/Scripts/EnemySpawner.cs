using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyBaseManager spawnedEnemy;

    public float extraSpawnDelaySeconds;
    public float spawnDelaySeconds;

    public int extraEnemiesToSpawn = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (extraEnemiesToSpawn > 0)
            {
                extraEnemiesToSpawn--;
                GameManager.instance.enemiesPool.GetElemFromPool(transform);
                yield return new WaitForSeconds(extraSpawnDelaySeconds);
            }

            GameManager.instance.enemiesPool.GetElemFromPool(transform);
            yield return new WaitForSecondsRealtime(spawnDelaySeconds);
        }
    }
}
