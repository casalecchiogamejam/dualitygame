using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.InputSystem.InputAction;

public class PlayerManager : MonoBehaviour
{
    public int experienceToLevelUp;

    public int experience;

    public int score;

    public int level
    {
        get { return experience / experienceToLevelUp; }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Enemy")
        {
            Debug.Log("YOU DIED");
            Destroy(gameObject);
        }
    }

    public void OnEnemyKilled(EnemyScriptableObject enemyData)
    {
        experience += enemyData.experience;
        score += enemyData.score;
    }


}
