using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyScriptableObject : ScriptableObject
{
    public int level;
    public int life;
    public float movingSpeed;
    public int score;
}

