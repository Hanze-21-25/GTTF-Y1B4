using UnityEngine;


/**
 * This class provides tiles with tools to build towers on them
 */


public class Game : MonoBehaviour {

    public Shop shop;
    public static Game Instance; // The instance of an only Build Manager in the scene.
    private Node _node; // to select node;

    /// Checks if player has enough money to buy selected turret
    public bool HasMoney => shop.selected.cost < Player.Money;
    
    /// Insures that this is the only BuildManager in the Scene
    private void Start() {
        var i = FindObjectOfType<Game>();
        if (i != null) {
            Destroy(i);
            return;
        }
        Instance = this;
    }
}