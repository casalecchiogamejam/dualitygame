using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float secondsToWaitBeforeDestroy;
    public float speed;


    void OnEnable()
    {
        DestroyObjectAfter(secondsToWaitBeforeDestroy);
    }

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Enemy"))
        {
            EnemyManager enemy = collisionInfo.gameObject.GetComponentInParent<EnemyManager>();

            if (enemy == null)
                Debug.LogWarning("missing EnemyManager component from " + collisionInfo.gameObject.name);
            else
            {
                enemy.OnBulletHit();
                DestroyObjectAfter(0);
            }
        }
    }

    void DestroyObjectAfter(float seconds)
    {
        StartCoroutine(GameManager.instance.bulletPool.DestroyObjectInstantiatedFromPool(gameObject, seconds));
    }

}
