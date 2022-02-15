
using UnityEngine;

[CreateAssetMenu(fileName = "Soul", menuName = "ScriptableObjects/Soul", order = 1)]
public class SoulScriptableObject : ScriptableObject
{
    public int experience;
    public float movingSpeed;
    public float absorbingSpeed;
}