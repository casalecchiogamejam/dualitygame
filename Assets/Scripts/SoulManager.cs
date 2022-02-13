using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulManager : EnemyBaseManager
{
    [SerializeField] EnemyScriptableObject data;

    private Vector3 moveDirection;

    void Start()
    {
        Vector3 playerPosition = GameManager.instance.player.transform.position;
        Vector3 distanceFromPlayer = playerPosition - transform.position;
        moveDirection = -distanceFromPlayer.normalized;
    }

    void FixedUpdate()
    {
        if (moveDirection != Vector3.zero)
            transform.position += moveDirection * data.speed * Time.deltaTime;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "SoulsResurrector")
        {
            //TODO: respawn soul as an enemy
            Debug.Log("RESURRECT ENEMY");
        }
    }
}
