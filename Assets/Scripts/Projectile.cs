using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public CircleCollider2D circleCollider;
	[HideInInspector] public bool isRespawn = false;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
	}

	public void Throw(Vector2 force)
	{
		rb.AddForce(force, ForceMode2D.Impulse);
	}

	public void ActivateRb()
	{
		rb.isKinematic = false;
	}
	public void DesactivateRb()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
		rb.isKinematic = true;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag != "Player")
		{
			DesactivateRb();
			isRespawn = true;
		}
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}
}
