using UnityEngine;
public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;
	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject carbPrefab;
	public GameObject seaturtlePrefab;
	public GameObject squidPrefab;
	public GameObject sealPrefab;
	public GameObject seagullPrefab;

	private TurretBlueprint turretToBuild;

	private Node selectedNode;

	public NodeUI nodeUI;

	//property that checks if player can build turrets
	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


	//Selected node makes the NodeUI appear
	public void SelectNode (Node node)
    {
		if (selectedNode == node)
        {
			DeselectNode();
			
			return;
			
        }

		selectedNode = node;
		turretToBuild = null;

		//Sets target from NodeUI script
		nodeUI.SetTarget(node);
    }

	//Makes the NodeUI disapear with the reference to the NodeUI script
	public void DeselectNode()
    {
		selectedNode = null;
		
		nodeUI.Hide();
    }

	//Reference to TurretBlueprint script to build the turret
	public void SelectTurretToBuild (TurretBlueprint turret)
    {
		FindObjectOfType<AudioManager>().Play("Tower selected");
		turretToBuild = turret;
		
		//Deselects the node when the turret is build
		DeselectNode();
    }

	public TurretBlueprint GetTurretToBuild ()
    {
		return turretToBuild;
    }


}
