using System;
using UnityEngine;

/** Issues -> Renderer is not working.
 * Represents an in-game node, to which player places turrets.
 */
public class Node : MonoBehaviour {
    
    public Game game;
    private bool Occupied => turret == null;
    
    public Turret turret; // Turret on top of this
    public NodeMenu contextMenu;
    [SerializeField] private Color baseColour;//Basic colour of this
    [SerializeField] private Color available; // Available colour
    [SerializeField] public Color unavailable; // Unavailable colour
    
    /**
     * Unity events
     */
    
    /// Initialises necessary values
    private void Start() {
        if (GetComponent<Renderer>() == null) {
            gameObject.AddComponent<Renderer>();
        }

        // Get from node parent
        var parent = transform.parent.GetComponent<Node>();
        if (parent != null) {
            baseColour = parent.baseColour;
            available = parent.available;
            unavailable = parent.unavailable;
        }

        GetComponent<Renderer>().material.color = baseColour;
        game = Game.Instance;
    }

    /// Calls BuildTurret
    private void OnMouseDown() {
        Build();
    }
    /// Changes colour of this
    private void OnMouseEnter() {
        if (Occupied) return;
        GetComponent<Renderer>().material.color = game.shop.selected.cost <= Player.Money ? available : unavailable;
    }

    /// Resets to a basic colour
    private void OnMouseExit() {
        GetComponent<Renderer>().material.color = baseColour;
    }

    
    /**
     * Custom Methods.
     */
    
    /// Builds a turret on top of this (Pass turret only with set prefab)
    private void Build() {
        if (Occupied || Player.Money < game.shop.selected.cost) return;
        Player.Money -= game.shop.selected.cost;
        turret = Instantiate(game.shop.selected.prefab, transform.position + turret.positionOffset, Quaternion.identity).GetComponent<Turret>();
    }
    
    /// Selection
    public void Select() {
        contextMenu.ui.SetActive(true);
    }
    public void Deselect(ref Node node) {
        contextMenu.ui.SetActive(false);
        node = null;
    }
}