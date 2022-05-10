using System;
using UnityEngine;
/**
 * This class provides tiles with tools to build towers on them
 */
public class Game : MonoBehaviour{
    
    public static Game instance; // The instance of an only Build Manager in the scene.
    public Turret turretToBuild { get; private set; }
    private Node selectedNode;


    /// Checks if player can build
    public bool CanBuild => turretToBuild != null;
    
    /// Checks if player has enough money to buy selected turret
    public bool HasMoney => PlayerStats.Money >= turretToBuild.GetComponent<Turret>().cost;
    
    /// Insures that this is the only BuildManager in the Scene
    private void Start() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene!");
            instance = null;
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
        selectedNode.contextMenu.Hide();
        selectedNode = null;
    }

    /// Selects a turret from a set -> (shop)
    public void SelectTurretToBuild(Turret turret) {
        turretToBuild = turret;
        DeselectNode();
    }
}