using UnityEngine;
using System.Collections;

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

	void Target()
	{
		//Makes turret focus on the closest enemy

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


	void Update()
	{
		if (target == null)
			return;

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

	void Shoot ()
    {
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
			bullet.Seek(target);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, range);
	}
	public int GetSellCost() {
		return cost / 2;
	}
}