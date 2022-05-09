using UnityEngine;
using UnityEngine.UI;

public class NodeMenu : MonoBehaviour{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private Node menuHost;

    /*public void SetTarget(Node _target) {
        target = _target;

        transform.position = target.transform.position + target.positionOffset;
        // checks if turret is upgraded if set to do so
        if (!target.isUpgraded) {
            upgradeCost.text = "Upgraded" + target.GetComponent<Turret>().upgradeCost;
            upgradeButton.interactable = true;
        }
        else {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        sellAmount.text = "$" + target.GetComponent<Turret>().GetSellCost();
        ui.SetActive(true);
    }*/

    /// Hides context menu
    public void Hide() {
        ui.SetActive(false);
    }

    public void SetTarget(Node menuHost) {
        this.menuHost = menuHost;

        transform.position = menuHost.transform.position + menuHost.positionOffset;
        // checks if turret is upgraded if set to do so
        if (!menuHost.isUpgraded) {
            upgradeCost.text = "Upgraded" + menuHost.turret.GetComponent<Turret>().upgradeCost;
            upgradeButton.interactable = true;
        }
        else {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        sellAmount.text = "$" + menuHost.turret.GetComponent<Turret>().GetSellCost();
        ui.SetActive(true);
    }

    /// 
    public void Upgrade() {
        // Upgrades the turret and deselects the node
        menuHost.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    /// Upgrades the turret and deselects the node
    public void Sell() {
        menuHost.SellTurret();
        BuildManager.instance.DeselectNode();
        menuHost.isUpgraded = false;
    }
}