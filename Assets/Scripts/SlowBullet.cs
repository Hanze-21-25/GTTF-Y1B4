using UnityEngine;
public class SlowBullet : MonoBehaviour
{
	private Transform target;

	//Speed of the bullet variable
	public float speed = 70f;

	public int damage = 50;

	public string Csound;

	public Turret sTower;

	private float sAmount;

	//Explosion radius variable
	public float explosionRadius = 0f;
	public GameObject impactEffect;

	void Start ()
    {
		sAmount = sTower.slowAmount;
	}

	public void Seek(Transform _target)
	{
		target = _target;
	}

	//Update void makes the bullet follow the enemy
	void Update()
	{
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;
		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);

		//Makes the bullet always turn face to the enemy
		transform.LookAt(target);

	}

	void HitTarget()
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		
		Destroy(effectIns, 5f);

		//Explosion works if its radius is higher than 0 (Explode void getts called)
		if (explosionRadius > 0f)
		{
			Explode();
		}
		else
		{
			Damage(target);
		}

		//Bullet gets distroyed when touches the enemy
		Destroy(gameObject);
	}

	void Explode()
	{
		
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider collider in colliders)
		{

			//Detects the collision with game objects under "Enemy" tag
			if (collider.CompareTag("Enemy"))
			{
				Damage(collider.transform);

			}
		}
	}

	void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		//This function calls Damage taking funtion in enemy script
		
		
		if (e != null) 
		{
			e.TakeDamage(damage);
			e.Slow(sAmount);
		}

	}

	void OnDrawGizmosSelected()
	{
		//Draws the sphere around the missile (only in the scene view)
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}