using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float secondsToWaitBeforeDestroy;

    private void OnEnable()
    {
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(secondsToWaitBeforeDestroy);

        if(gameObject != null && gameObject.activeInHierarchy)
            GameManager.instance.bulletObjectPool.pool.Release(gameObject);
    }
}
