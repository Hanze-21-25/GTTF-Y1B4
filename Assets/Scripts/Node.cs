using UnityEngine;
using UnityEngine.Serialization;

/** Issues -> Renderer is not working.
 * Represents an in-game node, to which player places turrets.
 */
public class Node : MonoBehaviour {
    
    public Game gameManager;
    public Turret turret; // Turret on top of this
    Renderer _renderer;
    bool _occupied;

    [SerializeField] Color baseColour;
    [SerializeField] Color available;
    [SerializeField] public Color unavailable;
    
    /// Initialises necessary values
    void Start() {
        _occupied = turret == null;
        _renderer = GetComponent<Renderer>();
        
        gameObject.AddComponent<Renderer>();
        GetFromParent();
        
        _renderer.material.color = baseColour;
        gameManager = Game.Instance;
    }
    
    /// 
    void GetFromParent() {
        var parent = transform.parent.GetComponent<Node>();
        
        if (parent == null) return;
        
        baseColour = parent.baseColour;
        available = parent.available;
        unavailable = parent.unavailable;
    }

    /// Changes colour of this
    void OnMouseEnter() {
        if (_occupied) return;
        GetComponent<Renderer>().material.color = gameManager.shop.selected.cost <= Player.Money ? available : unavailable;
    }

    /// Resets to a basic colour
    void OnMouseExit() {
        GetComponent<Renderer>().material.color = baseColour;
    }
    
    /// Builds a turret on top of this (Pass turret only with set prefab)
    void Build() {
        if (_occupied || Player.Money < gameManager.shop.selected.cost) return;
        
        Player.Money -= gameManager.shop.selected.cost;
        var position = transform.position + turret.transform.position;
        var t = Instantiate(gameManager.shop.selected.prefab, position, Quaternion.Euler(Vector3.zero));
        turret = t.GetComponent<Turret>();
    }

    /// Selection
    public void Select() {
        // Select this
    }
    
    public void Deselect(ref Node node) {
        // Select this
        node = null;
    }
}