using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.InputSystem.InputAction;

public class PlayerManager : MonoBehaviour
{
    public int experience;
    public int score;
    public Weapon equippedWeapon;

    public int level
    {
        get { return experience / Costants.experienceToLevelUp; }
    }

    public int damageDone
    {
        get { return equippedWeapon.bulletDamage; }
    }

    public void OnEnemyKilled(EnemyScriptableObject enemyData)
    {
        score += enemyData.score;
    }

    public void OnSoulKilled(EnemyScriptableObject soulData)
    {
        experience += soulData.experience;
    }

    public void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("YOU DIED");
        }
    }
}
