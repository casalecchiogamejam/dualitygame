using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_GO : MonoBehaviour
{
    public Enemy_SO data;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed= data.speed;
    }

    void Update()
    {
        Move();
    }

    // move toward player
    public void Move()
    {
        agent.destination = GameManager.instance.player.transform.position; 
        agent.Move(Vector3.zero);
    }
}
