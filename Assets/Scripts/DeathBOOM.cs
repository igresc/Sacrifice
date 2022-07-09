using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBOOM : MonoBehaviour
{

    [SerializeField] private float explosionStrenght;
    [SerializeField] private float explosionTorque;
    [SerializeField] private ParticleSystem deadParticles;

	public void Start()
	{
		Death();
		Destroy(gameObject, 2.0f);
	}

	public void Death()
	{
		Rigidbody2D[] parts = GetComponentsInChildren<Rigidbody2D>();
		foreach (Rigidbody2D part in parts)
		{
			if(part != null)
			{
				Vector2 dir = part.transform.position - transform.position;
				if(dir.y < 0) dir.y *= -1;
				float distance = 1 + dir.magnitude;
				float finalForce = explosionStrenght / distance;
				part.AddTorque(-dir.x * explosionTorque, ForceMode2D.Force);
				part.AddForce(dir * finalForce, ForceMode2D.Impulse);
			}
		}
		Instantiate(deadParticles, transform.position, Quaternion.identity);
	}
}
