using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

	public float speed = 10f;

	public int startHealth = 100;
	private float health;

	public int value = 50;

	[Header("Unity stuff")]
	public Image healthBar;

	private Transform target;
	private int wavepointIndex = 0;

	void Start()
	{
		target = Waypoints.points[0];
		health = startHealth;
	}

	public void TakeDamage (int amount) 
	{
        health -= amount;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0)
		{
             Die();
		}
	}

	void Die ()
	 {
        PlayerStats.Money += value;
        Destroy (gameObject);

		WaveSpawner.EnemiesAlive--;
	 }

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}
	}

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

    void EndPath () 
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
	} 

}