using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{
    
    [SerializeField] private Color hoverColor; // Available colour
    public Color notEnoughMoneyColor; // Unavailable colour
    public Vector3 positionOffset; // Offset of a turret from this

    [HideInInspector] public GameObject turret; // Turret on top of this
    [HideInInspector] public bool isUpgraded; 

    private Renderer rend; //??
    private Color startColor; //Basic colour of this

    BuildManager buildManager;
    
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
        
        this.turret = Instantiate(turret.GetComponent<Turret>().prefab, transform.position + positionOffset, Quaternion.identity);
        Debug.Log("Turret build!");
    }

    
    /// Upgrades a turret
    public void UpgradeTurret() {
        if (PlayerStats.Money < this.turret.GetComponent<Turret>().upgradeCost) {
            Debug.Log("You dont have enough money to upgrade that!");
            return;
        }
        var turret = this.turret.GetComponent<Turret>();
        var oldTurret = turret;
        //Deleting old turret
        Destroy(this.turret);
        //Building a new turret
        this.turret = Instantiate(oldTurret.upgradedPrefab,
            transform.position + positionOffset,
            Quaternion.identity);
        isUpgraded = true;
        Debug.Log("Turret upgraded!");
    }

    /// Sells turret
    public void SellTurret() {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;
    }

    /// Changes colour of this
    void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (buildManager.HasMoney) {
            rend.material.color = hoverColor;
        }
        else {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    /// Resets to a basic colour
    void OnMouseExit() {
        rend.material.color = startColor;
    }
}