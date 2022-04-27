using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Lets Unity to know how to show information in the inspector
public class TurretBlueprint 
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }

}
