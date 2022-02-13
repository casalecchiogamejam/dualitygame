using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldsManager : MonoBehaviour
{
    public Constants.Worlds currentWorld = Constants.Worlds.RealWorld;
    [SerializeField] GameObject sphereAlive;
    [SerializeField] GameObject sphereDead;


    public void ChangeWorld()
    {
        if (currentWorld == Constants.Worlds.RealWorld)
        {
            currentWorld = Constants.Worlds.SoulsWorld;
            GameManager.instance.GetAllActiveChildrenOfPool(GameManager.instance.soulsPool).ForEach(soul => soul.layer = LayerMask.NameToLayer("Default"));
            GameManager.instance.GetAllActiveChildrenOfPool(GameManager.instance.enemiesPool).ForEach(enemy => enemy.layer = LayerMask.NameToLayer("No Hit"));
            GameManager.instance.volumeSwitcher.SetVolume(0);
            Instantiate(sphereAlive);
        }
        else
        {
            currentWorld = Constants.Worlds.RealWorld;
            GameManager.instance.GetAllActiveChildrenOfPool(GameManager.instance.soulsPool).ForEach(soul => soul.layer = LayerMask.NameToLayer("No Hit"));
            GameManager.instance.GetAllActiveChildrenOfPool(GameManager.instance.enemiesPool).ForEach(enemy => enemy.layer = LayerMask.NameToLayer("Default"));
            GameManager.instance.volumeSwitcher.SetVolume(1);
            Instantiate(sphereDead);
        }
        Debug.Log("changing world to " + currentWorld);
    }
}
