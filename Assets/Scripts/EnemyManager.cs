using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public EnemyScriptableObject data;
    private NavMeshAgent agent;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = data.speed;
    }

    void Update()
    {
        agent.destination = GameManager.instance.player.transform.position;
    }

    public void OnBulletHit()
    {
        GameManager.instance.player.OnEnemyKilled(data);
        StartCoroutine(GameManager.instance.enemyPool.DestroyObjectInstantiatedFromPool(gameObject, 0));
    }
}
