using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GestureManager : MonoBehaviour
{

    public float detectTime;

    private float collisionTime = 0;
    private bool gestureDone = false;


    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.X))
            GameManager.instance.worldsManager.ChangeWorld();
#endif
    }

    void OnTriggerStay(Collider other)
    {
        if(GameManager.instance.gripLeftPressed && GameManager.instance.gripRightPressed)
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
