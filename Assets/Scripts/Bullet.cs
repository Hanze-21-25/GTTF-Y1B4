using UnityEngine;
public class Bullet : MonoBehaviour
{
	private Transform target;

	//Speed of the bullet variable
	public float speed = 70f;

	public int damage = 50;
	//Explosion radius variable
	public float explosionRadius = 0f;
	public GameObject impactEffect;

	public void Seek(Transform _target)
	{
		target = _target;
	}
	
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

		if (e != null) 
		{
	       e.Damage(damage);

		}

	}

	void OnDrawGizmosSelected()
	{
		//Draws the sphere around the missile (only in the scene view)
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}