using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : EnemyBaseManager
{
    [SerializeField] GameObject deathParticles;
    public EnemyScriptableObject data;
    private NavMeshAgent agent;
    private int currentLife;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GameManager.instance.player.transform.position;
    }

    void OnEnable()
    {
        agent.speed = data.movingSpeed;
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
        // istantiate soul
        GameObject soul = GameManager.instance.soulsPool.GetElemFromPool(transform);
        soul.transform.rotation = transform.rotation;

        // generate particles effect
        GameObject particles = GameObject.Instantiate(deathParticles);
        particles.transform.position = transform.position;

        // destroy enemy
        GameManager.instance.player.OnEnemyKilled(data);
        StartCoroutine(GameManager.instance.enemiesPool.DestroyObjectInstantiatedFromPool(gameObject, 0));
    }

    private void OnGetDamage()
    {
        // TODO: animate damage?!
    }
}