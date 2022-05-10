using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NodeMenu : MonoBehaviour{

    public int displayedSellCost;
    public int displayedUpgradeCost;
    public GameObject ui;
    public Button upgradeButton;
    private Node host;

    /// Adds this to a host, which sent as a parameter
    public void Add(Node host) {
        transform.position = host.transform.position + host.turret.GetComponent<Turret>().positionOffset;
        displayedSellCost = host.turret.GetComponent<Turret>().GetSellCost();
        ui.SetActive(true);
        host.contextMenu = this;
    }

    /// Upgrades the turret and deselects the node
    public void Upgrade() {
        host.turret.Upgrade();
        host.Deselect();
    }

    /// Upgrades the turret and deselects the node
    public void Sell() {
        host.turret.Sell();
        host.Deselect();
    }
}