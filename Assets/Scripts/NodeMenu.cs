using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NodeMenu : MonoBehaviour{

    public int displayedSellCost;
    public int displayedUpgradeCost;
    public GameObject ui;
    public Button upgradeButton;
    private Node menuHost;

    /// Hides context menu
    public void Hide() {
        ui.SetActive(false);
    }

    /// Adds this to a host, which sent as a parameter
    public void Add(ref Node menuHost) {
        transform.position = this.menuHost.transform.position + menuHost.turret.GetComponent<Turret>().positionOffset;
        displayedSellCost = menuHost.turret.GetComponent<Turret>().GetSellCost();
        ui.SetActive(true);
        
        menuHost.contextMenu = this;
    }

    /// Upgrades the turret and deselects the node
    public void Upgrade() {
        menuHost.turret.GetComponent<Turret>().Upgrade();
        BuildManager.instance.DeselectNode();
    }

    /// Upgrades the turret and deselects the node
    public void Sell() {
        menuHost.turret.GetComponent<Turret>().Sell();
        BuildManager.instance.DeselectNode();
        menuHost.isUpgraded = false;
    }
}