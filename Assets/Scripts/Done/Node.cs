using System;
using UnityEngine;
using UnityEngine.EventSystems;

/** Issues -> Renderer is not working.
 * Represents an in-game node, to which player places turrets.
 */
public class Node : MonoBehaviour {
    
    [NonSerialized] public Turret turret; // Turret on top of this
    [NonSerialized] public bool isUpgraded;
    private Game game;
    [NonSerialized] public NodeMenu contextMenu;
    
    [SerializeField] private Color baseColour;//Basic colour of this
    [SerializeField] private Color available; // Available colour
    [SerializeField] public Color unavailable; // Unavailable colour
    
    /// Initialises necessary values
    void Start() {
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
    void OnMouseDown() {
        BuildTurret(game.turretToBuild);
    }

    /// Builds a turret on top of this
    void BuildTurret(Turret turret) {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (turret != null) {
            game.SelectNode(this);
            return;
        } if (!game.CanBuild) return;
        if (PlayerStats.Money < turret.GetComponent<Turret>().cost) {
            Debug.Log("You dont have enough money to build that!");
            return;
        }
        PlayerStats.Money -= turret.GetComponent<Turret>().cost; 
        
        this.turret = Instantiate(turret.prefab,
            transform.position + turret.positionOffset,
            Quaternion.identity).GetComponent<Turret>();
        
        Debug.Log("Turret build!");
    }

    /// Changes colour of this
    void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!game.CanBuild) return;

        GetComponent<Renderer>().material.color = game.HasMoney ? available : unavailable;
    }

    /// Resets to a basic colour
    void OnMouseExit() {
        GetComponent<Renderer>().material.color = baseColour;
    }
}