using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponVacuum : Weapon
{
    [SerializeField] GameObject effectPrefab;
    private GameObject effect;
    private bool absorbing = false;
    private List<SoulManager> absorbingSouls = new List<SoulManager>();

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
        foreach (SoulManager soul in absorbingSouls)
            soul.absorbed = false;
        absorbingSouls.Clear();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!absorbing)
            return;

        if (other.CompareTag("Soul"))
        {
            SoulManager soulManager = other.GetComponent<SoulManager>();
            soulManager.absorbed = true;
            absorbingSouls.Add(soulManager);
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
            absorbingSouls.Remove(soulManager);
        }
    }
}