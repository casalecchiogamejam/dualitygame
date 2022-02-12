using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float secondsToWaitBeforeDestroy;
    public float speed;


    void OnEnable()
    {
        StartCoroutine(GameManager.instance.bulletPool.DestroyObjectInstantiatedFromPool(gameObject, secondsToWaitBeforeDestroy));
    }

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Enemy")
        {
            EnemyManager enemy = collisionInfo.gameObject.GetComponentInParent<EnemyManager>();

            if (enemy == null)
                Debug.LogWarning("missing EnemyManager component from " + collisionInfo.gameObject.name);
            else
                enemy.OnBulletHit();
        }
    }
}
