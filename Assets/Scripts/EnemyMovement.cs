using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

	private Enemy enemy;

	private Transform target;
	private int wavepointIndex = 0;

	void Start()
	{
		enemy = GetComponent<Enemy>();

		//Makes the enemy follow the wayponts
		target = Waypoints.points[0];
	}

		//Update void makes the enemy foloow the path of layed out waypoints
	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}


	}

	//This void structures the index of the waypoints that enemy is following
	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	//When enemy gets to the end and substracts the lives from the player
	void EndPath () 
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
	} 

}
