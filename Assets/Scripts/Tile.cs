using System;
using UnityEditor;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public Vector2 levelCoordinates { get; set; }

    void Start()
    {
        Debug.Log(name + "/" + gameObject.GetInstanceID() + " Created.");
    }

    /**
     * This method is called from other classes
     * to launch the function of the tile which method they are calling.
     */
    public virtual void Function()
    {
        DefaultBehaviour();
    }
    
    
    /**
     * <summary> A default behaviour of all tiles </summary>>
     */
    protected void DefaultBehaviour()
    {
        Build();
    }

    protected void Build()
    {
        
    }

    public Vector3 GetCoordinates()
    {
        return transform.position;
    }
    
}
