using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldsManager : MonoBehaviour
{
    public Constants.Worlds currentWorld = Constants.Worlds.RealWorld;

    public void ChangeWorld()
    {
        if (currentWorld == Constants.Worlds.RealWorld)
        {
            currentWorld = Constants.Worlds.SoulsWorld;
            GameManager.instance.GetAllActiveChildrenOfPool(GameManager.instance.soulsPool).ForEach(soul => soul.layer = LayerMask.NameToLayer("Default"));
            GameManager.instance.GetAllActiveChildrenOfPool(GameManager.instance.enemiesPool).ForEach(enemy => enemy.layer = LayerMask.NameToLayer("No Hit"));
            GameManager.instance.volumeSwitcher.SetVolume(0);
        }
        else
        {
            currentWorld = Constants.Worlds.RealWorld;
            GameManager.instance.GetAllActiveChildrenOfPool(GameManager.instance.soulsPool).ForEach(soul => soul.layer = LayerMask.NameToLayer("No Hit"));
            GameManager.instance.GetAllActiveChildrenOfPool(GameManager.instance.enemiesPool).ForEach(enemy => enemy.layer = LayerMask.NameToLayer("Default"));
            GameManager.instance.volumeSwitcher.SetVolume(1);
        }

        // TODO: change world graphically
    }
}
