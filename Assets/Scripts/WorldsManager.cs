using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldsManager : MonoBehaviour
{
    public Costants.Worlds currentWorld = Costants.Worlds.RealWorld;

    public void ChangeWorld()
    {
        if (currentWorld == Costants.Worlds.RealWorld)
            currentWorld = Costants.Worlds.SoulsWorld;
        else
            currentWorld = Costants.Worlds.RealWorld;

        // TODO: change world graphically
    }
}
