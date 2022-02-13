using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponBullet : Weapon
{
    public float bulletSpeed;
    public float fireRate;
    public int damage;
    [SerializeField] BulletManager bulletPrefab;

    public override int GetDamage()
    {
        return damage;
    }

    public override void OnTriggerPressed(InputAction.CallbackContext context)
    {
        // TODO: fireRate implementation
        GameManager.instance.bulletsPool.GetElemFromPool(transform);
    }

    public override void OnTriggerReleased(InputAction.CallbackContext context)
    {
        return;
    }
}

