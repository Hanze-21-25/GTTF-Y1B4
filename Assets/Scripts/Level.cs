using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform tilePrefab;
    private string contentsFolderName = "Contents";
    private int width;
    private int height;
    private List<Transform> tiles;
    
    [SerializeField] private Vector2 size;
    [SerializeField] private float tileSize;
    [SerializeField] private float tileOffset;

    void Start()
    {
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
        
        string folderName = contentsFolderName;

        if (transform.Find(folderName))
        {
            DestroyImmediate(transform.Find(folderName).gameObject);
        }

        Transform folder = new GameObject(folderName).transform;
        folder.parent = transform;
        
        tilePrefab.localScale = new Vector3(tileSize/10, 1, tileSize/10);
        if (size.x <= 0 || size.y <= 0)
        {
            throw new Exception("Null Exception - tile amount can not be less than 1");
        }

        for(var x = 0; x < size.x; x++)
        {
            for(var y = 0; y < size.y; y++)
            {
                var tile = SpawnTile(x,y,tileOffset);
                tile.parent = folder;
            }
        }
    }
    
    private Transform SpawnTile(int x, int y, float offset)
    {
        var position = transform.position;
        
        var x1 = position.x + tileSize * x * tileOffset + tileSize / 2 - tileSize*size.x/2;
        var z1 = position.z + tileSize * y * tileOffset + tileSize / 2 - tileSize*size.y/2;
        
        var tilePosition = new Vector3(x1 ,0 ,z1);
        return Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.zero));
        
    }
}