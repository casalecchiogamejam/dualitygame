using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
            Destroy(this.gameObject);
        }
    }

    public void OnEnemyKilled(EnemyScriptableObject enemyData)
    {
        experience += enemyData.experience;
        score += enemyData.score;
    }

}
