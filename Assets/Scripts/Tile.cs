using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    void Start()
    {
        Debug.Log(name + "/" + gameObject.GetInstanceID() + " Created.");
    }

    public Vector3 GetCoordinates()
    {
        throw new NotImplementedException();
    }

    public Tile GetNearestNeighbour()
    {
        throw new NotImplementedException();
    }
}
