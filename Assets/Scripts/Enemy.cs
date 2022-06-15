using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
	public float startSpeed = 10f;
	public string death_sound;
	
	//Speed of the enemy
	[HideInInspector]
	public float speed;
	
	//Health of the enemy
	public float startHealth = 100;
	private bool IsDead = false;
	private float health;

	//The money that player gets from a specific enemy type
	public int value = 50;

	[Header("Unity stuff")]
	//Added healthbar
	public Image healthBar;

	void Start()
	{
		health = startHealth;
		speed = startSpeed;
	}

	public void TakeDamage (float amount) 
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

	public void Slow (float pct)
    {
		speed = startSpeed * (1f - pct);
		StartCoroutine(Wait());
	}

	//Wait to remove slow 
	IEnumerator Wait ()
	{
		yield return new WaitForSeconds(5);
		speed = startSpeed;
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
			FindObjectOfType<AudioManager>().Play(death_sound);

		}

	 }

}