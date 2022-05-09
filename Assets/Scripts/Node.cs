using UnityEngine;
using UnityEngine.EventSystems;
/**
 * Represents an in-game node, to which player places turrets.
 */
public class Node : MonoBehaviour {
    
    public GameObject turret; // Turret on top of this
    public bool isUpgraded;
    private Renderer rend;
    private Color startColor; //Basic colour of this
    private BuildManager buildManager;
    public NodeMenu contextMenu;

    [SerializeField] private Color available; // Available colour
    [SerializeField] public Color unavailable; // Unavailable colour
    
    /// Initialises necessary values
    void Start() {
        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    
    /// Calls BuildTurret
    void OnMouseDown() {
        BuildTurret(buildManager.turretToBuild);
    }

    /// Builds a turret on top of this
    void BuildTurret(GameObject turret) {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (turret != null) {
            buildManager.SelectNode(this);
            return;
        } if (!buildManager.CanBuild) return;
        if (PlayerStats.Money < turret.GetComponent<Turret>().cost) {
            Debug.Log("You dont have enough money to build that!");
            return;
        }
        PlayerStats.Money -= turret.GetComponent<Turret>().cost; 
        
        this.turret = Instantiate(turret.GetComponent<Turret>().prefab,
            transform.position + turret.GetComponent<Turret>().positionOffset,
            Quaternion.identity);
        
        Debug.Log("Turret build!");
    }

    /// Changes colour of this
    void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (buildManager.HasMoney) {
            rend.material.color = available;
        }
        else {
            rend.material.color = unavailable;
        }
    }

    /// Resets to a basic colour
    void OnMouseExit() {
        rend.material.color = startColor;
    }
}