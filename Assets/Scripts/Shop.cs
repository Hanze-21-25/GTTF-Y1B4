using UnityEngine;
using UnityEngine.Serialization;

public class Shop : MonoBehaviour
{
	[Header("Prefabs")]
	public Turret crab;
	public Turret seaTurtle;
	public Turret squid;
	public Turret seal;
	public Turret seagull;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	/// Selection of a turret
	public void SelectCrabTurret()
	{
		Debug.Log("Crab Selected");
		buildManager.SelectTurretToBuild(crab);
	}
	public void SelectSeaTurtleTurret()
	{
		Debug.Log("Seaturtle Selected");
		buildManager.SelectTurretToBuild(seaTurtle);
	}
	public void SelectSquidTurret()
	{
		Debug.Log("Squid Selected");
		buildManager.SelectTurretToBuild(squid);
	}
	public void SelectSealTurret()
	{
		Debug.Log("Seal Selected");
		buildManager.SelectTurretToBuild(seal);
	}
	public void SelectSeagullTower()
	{
		Debug.Log("Seagull Tower Selected");
		buildManager.SelectTurretToBuild(seagull);
	}
}