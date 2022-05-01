using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private Vector2 coordinates;
    
    [SerializeField] private int levelVerticalSize;
    [SerializeField] private int levelHorizontalSize;
    [SerializeField] private float squareSize;


    void Start()
    {
        coordinates = new Vector2(levelHorizontalSize, levelVerticalSize);
        for (var x = 0; x < coordinates.x; x++)
        {
            GenerateTile();
        }
    }

    private void GenerateTile()
    {
        throw new NotImplementedException();
        
    }
}
