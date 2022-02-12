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

    private void Start()
    {
        inputMap = inputActionAsset.FindActionMap(mapName);

        InputAction inputAction = inputMap.FindAction(triggerActionName);

        if (inputAction != null)
            inputAction.started += OnTriggerPressed;
    }

    public void OnTriggerPressed(CallbackContext context)
    {
        GameObject newBullet = GameManager.instance.bulletPool.GetElemFromPoolOrInstantiate();
        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;
    }
}
