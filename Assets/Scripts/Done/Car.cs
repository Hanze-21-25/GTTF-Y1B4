using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimationController : MonoBehaviour
{
    void Update()
    {
        if (Wave.enemies.Length < 1)
        {
            GetComponent<Animator>().Play("Car Movement");
        } else
        {
            GetComponent<Animator>().Play("New State");
        }
    }
}
