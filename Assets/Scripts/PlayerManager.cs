using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.InputSystem.InputAction;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public Weapon weaponBulletLEFT;
    [SerializeField] public Weapon weaponBulletRIGHT;
    [SerializeField] public Weapon weaponVacuumLEFT;
    [SerializeField] public Weapon weaponVacuumRIGHT;

    public int experience;
    public int score;

    public Weapon equippedWeapon;

    public int level
    {
        get { return experience / Constants.experienceToLevelUp; }
    }

    public int damageDone
    {
        get { return equippedWeapon.GetDamage(); }
    }


    public void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("YOU DIED");
        }
    }

    public void OnEnemyKilled(EnemyScriptableObject enemyData)
    {
        score += enemyData.score;
    }

    public void OnSoulKilled(EnemyScriptableObject soulData)
    {
        experience += soulData.experience;
    }

    public void SwitchWeapon()
    {
        if (GameManager.ReferenceEquals(equippedWeapon, weaponBulletLEFT))
        {
            weaponBulletLEFT.gameObject.SetActive(false);
            weaponBulletRIGHT.gameObject.SetActive(false);
            weaponVacuumLEFT.gameObject.SetActive(true);
            weaponVacuumRIGHT.gameObject.SetActive(true);
            equippedWeapon = weaponVacuumLEFT;
        }
        else if (GameManager.ReferenceEquals(equippedWeapon, weaponVacuumLEFT))
        {
            weaponBulletLEFT.gameObject.SetActive(true);
            weaponBulletRIGHT.gameObject.SetActive(true);
            weaponVacuumLEFT.gameObject.SetActive(false);
            weaponVacuumRIGHT.gameObject.SetActive(false);
            equippedWeapon = weaponBulletLEFT;
        }
    }

}