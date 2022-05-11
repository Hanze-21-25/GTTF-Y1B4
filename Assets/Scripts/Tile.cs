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
    
    
    /* private variables */


    /* public variables */
    
    
    /* Unity Methods */
    
    private void Start() {
        // Inherits parent or sets children
        InheritParent();
        SetChildren();
        SetChildrenColours(neutral);
    }

    private void OnMouseEnter() {
        SetColour(available);
    }

    private void OnMouseExit() {
        SetColour(neutral);
    }

    private void Update() {
        
    }
    
    /** Public Methods **/
    
    /** Private Methods **/

    // Builds a turret on top of this
    private void Build() {
        
    }

    // Changes a colour of this
    private void SetColour(Color colour) {
        var renderer = transform.GetComponent<Renderer>();
        if (renderer == null) return;
        renderer.material.color = colour;

    }

    // Changes a colour of children
    private void SetChildrenColours(Color colour) {
        foreach (var renderer in GetComponentsInChildren<Renderer>()) {
            renderer.material.color = colour;
        }
    }

    // Inherits all public properties of a parent
    private bool InheritParent() {
        var parent = transform.parent.GetComponent<Tile>();
        if (parent == null) return false;
        // Sets this properties to parent's
        neutral = parent.neutral;
        available = parent.available;
        unavailable = parent.unavailable;
        return true;
    }

    private void SetChildren() {
        SetChildrenColours(neutral);
        var children = GetComponentsInChildren<Transform>();

        foreach (var child in children) {
            child.gameObject.AddComponent<Tile>();
        }
    }
}
