using UnityEngine;
using UnityEngine.UI;

//This script is the UI attached to the node, when the turret on it being selected
public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    //Upgrade codt can be chosen for a specific turret
    public Text upgradeCost;
    public Button upgradeButton;
    //SellAmount also can be defined
    public Text sellAmount;
    //Node is the target parameter
    private Node target;
    public GameObject rangeIndic;
    private Vector3 towerPos;

    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    //Sets the target on selected turret
    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();


        if (!target.isUpgraded)
        {
            //reference to the turretBlueprint to extract the upgrade cost from the player
            upgradeCost.text = "¤" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }else
        {
            //Instead of text upgrade there is text DONE on the button
            upgradeCost.text = "DONE";
            //and button is no longer interctable
            upgradeButton.interactable = false;
        }

        sellAmount.text = "¤" + target.turretBlueprint.GetSellAmount();

        //UI gets displyed
        ui.SetActive(true);
    }

    public void Hide ()
    {
        ui.SetActive(false);
    }
    
    
    //Upgrades the turret and deselects the node
    public void Upgrade()
    {
        target.UpgradeTurret();
        //and the node gets deselected
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        //SellTurret void is from Node script
        target.SellTurret();
        BuildManager.instance.DeselectNode();
        target.isUpgraded = false;
    }

}
