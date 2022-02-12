using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// This example spawns a random number of GameObject using a pool so that old systems can be reused.
public class GenericObjectPooling : MonoBehaviour
{
    public int defaultPoolSize;
    public int maxPoolSize;
    public GameObject prefabToInstantiate;
    public IObjectPool<GameObject> pool;

    private void Awake()
    {
        CreateNewObjectPool();
    }

    public IObjectPool<GameObject> CreateNewObjectPool()
    {
        if (pool == null)
        {
            pool = new ObjectPool<GameObject>(createFunc: () => 
                                                                {
                                                                    GameObject newPooledGO = Instantiate(prefabToInstantiate);
                                                                    newPooledGO.transform.parent = gameObject.transform;
                                                                    return newPooledGO;
                                                                },
                                                actionOnGet: (obj) => obj.SetActive(true),
                                                actionOnRelease: (obj) => obj.SetActive(false),
                                                actionOnDestroy: (obj) => Destroy(obj),
                                                collectionCheck: true,
                                                defaultCapacity: defaultPoolSize,
                                                maxSize: maxPoolSize);
        }
        return pool;
    }

    public IEnumerator DestroyObjectInstantiatedFromPool(GameObject goToDestroy, float secondsToWaitBeforeDestroy)
    {
        yield return new WaitForSeconds(secondsToWaitBeforeDestroy);

        if (gameObject != null && gameObject.activeInHierarchy)
            pool.Release(goToDestroy);

        Debug.Log(pool.CountInactive);
    }

}
