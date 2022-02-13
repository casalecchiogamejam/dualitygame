using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdle : MonoBehaviour
{
    Animator anim;
    void Start(){
        anim = GetComponent<Animator>();
    }

    public void EndCycle(){
        if(Random.Range(0,5)==2){
            anim.SetTrigger("Sobbalza");
        }
    }
}
