using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	//Speed of the enemy
	public float speed = 10f;
	//Health of the enemy

	public int startHealth = 100;
	private bool IsDead = false;
	private float health;

	//The money that player gets from a specific enemy type
	public int value = 50;

	[Header("Unity stuff")]
	//Added healthbar
	public Image healthBar;

	private Transform target;
	private int wavepointIndex = 0;

	void Start()
	{
		//Makes the enemy follow the wayponts
		target = Waypoints.points[0];
		health = startHealth;
	}

	public void TakeDamage (int amount) 
	{
		//substrcts the damage amount from the enemy health
		health -= amount;

		healthBar.fillAmount = health / startHealth;

		//When enemy health is less than 0 is destroys itself
		if (health <= 0)
		{
			//void Die is called
			Die();
		}
	}


	//void Die makes the enemy destroy itself and gives the money amount to the player, as well as affects the wavespawner enemy count
	void Die ()
	 {
		if (IsDead)
		{ return; }
		if (health <= 0)
		{
			PlayerStats.Money += value;
			Destroy(gameObject);

			WaveSpawner.EnemiesAlive--;
			IsDead = true;
			Debug.Log("Enemy Death");
			Debug.Log(WaveSpawner.EnemiesAlive);

		}

	 }


	//Update void makes the enemy foloow the path of layed out waypoints
	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

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