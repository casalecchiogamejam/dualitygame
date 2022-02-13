using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulManager : EnemyBaseManager
{
    [SerializeField] EnemyScriptableObject data;

    private Vector3 moveDirection;

    void FixedUpdate()
    {
        transform.position += Vector3.up * data.speed * Time.deltaTime;
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
