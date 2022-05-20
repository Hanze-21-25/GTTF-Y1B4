using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	
	public Color hoverColor;
	public Color notEnoughMoneyColor;
	public Vector3 positionOffset;
	
	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;


	private Renderer rend;
	private Color startColor;

	BuildManager buildManager;

	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition ()
    {
		return transform.position + positionOffset;
    }
	//When mouse is presses and the mouse is above the node, buildmanager function of building the turret is called

	void OnMouseUp()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		

		if (!buildManager.CanBuild)
			return;

		BuildTurret(buildManager.GetTurretToBuild());
	}

	void BuildTurret (TurretBlueprint blueprint)
    {
		//function checks if player has enough money to build a turret

		if (PlayerStats.Money < blueprint.cost)
		{
			Debug.Log("You dont have enough money to build that!");
			return;
		}
		
		//substracts the cost of the turret from player money
		PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity); //Quaternion.identity - no rotation
		turret = _turret;

		turretBlueprint = blueprint;

		Debug.Log("Turret build!");
		FindObjectOfType<AudioManager>().Play("Tower placed");
	}

	public void UpgradeTurret()
    {
		if (PlayerStats.Money < turretBlueprint.upgradeCost)
		{
			Debug.Log("You dont have enough money to upgrade that!");
			return;
		}
		
		//substracts the cost of the upgrade from player money
		PlayerStats.Money -= turretBlueprint.upgradeCost;

		//Deleting old turret
		Destroy(turret);

		//Building a new turret
		GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		isUpgraded = true;

		FindObjectOfType<AudioManager>().Play("Tower upgraded");
	}

	public void SellTurret()
    {
		//adds the sell amount to the player money
		PlayerStats.Money += turretBlueprint.GetSellAmount();

		Destroy(turret);
		turretBlueprint = null;
		FindObjectOfType<AudioManager>().Play("Tower sold");

	}


	void OnMouseEnter()
	{
		//When the mouse if above the node, it changes the color
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;
		//If payer does not have enough money to build the turret, node displays other color
		if (buildManager.HasMoney){

          rend.material.color = hoverColor;
		} else {
			rend.material.color = notEnoughMoneyColor;
		}

	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}