using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GenericObjectPooling bulletPool;
    public GenericObjectPooling enemyPool;
    public PlayerManager player;

    private void Awake()
    {
        if(_instance==null)
        {
            _instance = GetComponent<GameManager>();
        }

        bulletPool.CreateNewPoolList();
        enemyPool.CreateNewPoolList();
    }
}
