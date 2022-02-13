using System.Collections;
using System.Collections.Generic;
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
        if (context.started)
        {
            Debug.Log("started");

            absorbing = true;
            effect = GameObject.Instantiate(effectPrefab);
            effect.transform.position = transform.position;
        }
        else if (context.canceled)
        {
            Debug.Log("ended");

            absorbing = false;
            GameObject.Destroy(effect);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soul"))
        {
            SoulManager soulManager = other.GetComponent<SoulManager>();
            soulManager.absorbed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Soul"))
        {
            SoulManager soulManager = other.GetComponent<SoulManager>();
            soulManager.absorbed = false;
        }
    }
}