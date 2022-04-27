using UnityEngine;

public class Shop : MonoBehaviour
{
	public TurretBlueprint Crab;
	public TurretBlueprint Seaturtle;
	public TurretBlueprint Squid;
	public TurretBlueprint Seal;
	public TurretBlueprint Seagull;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectCrabTurret()
	{
		Debug.Log("Crab Selected");
		buildManager.SelectTurretToBuild(Crab);
	}

	public void SelectSeaturtleTurret()
	{
		Debug.Log("Seaturtle Selected");
		buildManager.SelectTurretToBuild(Seaturtle);
	}
	
	public void SelectSquidTurret()
	{
		Debug.Log("Squid Selected");
		buildManager.SelectTurretToBuild(Squid);
	}

	public void SelectSealTurret()
	{
		Debug.Log("Seal Selected");
		buildManager.SelectTurretToBuild(Seal);
	}

	public void SelectSeagullTower()
	{
		Debug.Log("Seagull Tower Selected");
		buildManager.SelectTurretToBuild(Seagull);
	}
}