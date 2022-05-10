using System;
using UnityEngine;
using UnityEngine.EventSystems;

/** Issues -> Renderer is not working.
 * Represents an in-game node, to which player places turrets.
 */
public class Node : MonoBehaviour {
    
    private Game game;
    private bool occupied => turret == null;
    
    [NonSerialized] public Turret turret; // Turret on top of this
    [NonSerialized] public NodeMenu contextMenu;
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
        game = Game.instance;
    }

    /// Calls BuildTurret
    private void OnMouseDown() {
        Build(game.selectedTurret);
    }
    /// Changes colour of this
    private void OnMouseEnter() {
        if (occupied) return;
        GetComponent<Renderer>().material.color = game.selectedTurret.cost <= Player.Money ? available : unavailable;
    }

    /// Resets to a basic colour
    private void OnMouseExit() {
        GetComponent<Renderer>().material.color = baseColour;
    }

    
    /**
     * Custom Methods.
     */
    
    /// Builds a turret on top of this
    private void Build(Turret turret) {
        if (occupied) {
            
            return;
        }

        if (Player.Money < turret.GetComponent<Turret>().cost) {
            Debug.Log("You dont have enough money to build that!");
            return;
        }
        Player.Money -= turret.GetComponent<Turret>().cost; 
        
        this.turret = Instantiate(turret.prefab,
            transform.position + turret.positionOffset,
            Quaternion.identity).GetComponent<Turret>();
        
        Debug.Log("Turret build!");
    }
    
    /// Selects and deselects node
    public void Select() {
        // Deselects if you click on the same node you clicked before.
        contextMenu.ui.SetActive(true);
        contextMenu.Add(this);
    }

    /// Deselects a node
    public void Deselect(ref Node node) {
        node.contextMenu.ui.SetActive(false);
        node = null;
    }
}