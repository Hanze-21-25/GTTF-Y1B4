using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimationController : MonoBehaviour
{
    void Update()
    {
        if (WaveSpawner.EnemiesAlive < 1)
        {
            GetComponent<Animator>().Play("Car Movement");
        } else
        {
            GetComponent<Animator>().Play("New State");
        }
    }
}
