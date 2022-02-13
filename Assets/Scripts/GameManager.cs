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

    public GenericObjectPooling bulletsPool;
    public GenericObjectPooling enemiesPool;
    public GenericObjectPooling soulsPool;
    public PlayerManager player;
    public WorldsManager worldsManager;

    private void Awake()
    {
        if(_instance==null)
        {
            _instance = GetComponent<GameManager>();
        }

        bulletsPool.CreateNewPoolList();
        enemiesPool.CreateNewPoolList();
        soulsPool.CreateNewPoolList();
    }
}
