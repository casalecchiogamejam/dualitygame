using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region instance_singleton
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    #endregion

    public GenericObjectPooling bulletsPool;
    public GenericObjectPooling enemiesPool;
    public GenericObjectPooling soulsPool;
    public PlayerManager player;
    public WorldsManager worldsManager;
    public VolumeSwitcher volumeSwitcher;
    [HideInInspector]
    public bool gripLeftPressed = false;
    [HideInInspector]
    public bool gripRightPressed = false;

    private List<GameObject> allActiveObjs;


    private void Awake()
    {
        if(_instance==null)
        {
            _instance = GetComponent<GameManager>();
        }

        allActiveObjs = new List<GameObject>();
        CreateAllPoolLists();
    }

    private void CreateAllPoolLists()
    {
        bulletsPool.CreateNewPoolList();
        enemiesPool.CreateNewPoolList();
        soulsPool.CreateNewPoolList();
        //initialize all pools here...
    }

    public List<GameObject> GetAllActiveChildrenOfPool(GenericObjectPooling poolToRetrieve)
    {
        allActiveObjs.Clear();
        foreach (Transform child in poolToRetrieve.gameObject.transform)
        {
            if (child.gameObject.activeInHierarchy)
                allActiveObjs.Add(child.gameObject);
        }

        return allActiveObjs;
    }

    public void OnGripLeftPressed(InputAction.CallbackContext context)
    {
        if(context.started)
            gripLeftPressed = true;
        else if(context.canceled)
            gripLeftPressed = false;
    }

    public void OnGripRightPressed(InputAction.CallbackContext context)
    {
        if (context.started)
            gripRightPressed = true;
        else if (context.canceled)
            gripRightPressed = false;
    }
}
