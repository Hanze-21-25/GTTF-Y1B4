using UnityEngine;

/** Issues -> Renderer is not working.
 * Represents an in-game node, to which player places turrets.
 */
public class Node : MonoBehaviour {
    
    public Game game;
    public Turret turret; // Turret on top of this
    public NodeMenu contextMenu;
    Renderer _renderer;
    bool occupied => turret == null;
    
    [SerializeField] Color baseColour; //Basic colour of this
    [SerializeField] Color available; // Available colour
    [SerializeField] public Color unavailable; // Unavailable colour
    
    /// Initialises necessary values
    void Start() {
        if (transform.parent.GetComponent<Renderer>() != null) {
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
    void OnMouseDown() {
        Build();
    }

    /// Changes colour of this
    void OnMouseEnter() {
        if (occupied) return;
        GetComponent<Renderer>().material.color = game.shop.selected.cost <= Player.Money ? available : unavailable;
    }

    /// Resets to a basic colour
    void OnMouseExit() {
        GetComponent<Renderer>().material.color = baseColour;
    }
    
    /// Builds a turret on top of this (Pass turret only with set prefab)
    void Build() {
        if (occupied || Player.Money < game.shop.selected.cost) return;
        Player.Money -= game.shop.selected.cost;
        turret = Instantiate(game.shop.selected.prefab, transform.position + turret.positionOffset, Quaternion.identity)
            .GetComponent<Turret>();
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