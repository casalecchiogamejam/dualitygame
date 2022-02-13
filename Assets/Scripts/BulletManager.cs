using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Rigidbody rb;
    public float secondsToWaitBeforeDestroy;
    public float speed;

    void OnEnable()
    {
        DestroyObjectAfter(secondsToWaitBeforeDestroy);
    }

    void Update()
    {
        rb.AddForce(transform.forward * speed);
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Enemy"))
        {
            EnemyManager enemy = collisionInfo.gameObject.GetComponent<EnemyManager>();

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
        if(GameManager.instance.bulletsPool != null)
        {
            rb.velocity = Vector3.zero;
            StartCoroutine(GameManager.instance.bulletsPool.DestroyObjectInstantiatedFromPool(gameObject, seconds));
        }
    }

}
