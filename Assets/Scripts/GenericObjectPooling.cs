using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This example spawns a random number of GameObject using a pool so that old systems can be reused.
public class GenericObjectPooling : MonoBehaviour
{
    public int numToInstantiate;
    public GameObject prefabToInstantiate;
    private List<GameObject> inactivePoolObjs;

    private void Awake()
    {
        CreateNewPoolList();
    }

    private void CreateNewPoolList()
    {
        inactivePoolObjs = new List<GameObject>();
        for (int i = 0; i < numToInstantiate; i++)
        {
            GameObject newPooledObj = Instantiate(prefabToInstantiate);
            newPooledObj.transform.SetParent(gameObject.transform);
            inactivePoolObjs.Add(newPooledObj);
        }
    }

    public GameObject GetElemFromPoolOrInstantiate()
    {
        if(inactivePoolObjs.Count > 0)
        {
            GameObject toEnableGO = inactivePoolObjs[0];
            toEnableGO.SetActive(true);
            inactivePoolObjs.Remove(toEnableGO);
            return toEnableGO;
        }
        else
        {
            GameObject toInstantiate = Instantiate(prefabToInstantiate);
            toInstantiate.transform.SetParent(gameObject.transform);
            toInstantiate.SetActive(true);
            return toInstantiate;
        }
    }

    public void DisableElemInScene(GameObject goToDisable)
    {
        goToDisable.SetActive(false);
        inactivePoolObjs.Add(goToDisable);
    }

    public IEnumerator DestroyObjectInstantiatedFromPool(GameObject goToDestroy, float secondsToWaitBeforeDestroy)
    {
        yield return new WaitForSeconds(secondsToWaitBeforeDestroy);

        if (gameObject != null && gameObject.activeInHierarchy)
            DisableElemInScene(goToDestroy);
    }

}
