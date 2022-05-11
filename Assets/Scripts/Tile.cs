using System;
using UnityEngine;
using UnityEngine.Serialization;

/**
 * Should change colour on mouse enter and exit
 */
public class Tile : MonoBehaviour {
    
    /* Serialized Fields */
    
    [SerializeField] public Color available;
    [SerializeField] public Color unavailable;
    [SerializeField] public Color neutral;
    [SerializeField] public Color selection;
    
    
    /* private variables */
    private bool selected;

    /* public variables */
    
    
    
    /** Unity Methods **/
    
    // Selection
    private void Start() {
        // Inherits parent or sets children
        SetChildren();
        SetColour(neutral);
        selected = false;
    }

    private void OnMouseEnter() {
        if (!selected) {
            SetColour(available);
        }
    }

    private void OnMouseExit() {
        if (!selected) {
            SetColour(neutral);
        }
    }

    private void OnMouseDown() {
        selected = !selected;
        switch (selected) {
            case true:
                SetColour(selection);
                break;
            case false:
                SetColour(neutral);
                break;
        }
    }

    private void Update() {
        
    }
    
    /** Public Methods **/
    
    // Changes a colour of this
    private void SetColour(Color colour) {
            var renderer = transform.GetComponent<Renderer>();
            if (renderer == null) return;
            renderer.material.color = colour;
    
        }
    
    /** Private Methods **/

    // Builds a turret on top of this
    private void Build() {
        
    }

    // Adds this to all children and sets same property values.
    private void SetChildren() {
        foreach (Transform child in transform){
            child.gameObject.AddComponent<Tile>();
            var c = child.GetComponent<Tile>();
            c.available = available;
            c.unavailable = unavailable;
            c.neutral = neutral;
        }
    }
}
