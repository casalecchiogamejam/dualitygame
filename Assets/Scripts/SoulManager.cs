using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulManager : EnemyBaseManager
{
    public SoulScriptableObject data;
    public bool absorbed = false;

    void FixedUpdate()
    {
        if (absorbed)
        {
            Vector3 playerPosition = GameManager.instance.player.transform.position;
            Vector3 absorbingDirection = -(transform.position - playerPosition).normalized;

            transform.position += absorbingDirection * data.absorbingSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.up * data.movingSpeed * Time.deltaTime;
        }

    }

    public void OnAbsorbFinished()
    {
        StartCoroutine(GameManager.instance.soulsPool.DestroyObjectInstantiatedFromPool(gameObject, 0));
    }
}