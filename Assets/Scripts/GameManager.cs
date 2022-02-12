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
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    #endregion

    public GameObject bulletPrefab;
    public GameObject rightHandControllerGO;
    public GameObject leftHandControllerGO;
    public Player player;

    //TODO creare input system per gestione eventi sui tasti dei controller
}
