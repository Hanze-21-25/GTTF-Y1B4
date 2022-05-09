using UnityEngine;
public class BuildManager : MonoBehaviour{
    
    public static BuildManager instance; // The instance of an only Build Manager in the scene.
    public GameObject turretToBuild { get; private set; }
    private Node selectedNode; 
    public NodeMenu nodeMenu;
    
    
    /// Checks if player can build
    public bool CanBuild => turretToBuild != null;
    /// Checks if player has enough money to buy selected turret
    public bool HasMoney => PlayerStats.Money >= turretToBuild.GetComponent<Turret>().cost;
    /// Insures that this is the only BuildManager in the Scene
    private void Awake() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    
    public void SelectNode(Node node) {
        // Deselects if you click on the same node you clicked before.
        if (selectedNode == node) {
            DeselectNode();
            return;
        }
        // Sets selected node to argument node.
        selectedNode = node;
        turretToBuild = null;

        nodeMenu.SetTarget(node);
    }

    /// Deselects a node
    public void DeselectNode() {
        selectedNode = null;
        nodeMenu.Hide();
    }

    /// Selects a turret from a set -> (shop)
    public Turret SelectTurretToBuild(Turret turret) {
        turretToBuild = turret;
        DeselectNode();
        return turretToBuild;
    }
}

/*
 *
 * .GetComponent<Turret>()
 */