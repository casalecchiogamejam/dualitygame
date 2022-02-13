using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureManager : MonoBehaviour
{
    public float detectTime;

    private float collisionTime = 0;
    private bool gestureDone = false;

    void OnTriggerStay(Collider other)
    {
        if (gestureDone)
            return;

        collisionTime += Time.deltaTime;

        if (collisionTime >= detectTime)
        {
            GameManager.instance.worldsManager.ChangeWorld();
            gestureDone = true;
            collisionTime = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RightHand Controller")
        {
            collisionTime = 0;
            gestureDone = false;
        }
    }
}
