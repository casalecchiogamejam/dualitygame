using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponVacuum : Weapon
{
    [SerializeField] GameObject effectPrefab;
    private GameObject effect;
    private bool absorbing = false;

    public override int GetDamage()
    {
        return 0;
    }

    public override void OnTriggerPressed(InputAction.CallbackContext context)
    {
        absorbing = true;
        effect = Instantiate(effectPrefab);
        effect.transform.position = transform.position;
    }

    public override void OnTriggerReleased(InputAction.CallbackContext context)
    {
        absorbing = false;
        Destroy(effect);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!absorbing)
            return;

        if (other.CompareTag("Soul"))
        {
            Debug.Log("diocane");
            SoulManager soulManager = other.GetComponent<SoulManager>();
            soulManager.absorbed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!absorbing)
            return;

        if (other.CompareTag("Soul"))
        {
            SoulManager soulManager = other.GetComponent<SoulManager>();
            soulManager.absorbed = false;
        }
    }
}