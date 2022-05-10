using System;
using UnityEngine;
/**
 * This class provides tiles with tools to build towers on them
 */
public class Game : MonoBehaviour{
    
    public static Game instance; // The instance of an only Build Manager in the scene.
    public Turret selectedTurret { get; private set; }
    private Node node; // to select node;

    /// Checks if player has enough money to buy selected turret
    public bool HasMoney => selectedTurret.cost ;
    
    /// Insures that this is the only BuildManager in the Scene
    private void Start() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene!");
            instance = null;
            return;
        }
        instance = this;
    }

    /// Selects a turret from a set -> (shop)
    public void SelectTurret(Turret turret) {
        selectedTurret = turret;
        Deselect(ref node);
    }
}