using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Weapon : MonoBehaviour
{
    [SerializeField] BulletManager bulletPrefab;
    [SerializeField] string mapName;
    [SerializeField] string triggerActionName;
    [SerializeField] InputActionAsset inputActionAsset;
    private InputActionMap inputMap;

    public float bulletSpeed;
    public int bulletDamage;
    public float fireRate;

    private void Start()
    {
        inputMap = inputActionAsset.FindActionMap(mapName);

        InputAction inputAction = inputMap.FindAction(triggerActionName);

        if (inputAction != null)
            inputAction.started += OnTriggerPressed;
    }

    public void OnTriggerPressed(CallbackContext context)
    {
        // TODO: fireRate implementation
        GameManager.instance.bulletPool.GetElemFromPool(transform);
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Space))
            GameManager.instance.bulletPool.GetElemFromPool(transform);
#endif
    }
}
