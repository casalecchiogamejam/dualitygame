using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float secondsToWaitBeforeDestroy;

    void OnEnable()
    {
        StartCoroutine(GameManager.instance.bulletPool.DestroyObjectInstantiatedFromPool(gameObject, secondsToWaitBeforeDestroy));
    }
}
