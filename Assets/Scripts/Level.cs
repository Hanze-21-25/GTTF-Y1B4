using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable MemberCanBeMadeStatic.Local

public class Level : MonoBehaviour
{
    public Transform tilePrefab;
    [SerializeField] private Vector2 tiles;
    [SerializeField] private float tileSize;
    [SerializeField] private float tileOffset;

    
    
    
    
    
    
    
    
    

    void Start()
    {
        GenerateLevel();
    }
    
    
    
    
    
    
    

    private void GenerateLevel()
    {
        if (tiles.x <= 0 || tiles.y <= 0)
        {
            throw new Exception("Null Exception - tile amount can not be less than 1");
        }

        for(var x = 0; x < tiles.x; x++)
        {
            for(var y = 0; y < tiles.y; y++)
            {
                SpawnTile(x,y,tileOffset);
            }
        }
    }

    
    
    
    
    
    
    
    
    private Transform SpawnTile(int x, int y, float offset)
    {
        var tilePosition = new Vector3( tileSize*x + tileSize/2 ,0 ,tileSize*y + tileSize/2);
        return Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90));
    }
}
