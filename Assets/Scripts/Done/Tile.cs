using UnityEngine;

/**
 * Should change colour on mouse enter and exit
 */
public class Tile : MonoBehaviour {

    /* Serialized Fields */
    
    [SerializeField] public Transform allyPrefab;
    [SerializeField] public Color available;
    [SerializeField] public Color unavailable;
    [SerializeField] public Color neutral;
    [SerializeField] public Color occupied;
    
    /* private variables */
    private Ally _ally;


    /* public variables */

    /** Unity Methods **/
    
    // Selection
    private void Start() {
        // Inherits parent or sets children
        SetChildren();
        SetColour(neutral);
    }
    private void OnMouseEnter() {
        if (_ally == null) {
            SetColour(available);
        }
    }
    private void OnMouseExit() {
        if (_ally == null) {
            SetColour(neutral);
        }
    }
    // Select/Deselect Tile
    private void OnMouseDown() {
        if (Input.GetMouseButtonDown(0) && _ally == null) {
            Build();
        } 
    }

    /** Public Methods **/
    
    /** Private Methods **/
    // Changes a colour of this
    private void SetColour(Color colour) {
            var renderer = transform.GetComponent<Renderer>();
            
            if (renderer == null) return;
            renderer.material.color = colour;
    }

    // Builds a turret on top of this
    private void Build() {
        if (_ally != null) return;
        SetColour(occupied);
        var pos = transform.position;
        pos.y += 0.6f;
        _ally = Instantiate(allyPrefab, pos, transform.rotation).GetComponent<Ally>();
    }

    // Adds this to all children and sets same property values.
    private void SetChildren() {
        foreach (Transform child in transform){
            child.gameObject.AddComponent<Tile>();
            var c = child.GetComponent<Tile>();
            c.available = available;
            c.unavailable = unavailable;
            c.neutral = neutral;
            c.allyPrefab = allyPrefab;
        }
    }
}
