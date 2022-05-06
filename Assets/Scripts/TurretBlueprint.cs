using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Lets Unity to know how to show information in the inspector

//Turret blueprint contains all the important information about the specific turret in the buildmanager
public class TurretBlueprint 
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;


    //Returns the half of the cost to the player
    //References are in Node and NodeUI
    public int GetSellAmount()
    {
        return cost / 2;
    }

}
