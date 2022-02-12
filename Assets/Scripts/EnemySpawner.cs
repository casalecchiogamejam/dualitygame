using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy_GO spawnedEnemy;

    public float spawnDelaySeconds;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Enemy_GO newEnemy = GameObject.Instantiate(spawnedEnemy, transform.position, transform.rotation);
            yield return new WaitForSecondsRealtime(spawnDelaySeconds);
        }
    }
}
