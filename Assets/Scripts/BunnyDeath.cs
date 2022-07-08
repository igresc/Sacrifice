using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyDeath : MonoBehaviour
{

    [SerializeField] private float explosionStrenght;

	public void Start()
	{
		Death();
	}

	public void Death()
	{
		//Collider2D[] parts = GetComponentsInChildren<Collider2D>();

		Rigidbody2D[] parts = GetComponentsInChildren<Rigidbody2D>();
		Debug.Log(parts);
		foreach (Rigidbody2D part in parts)
		{
			//if (part != null) {
			//	Vector2 dir = part.transform.position - transform.position;
			//	float distance = 1 + dir.magnitude;
			//	float finalForce = explosionStrenght / distance;
			//	part.AddForce(dir * finalForce);
			//}
		}
	}
}
