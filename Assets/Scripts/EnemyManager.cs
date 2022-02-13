using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] TMP_Text lifeText;
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
        agent.speed = data.speed;
        currentLife = data.life;
        UpdateLifeBar();
    }

    void Update()
    {
        lifeText.gameObject.transform.LookAt(GameManager.instance.player.transform, GameManager.instance.player.transform.up);
    }

    public void OnBulletHit()
    {
        GetDamage(GameManager.instance.player.damageDone);
    }

    private void UpdateLifeBar()
    {
        lifeText.text = currentLife.ToString();
    }

    private void GetDamage(int damage)
    {
        currentLife -= GameManager.instance.player.damageDone;
        if (currentLife <= 0)
        {
            GameManager.instance.player.OnEnemyKilled(data);
            StartCoroutine(GameManager.instance.enemyPool.DestroyObjectInstantiatedFromPool(gameObject, 0));
        }
        else
        {
            // TODO: animate damage?!
            UpdateLifeBar();
        }
    }
}
