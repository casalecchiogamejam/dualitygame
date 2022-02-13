using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldsManager : MonoBehaviour
{
    public Constants.Worlds currentWorld = Constants.Worlds.RealWorld;

    public void ChangeWorld()
    {
        if (currentWorld == Constants.Worlds.RealWorld)
            currentWorld = Constants.Worlds.SoulsWorld;
        else
            currentWorld = Constants.Worlds.RealWorld;

        // TODO: change world graphically
    }
}
