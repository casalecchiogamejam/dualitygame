using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.InputSystem.InputAction;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Weapon weaponBulletLEFT;
    [SerializeField] Weapon weaponBulletRIGHT;
    [SerializeField] Weapon weaponVacuumLEFT;
    [SerializeField] Weapon weaponVacuumRIGHT;

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

    public float experiencePercent
    {
        get { return (float)experience / (float)Constants.experienceToLevelUp; }
    }


    public void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Enemy"))
        {
            // GAME OVER
            GameManager.instance.PauseGame();
        }

        if (collisionInfo.gameObject.CompareTag("Soul"))
        {
            SoulManager soul = collisionInfo.GetComponent<SoulManager>();
            soul.OnAbsorbFinished();
            OnSoulKilled(soul.data);
        }
    }

    public void OnEnemyKilled(EnemyScriptableObject enemyData)
    {
        score += enemyData.score;
    }

    public void OnSoulKilled(SoulScriptableObject soulData)
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