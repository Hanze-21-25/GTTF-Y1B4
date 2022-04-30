using System;
using UnityEngine;

/**
 * This class represents all living things in the game.
 */
public abstract class Entity : MonoBehaviour
{
    private int health;
    private string model;
    private float agility;

    
    private void Start()
    {
        // Adds a rigidbody to this object if it doesn't have it already
        if (GetComponent<Rigidbody>() != null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }
    
    private void Update()
    {
        CheckHealth();
    }

    /**
     * <summary>Kills an object if it runs out of health</summary>>
     */
    private void CheckHealth()
    {
        if (health > 0) return;
        Kill();
    }
    private void Kill()
    {
        Destroy(gameObject);
    }
    
}
