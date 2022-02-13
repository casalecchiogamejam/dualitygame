using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] string mapName;
    [SerializeField] string triggerActionName;
    [SerializeField] InputActionAsset inputActionAsset;
    private InputActionMap inputMap;

    private void OnEnable()
    {
        inputMap = inputActionAsset.FindActionMap(mapName);

        InputAction inputAction = inputMap.FindAction(triggerActionName);

        if (inputAction != null)
        {
            inputAction.started += OnTriggerPressed;
            inputAction.canceled += OnTriggerReleased;
        }
    }

    private void OnDisable()
    {
        inputMap = inputActionAsset.FindActionMap(mapName);

        InputAction inputAction = inputMap.FindAction(triggerActionName);

        if (inputAction != null)
        {
            inputAction.started -= OnTriggerPressed;
            inputAction.canceled -= OnTriggerReleased;
        }
    }

    public abstract void OnTriggerPressed(CallbackContext context);
    public abstract void OnTriggerReleased(CallbackContext context);
    public abstract int GetDamage();

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
            GameManager.instance.bulletsPool.GetElemFromPool(transform);
#endif
    }
}
