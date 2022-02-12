using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_GO : MonoBehaviour
{
    public Enemy_SO data;

    void Update()
    {
        Move();
    }

    // move toward player
    public void Move()
    {
        transform.position += transform.forward * data.speed * Time.deltaTime;
    }


}
