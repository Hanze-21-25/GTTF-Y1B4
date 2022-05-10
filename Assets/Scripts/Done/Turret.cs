using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Turret : MonoBehaviour
{
	private Transform target;

	[Header("Prefabs")]
	public GameObject prefab;
	public GameObject upgradedPrefab;
	
	[Header("Attributes")]
	public int cost;
	public int upgradeCost;
	public float range = 15f;
	public float fireRate = 1f;
	private float fireCountdown;
	public bool upgraded;
	public Vector3 positionOffset; // Offset of a turret from this
	public Node host;

	[Header("Unity Setup Fields")]
	public string enemyTag = "Enemy";
	public Transform partToRotate;
	public float turnSpeed = 10f;
	public GameObject bulletPrefab;
	public Transform firePoint;
	
	/// Executes working loop
	void Start()
	{
		InvokeRepeating("Target", 0f, 0.5f);
	}

	/// Targets closest enemy (launched from the start loop) 
	void Target()
	{

		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		}
		else
		{
			target = null;
		}

	}

	/// Executes combat
	void Update()
	{ 
		if (target == null)
			return;
		
		CheckUpgraded();

		//Target lock on
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if (fireCountdown <= 0f)
        {
			Shoot();
			fireCountdown = 1f / fireRate;

		}
		fireCountdown -= Time.deltaTime;

	}
	
	/// Launches a projectile towards closest enemy
	void Shoot ()
    {
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
			bullet.Seek(target);
	}
	
	///  Gets the cost of a turret on sale
	public int GetSellCost() {
		return cost / 2;
	}

	/// Checks if turret is upgraded
	private void CheckUpgraded() {
		if (!upgraded) {
			host.contextMenu.upgradeButton.interactable = true;
		}
		else {
			host.contextMenu.upgradeButton.interactable = true;
		}
	}

	/// Upgrades a turret
	public void Upgrade() {
		if (Player.Money < GetComponent<Turret>().upgradeCost) {
			Debug.Log("You dont have enough money to upgrade that!");
			return;
		}
		//Deleting old turret
		Destroy(this);
		//Building a new turret
		prefab = Instantiate(upgradedPrefab,
			transform.position + positionOffset,
			Quaternion.identity);
		upgraded = true;
		Debug.Log("Turret upgraded!");
	}

	/// Sells turret
	public void Sell() {
		Player.Money +=  GetSellCost();
		upgraded = false;
		Destroy(this);
	}
}