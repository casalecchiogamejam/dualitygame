using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public float secondsToWaitBeforeDestroy;
    public EnemyScriptableObject data;
    private NavMeshAgent agent;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = data.speed;
    }
    void OnEnable()
    {
        StartCoroutine(GameManager.instance.enemyPool.DestroyObjectInstantiatedFromPool(gameObject, secondsToWaitBeforeDestroy));
    }

    void Update()
    {
                
        agent.destination=GameManager.instance.player.transform.position; 

    }
}
