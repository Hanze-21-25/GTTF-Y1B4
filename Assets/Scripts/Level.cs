using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform tilePrefab;
    private string contentsFolderName = "Tiles";
    private int width;
    private int height;
    private List<Transform> tiles;
    
    [SerializeField] private Vector2 size;
    [SerializeField] private float tileSize;
    [SerializeField] private float tileOffset;

    void Start()
    {
        tilePrefab.localScale = new Vector3(tileSize/10, 1, tileSize/10);
        
        width = (int) size.x;
        height = (int) size.y;
        
        if (tileOffset < 1)
        {
            tileOffset = 1;
        }

        GenerateLevel();
    }

    private void GenerateLevel()
    {
        
        // Destroys previous generation artifacts
        if (transform.Find(contentsFolderName))
        {
            DestroyImmediate(transform.Find(contentsFolderName).gameObject);
        }
        
        // Creates a folder under an object and puts all the tiles in it
        var folder = new GameObject(contentsFolderName).transform;
        folder.parent = transform;
        
        // Makes sure developer would set proper size for a level.
        if (size.x <= 0 || size.y <= 0)
        {
            throw new Exception("Null Exception - tile amount can not be less than 1");
        }

        //Generation itself
        tiles = GenerateLevelBody();
    }

    private List<Transform> GenerateLevelBody()
    {
        var tiles = new List<Transform>();

        for(var x = 0; x < size.x; x++)
        {
            for(var y = 0; y < size.y; y++)
            {
                var tile = SpawnTile(x,y,tileOffset, "Tile");
                tiles.Add(tile);
            }
        }

        return tiles;
    }

    private Transform SpawnTile(int x, int y, float offset, string tileName)
    {
        var position = transform.position;
        
        var x1 = position.x + tileSize * x * offset + tileSize / 2 - tileSize*size.x/2;
        var z1 = position.z + tileSize * y * offset + tileSize / 2 - tileSize*size.y/2;
        
        var tilePosition = new Vector3(x1 ,0 ,z1);
        
        var tile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.zero));
        tile.name = tileName + " "+ (x + 1) + "."+ (y + 1);
        var folder = transform.Find(contentsFolderName);
        tile.parent = folder;
        
        return tile;

    }
}