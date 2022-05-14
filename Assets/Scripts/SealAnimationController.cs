using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealAnimationController : MonoBehaviour
{
    
    void Start()
    {
        
        
        
    }

    
    void Update()
    {
        

        if (Input.GetKey(KeyCode.L))
        {
            GetComponent<Animator>().Play("SealAttack");
        }

        if (Input.GetKey(KeyCode.V))
        {
            GetComponent<Animator>().Play("SealWin");
        }
       
        if (Input.GetKey(KeyCode.I))
        {
            GetComponent<Animator>().Play("SealIdle");
        }
    }
}
