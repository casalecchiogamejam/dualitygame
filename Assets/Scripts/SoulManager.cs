using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulManager : EnemyBaseManager
{
    [SerializeField] EnemyScriptableObject data;

    private Vector3 moveDirection;
    public bool absorbed = false;

    void FixedUpdate()
    {
        if (absorbed)
        {
            Vector3 playerPosition = GameManager.instance.player.transform.position;
            Vector3 absorbingDirection = -(transform.position - playerPosition).normalized;

            transform.position += absorbingDirection * data.speed * 5 * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.up * data.speed * Time.deltaTime;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "SoulsResurrector")
            GameManager.instance.soulsPool.DestroyObjectInstantiatedFromPool(gameObject, 0);
    }
}