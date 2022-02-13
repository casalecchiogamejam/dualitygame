using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponVacuum : Weapon
{
    public override int GetDamage()
    {
        return 0;
    }

    public override void OnTriggerPressed(InputAction.CallbackContext context)
    {
    }
}
