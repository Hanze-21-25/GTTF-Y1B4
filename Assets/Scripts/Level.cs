using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable MemberCanBeMadeStatic.Local

public class Level : MonoBehaviour
{
    public Transform tilePrefab;
    [SerializeField] private Vector2 coordinates;
    [SerializeField] private float tileSize;
    [SerializeField] private float tileOffset;


    void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for(var x = 0; x < coordinates.x; x++)
        {
            for(var y = 0; y < coordinates.y; y++)
            {
                SpawnTile(x,y,tileOffset);
            }
        }
    }

    private void SpawnTile(int x, int y, float offset)
    {
        
    }
}
