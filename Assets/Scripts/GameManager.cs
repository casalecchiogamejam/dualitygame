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
    public GameOverLayer gameOverLayer;
    public VolumeSwitcher volumeSwitcher;

    public bool IsGamePaused
    {
        get { return Time.timeScale == 0; }
        private set { Time.timeScale = value ? 0 : 1; }
    }

    [SerializeField] float slowMotionFactor = 0.5f;
    public bool IsSlowMotionActive
    {
        get
        {
            return Time.timeScale == slowMotionFactor;
        }
        private set
        {
            if (value && !IsGamePaused)
                Time.timeScale = slowMotionFactor;
            else if (!IsGamePaused)
                Time.timeScale = 1;
        }
    }

    [HideInInspector] public bool gripLeftPressed = false;
    [HideInInspector] public bool gripRightPressed = false;

    private List<GameObject> allActiveObjs;



    private void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<GameManager>();
        }

        allActiveObjs = new List<GameObject>();
        CreateAllPoolLists();
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.M))
            ToggleSlowMotion();
#endif
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

    public void PauseGame()
    {
        IsGamePaused = false;
    }

    public void ResumeGame()
    {
        IsGamePaused = true;
    }

    public void ToggleSlowMotion()
    {
        IsSlowMotionActive = !IsSlowMotionActive;
    }
}
