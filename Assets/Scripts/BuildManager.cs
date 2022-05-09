using UnityEngine;
public class BuildManager : MonoBehaviour{
    
    public static BuildManager instance; // The instance of an only Build Manager in the scene.
    public GameObject turretToBuild { get; private set; }
    private Node selectedNode;


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
    
    /// Selects and deselects node
    public void SelectNode(Node node) {
        // Deselects if you click on the same node you clicked before.
        if (selectedNode == node) {
            DeselectNode();
            return;
        }
        // Sets selected node to argument node.
        selectedNode = node;
        turretToBuild = null;

        selectedNode.contextMenu.Add(ref node);
    }

    /// Deselects a node
    public void DeselectNode() {
        selectedNode = null;
        selectedNode.contextMenu.Hide();
    }

    /// Selects a turret from a set -> (shop)
    public void SelectTurretToBuild(Turret turret) {
        turretToBuild = turret.gameObject;
        DeselectNode();
    }
}