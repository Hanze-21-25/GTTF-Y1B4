using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Turret turret;
    private Animator anim;
    
    void Awake()
    {
        turret = GetComponent<Turret>();
    }   

    void Start(){
        anim = GetComponent<Animator>();
    }

    void Update(){
        if(turret.sht == true)
        {
            anim.SetTrigger("isAttack");
            Debug.Log("Attacked");
            turret.sht = false;
        }
    }
}
