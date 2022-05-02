using System;
using UnityEngine;
// ReSharper disable MemberCanBeMadeStatic.Local

public class Level : MonoBehaviour
{
    public Transform tilePrefab;
    private string contentsFolderName = "Contents";
    [SerializeField] private Vector2 tiles;
    [SerializeField] private float tileSize;
    [SerializeField] private float tileOffset;

    void Start()
    {
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
        if (tiles.x <= 0 || tiles.y <= 0)
        {
            throw new Exception("Null Exception - tile amount can not be less than 1");
        }

        for(var x = 0; x < tiles.x; x++)
        {
            for(var y = 0; y < tiles.y; y++)
            {
                var tile = SpawnTile(x,y,tileOffset);
                tile.parent = folder;
            }
        }
    }
    
    private Transform SpawnTile(int x, int y, float offset)
    {
        var position = transform.position;
        
        var x1 = position.x + tileSize * x * tileOffset + tileSize / 2;
        var z1 = position.z + tileSize * y * tileOffset + tileSize / 2;
        
        var tilePosition = new Vector3(x1 ,0 ,z1);
        return Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.zero));
        
    }
}