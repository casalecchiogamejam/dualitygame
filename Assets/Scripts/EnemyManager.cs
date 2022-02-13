using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : EnemyBaseManager
{
    public EnemyScriptableObject data;
    private NavMeshAgent agent;
    private int currentLife;
    private bool destinationNavMeshSet;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        destinationNavMeshSet = false;
    }

    void OnEnable()
    {
        if (!destinationNavMeshSet && agent.isOnNavMesh)
        {
            agent.destination = GameManager.instance.player.transform.position;
            destinationNavMeshSet = true;
        }

        agent.speed = data.speed;
        currentLife = data.life;
    }

    public void OnBulletHit()
    {
        GetDamage(GameManager.instance.player.damageDone);
    }

    private void GetDamage(int damage)
    {
        Debug.Log(gameObject.name + " get damage " + damage);
        currentLife -= GameManager.instance.player.damageDone;
        if (currentLife <= 0)
            OnDeath();
        else
            OnGetDamage();
    }

    private void OnDeath()
    {
        GameManager.instance.player.OnEnemyKilled(data);
        StartCoroutine(GameManager.instance.enemyPool.DestroyObjectInstantiatedFromPool(gameObject, 0));

        // TODO: spawn enemy soul
    }

    private void OnGetDamage()
    {
        // TODO: animate damage?!
    }
}
