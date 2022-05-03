using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class Level : MonoBehaviour
{
    public Transform tilePrefab;
    public Transform sceneryPrefab;
    private string contentsFolderName = "Tiles";
    private object[,] tiles;
    private int tileAmount;

    [SerializeField] private Vector2 size;
    [SerializeField] private float tileSize;
    [SerializeField] private float tileOffset;

    void Start()
    {
        tileAmount = (int) (size.x * size.y);
        tilePrefab.localScale = new Vector3(tileSize/10, 1, tileSize/10);
        if (tileOffset < 1)
        {
            tileOffset = 1;
        }

        GenerateLevel(); 
        GenerateLevelScenery();
    }

    
    
    //Generates the whole level
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

    
    
    
    //Generates the structure of tiles and returns a list of tiles and their coordinates.
    private object[] GenerateLevelBody()
    {
        var tiles = new object[tileAmount];
        var counter = 0;
        
        
        for(var x = 0; x < size.x; x++)
        {
            for(var y = 0; y < size.y; y++)
            {
                tiles[counter] = SpawnTile(x,y,tileOffset,"Tile");
                counter++;
            }
        }
        
        
        return tiles;
    }

    
    
    
    //Generates scenery of the level - for example beach or mountain range.
    private void GenerateLevelScenery(int tileNumber)
    {
        var pos = transform.position;
        object[] tile = tiles[tileNumber];


        pos.x = pos.x + tileSize * x * tileOffset + tileSize / 2 - tileSize*size.x/2;;
        pos.z = tileSize;
        
        var lvlScenery = Instantiate(sceneryPrefab, pos ,Quaternion.Euler(Vector3.zero));
        lvlScenery.parent = transform;
        lvlScenery.name = "Level Scenery";
    }
    
    
    
    
    //Spawns tiles under an instance of this class.
    private object[] SpawnTile(int x, int y, float offset, string tileName)
    {
        var position = transform.position;
        var x1 = position.x + tileSize * x * offset + tileSize / 2 - tileSize*size.x/2;
        var z1 = position.z + tileSize * y * offset + tileSize / 2 - tileSize*size.y/2;
        
        var tilePosition = new Vector3(x1 ,0 ,z1);
        var tile = new object[3];

        var folder = transform.Find(contentsFolderName);
        var tl = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.zero)).transform;
        
        tl.name = tileName + " "+ (x + 1) + "."+ (y + 1);
        tl.parent = folder;
        
        tile[0] = x;
        tile[1] = y;
        tile[2] = tl;
        
        
        return tile;
    }
}