using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyDeath : MonoBehaviour
{

    [SerializeField] private float explosionStrenght;
    [SerializeField] private float explosionTorque;
    [SerializeField] private ParticleSystem deadParticles;

	public void Start()
	{
		Death();
	}

	public void Death()
	{
		//Collider2D[] parts = GetComponentsInChildren<Collider2D>();

		Rigidbody2D[] parts = GetComponentsInChildren<Rigidbody2D>();
		foreach (Rigidbody2D part in parts)
		{
			if(part != null)
			{
				Vector2 dir = part.transform.position - transform.position;
				float distance = 1 + dir.magnitude;
				float finalForce = explosionStrenght / distance;
				part.AddTorque(-dir.x * explosionTorque, ForceMode2D.Force);
				part.AddForce(dir * finalForce, ForceMode2D.Impulse);
			}
		}
		Instantiate(deadParticles, transform.position, Quaternion.identity);
	}
}
