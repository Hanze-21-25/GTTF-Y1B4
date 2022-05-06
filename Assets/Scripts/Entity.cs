using UnityEngine;

/**
 * This class represents all living things in the game.
 */
public abstract class Entity : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Transform model;
    [SerializeField] private float agility;

    
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

    private void Kill(){
        Destroy(gameObject);
    }


}