using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    //Makes the object (seagull) spin
    void Update()
    {
        transform.Rotate(0f, 20f * Time.deltaTime, 0f, Space.World);
    }
}
